package activitat;

//import com.sun.jdi.connect.spi.Connection;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.sql.Connection;
import java.sql.DriverManager;
import java.time.LocalDateTime;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.sql.SQLException;
import java.sql.PreparedStatement;
import java.lang.String;
import java.io.FileWriter;
import java.io.OutputStreamWriter;
import org.json.JSONException;
import org.json.JSONObject;

public class Unf0und_Server {
        static String bd = "a21llucaptor_Unf0und_Beta";
        static String url = "jdbc:mysql://labs.inspedralbes.cat:3306/";
        static String user = "a21llucaptor_lcapo";
        static String password = "estaNoEsMiContrasena2";
        static String driver = "com.mysql.cj.jdbc.Driver";
        static Connection cx;
        static String[] nameList = new String[10];
        static String[] scoreList = new String[10];
        static String[] emailList = new String[10];
        
    public static void main(String[] args) throws IOException, InterruptedException{
        
        int portNumber = 9000;
        Connect();

        try {
            ServerSocket serverSocket = new ServerSocket(portNumber);
            System.out.println("Socket creat");
            String inputLine;

            while (true) {
                Socket clientSocket = serverSocket.accept();
                System.out.println("Crida del client acceptada");
                PrintWriter out = new PrintWriter(clientSocket.getOutputStream(), true);
                InputStreamReader isr = new InputStreamReader(clientSocket.getInputStream());
                //InputStreamWriter isw = new InputStreamWriter(clientSocket.getOutputStream());
                BufferedReader in = new BufferedReader(isr);
                
                while ((inputLine = in.readLine()) != null) {
                    
                    String nick = inputLine.split("/")[0];
                    String email = inputLine.split("/")[1];
                    String score = inputLine.split("/")[2];
                    //Insert(nick, email, score);
                    out.println(Select());
                    break;
                }
                
                System.out.println("sale del while");
                System.out.println("Socket del client tancat. Tornem a esperar una connexió");
                
                if (clientSocket.isConnected())
                    clientSocket.close();
            }
        } catch (IOException e) {
            System.out.println("Exception caught when trying to listen on port "
                    + portNumber + " or listening for a connection");
            System.out.println(e.getMessage());
        }
        
        Desconectar();

    }
    
    public static Connection Connect()
    {
        try {
            Class.forName(driver);
            cx = DriverManager.getConnection(url+bd, user, password);
            System.out.println("conectado");
        } catch (ClassNotFoundException | SQLException ex) {
            System.out.println("no conectado " + ex.getMessage());
        }
        return cx;
    }
    
    public static void Insert(String _nick, String _email ,String _score)
    { 
            try {
                String query = "insert into Saves (nick, email, score) values ('" + _nick + "', '" + _email + "','"+Integer.parseInt(_score)+"')";
                // create the mysql insert preparedstatement
                PreparedStatement preparedStmt = cx.prepareStatement(query);
                preparedStmt.execute();
                //preparedStmt.setString (1, "Barney");
            } catch (SQLException ex) {
                System.out.println("Error en insertar " + ex.getMessage());
            }
    }
    
    public static String Select()
    {
        try{
            String query = "SELECT nick, email, score FROM Saves ORDER BY score DESC";
            PreparedStatement stmt = cx.prepareStatement(query);
            var rs = stmt.executeQuery(query);
            int index = 0;
            while(rs.next() && index < 10)
            {
                nameList[index] = rs.getString("nick");
                scoreList[index] = Integer.toString(rs.getInt("score"));
                emailList[index] = rs.getString("email");
                //SetInfoInJSON(nameList[index], scoreList[index]);
                index++;
            }
            
                        
        }catch(Exception e)
        {
            System.out.println(e.getMessage());
        }
        
        return SetInfoInJSON(nameList, emailList, scoreList).toString();

    }
    
    public static JSONObject SetInfoInJSON(String[] _nick, String[] _email, String[] _score)
    {
        JSONObject obj = new JSONObject();
            try {
                for(int i = 0; i < _nick.length; i++)
                {
                    obj.append("nick", _nick[i]);
                    obj.append("email", _email[i]);
                    obj.append("score", _score[i]);
                }
            } catch (JSONException ex) {
                System.out.println(ex.getMessage());
            }
        return obj;
    }
    
    public static void Desconectar()
    {
        try {
            cx.close();
        } catch (SQLException ex) {
            Logger.getLogger(Unf0und_Server.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
