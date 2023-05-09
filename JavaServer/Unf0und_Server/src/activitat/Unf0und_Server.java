package activitat;
//git

import java.io.IOException;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.mail.*;
import javax.mail.internet.*;
import javax.activation.*;
import java.io.IOException;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.mail.Address;
import javax.mail.BodyPart;
import javax.mail.Flags;
import javax.mail.Folder;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Multipart;
import javax.mail.NoSuchProviderException;
import javax.mail.Session;
import javax.mail.Store;
import javax.mail.internet.MimeMessage;
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
                    
                    CheckScore(nick, Integer.parseInt(score));
                    Insert(nick, email, score);
                    
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
    
    public static void CheckScore(String _nick, int _score)
    {
            try {
                String query = "SELECT nick, email, score FROM Saves WHERE score = (SELECT MAX(score) FROM Saves)";
                PreparedStatement stmt = cx.prepareStatement(query);
                var rs = stmt.executeQuery(query);
                int maxScore = 0;
                String maxScoreEmail = "";
                
                while(rs.next())
                {
                    maxScoreEmail = rs.getString("email");
                    maxScore = rs.getInt("score");
                }
                
                
                if(_score > maxScore)
                {
                    System.out.println("------- Check, true " + maxScoreEmail);
                    SendEmail(_nick, maxScoreEmail);
                }
                else
                    System.out.println("------- Check, false, " +maxScore+ "  /  "+_score);
                
                
                System.out.println(maxScoreEmail + "    " + maxScore);
            } catch (SQLException ex) {
                Logger.getLogger(Unf0und_Server.class.getName()).log(Level.SEVERE, null, ex);
            }
    }
    
     public static void SendEmail(String _nick, String _email)
    {
         String from = "grup02@m09.alumnes.inspedralbes.cat";
         String password = "grup02_M09";
         String host = "mail.m09.alumnes.inspedralbes.cat";
         String port = "587";
         String username = from; // correct password for gmail id
         String to = _email;

        
        System.out.println("Comencem!!!");


        // Get system properties
        Properties properties = System.getProperties();

        // Setup mail server
        properties.setProperty("mail.smtp.host", host);

        // SSL Port
        properties.put("mail.smtp.port", port);

        // enable authentication
        properties.put("mail.smtp.auth", "true");

        // SSL Factory
        properties.put("mail.smtp.socketFactory.class",
                "javax.net.ssl.SSLSocketFactory");
        
        Session session = null;
        
        try{
            session = Session.getDefaultInstance(properties,
                    new javax.mail.Authenticator() {

                // override the getPasswordAuthentication
                // method
                protected PasswordAuthentication
                        getPasswordAuthentication() {
                    return new PasswordAuthentication(username, password);
                } 
            });
        }catch(Exception e){
            System.out.println(e.getMessage());
        }

//compose the message
        try {
            // javax.mail.internet.MimeMessage class is mostly
            // used for abstraction.
            MimeMessage message = new MimeMessage(session);

            // header field of the header.
            message.setFrom(new InternetAddress(from));

            message.addRecipient(Message.RecipientType.TO,
                    new InternetAddress(to));
            message.setSubject("Unf0und_VR Notify");
            message.setText("¡" + _nick + " te ha superado, ya no eres la persona con la puntuación más alta!");

            // Send message
            System.out.println("Inici de l'enviament... (paciència que pot trigar uns 10 segons.... )");
            Transport.send(message);
            System.out.println("Enviat!!!");
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
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
