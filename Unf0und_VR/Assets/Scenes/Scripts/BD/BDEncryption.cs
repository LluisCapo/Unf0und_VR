using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System.IO;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Engines;
using UnityEngine.InputSystem;

public class BDEncryption : MonoBehaviour
{

    public BDInfoToInsert playerInfo;
    private void Start()
    {

        Send("reguii/reguii@tupu.com/36/Unf0und_VR");
    }
    public void Send(string msgToSend)
    {
        //Genero contra
        byte[] pwd = GenerateRandomKey();

        //Genero contra encriptada con clave pública
        byte[] contraCif = EncryptAsim(pwd, GetKey());

        //Encripto mensaje con clave
        byte[] mesgCif = EncryptSim(msgToSend, pwd);

        //Envio contraseña cifrada con clave + texto cifrado con contraseña
        Debug.Log("n -> " + mesgCif.Length + "   " + Encoding.ASCII.GetString(mesgCif));
        byte[] mesgToSend = new byte[contraCif.Length + mesgCif.Length];

        for (int i = 0; i < contraCif.Length; i++)
            mesgToSend[i] = contraCif[i];

        for (int i = contraCif.Length; i <= mesgToSend.Length - 1; i++)
            mesgToSend[i] = mesgCif[i - 256];

        Debug.Log(Encoding.ASCII.GetString(mesgToSend));

        Debug.Log($"Contra --> {contraCif.Length}   mesg --> {mesgCif.Length}   total --> {mesgToSend.Length}  {mesgToSend[mesgToSend.Length - 1]}");

        GetComponent<BDManager>().BDStart(mesgToSend);
    }


    /*public byte[] EncryptAsim(string _pw, RSA _key)
    {
        byte[] plainBytes = Encoding.ASCII.GetBytes(_pw);
        RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;

        return _key.Encrypt(plainBytes, padding);
    }*/

    public byte[] CifradoAlReves(byte[] _key)
    {
        byte[] newByte = new byte[_key.Length];

        for(int i = _key.Length - 1; i >= 0; i--)
            newByte[_key.Length - 1 - i] = _key[i];

        Debug.Log(Encoding.ASCII.GetString(newByte));

        return newByte;
    }

    public byte[] EncryptAsim(byte[] _pw, RSA _key)
    {
        //byte[] plainBytes = Encoding.ASCII.GetBytes(_pw);
        RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;

        return _key.Encrypt(_pw, padding);
    }

    public RSA GetKey()
    {
        byte[] crtData = File.ReadAllBytes("C://Users/Lluis Capo/Downloads/CLAUS/Claus/Lluis.crt");
        X509Certificate2 cert = new X509Certificate2(crtData);

        // Obtener la clave pública del certificado
        RSA publicKey = cert.GetRSAPublicKey();
        return publicKey;
    }

    public byte[] GenerarContraseña()
    {
        // Definir la contraseña y la sal
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes("aqui va la contraseña");
        byte[] salt = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        // Definir el número de iteraciones y la longitud de la clave
        int iterations = 1000;
        int keyLength = 256; // en bits

        // Crear un generador de contraseñas simétricas con PKCS5S2

        Pkcs5S2ParametersGenerator generator = new Pkcs5S2ParametersGenerator();
        generator.Init(bytes, salt, iterations);
        // Generar la clave simétrica
        KeyParameter key = (KeyParameter)generator.GenerateDerivedParameters(keyLength);
        byte[] symmetricKey = key.GetKey();

        return symmetricKey;
    }
    public byte[] EncryptSim(string plainText, byte[] passwordBytes)
    {
        //byte[] key = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordBytes);

        byte[] plaintext = Encoding.ASCII.GetBytes(plainText);
        //byte[] ciphertext = new byte[plaintext.Length];

        RC4 rc4 = new RC4(passwordBytes);
        return rc4.Encrypt(plaintext);

    }


    public byte[] GenerateRandomKey()
    {
        byte[] key = new byte[16];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(key);
        }

        return key;
    }
}
