using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using System.IO;

public class BDEncryption : MonoBehaviour
{

    public BDInfoToInsert playerInfo;
    private string publicKeyPath;
    public void StartBDCall()
    {
        try
        {
            publicKeyPath = "C:/Users/Tarda/Downloads/Claus/Lluis.crt";
            Send($"{playerInfo.nick}/{playerInfo.email}/{playerInfo.score}/Unf0und_VR");
        }
        catch
        {
            Debug.LogWarning("Error en la carga de archivos o internet.");
        }
    }
    private void Send(string msgToSend)
    {
        //Genero contra
        byte[] pwd = GenerateRandomKey();
        //Genero contra encriptada con clave pública
        byte[] contraCif = EncryptAsim(pwd, GetKey());

        //Encripto mensaje con clave
        byte[] mesgCif = EncryptSim(msgToSend, pwd);

        //Envio contraseña cifrada con clave + texto cifrado con contraseña
        Debug.Log("n -> " + mesgCif.Length + "   " + Encoding.ASCII.GetString(mesgCif));

        byte[] mesgToSend = ConcatBytes(contraCif, mesgCif);

        Debug.Log(Encoding.ASCII.GetString(mesgToSend));

        Debug.Log($"Contra --> {contraCif.Length}   mesg --> {mesgCif.Length}   total --> {mesgToSend.Length}  {mesgToSend[mesgToSend.Length - 1]}");

        GetComponent<BDManager>().BDStart(mesgToSend);
    }
    private byte[] EncryptAsim(byte[] _pw, RSA _key)
    {
        //byte[] plainBytes = Encoding.ASCII.GetBytes(_pw);
        RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;

        return _key.Encrypt(_pw, padding);
    }
    private RSA GetKey()
    {
        byte[] crtData = File.ReadAllBytes(publicKeyPath);
        X509Certificate2 cert = new X509Certificate2(crtData);

        // Obtener la clave pública del certificado
        RSA publicKey = cert.GetRSAPublicKey();
        return publicKey;
    }
    private byte[] EncryptSim(string plainText, byte[] passwordBytes)
    {
        //byte[] key = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordBytes);

        byte[] plaintext = Encoding.ASCII.GetBytes(plainText);
        //byte[] ciphertext = new byte[plaintext.Length];

        RC4 rc4 = new RC4(passwordBytes);
        return rc4.Encrypt(plaintext);

    }
    private byte[] GenerateRandomKey()
    {
        byte[] key = new byte[64];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(key);
        }

        return key;
    }
    private byte[] ConcatBytes(byte[] contraCif, byte[] mesgCif)
    {
        byte[] mesgToSend = new byte[contraCif.Length + mesgCif.Length];

        for (int i = 0; i < contraCif.Length; i++)
            mesgToSend[i] = contraCif[i];

        for (int i = contraCif.Length; i <= mesgToSend.Length - 1; i++)
            mesgToSend[i] = mesgCif[i - 256];

        return mesgToSend;
    }
}
