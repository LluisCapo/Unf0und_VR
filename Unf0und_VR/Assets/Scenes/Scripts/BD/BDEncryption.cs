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
        //Send();

        //Genero contra
        byte[] pwd = Encoding.ASCII.GetBytes("hola");//GenerateRandomKey();
        //Genero clave encriptada
        byte[] contraCif = EncryptAsim(GenerateRandomKey(), GetKey());
        //Encripto texto
        byte[] mesgCif = EncryptSim("Hola buenas tardes", pwd);
        //Envio contraseña + texto
        Debug.Log("n -> " + mesgCif.Length + "   " + Encoding.ASCII.GetString(mesgCif));

        byte[] mesgToSend = new byte[contraCif.Length + mesgCif.Length];

        for(int i = 0; i < contraCif.Length; i++)
            mesgToSend[i] = contraCif[i];

        for(int i = contraCif.Length; i < mesgToSend.Length - 1; i++)
            mesgToSend[i] = mesgCif[i - 255];

        Debug.Log($"Contra --> {contraCif.Length}   mesg --> {mesgCif.Length}   total --> {mesgToSend.Length}  {mesgToSend[mesgToSend.Length-1]}");
        //GetComponent<BDManager>().BDStart(mesgToSend);
        //GetComponent<BDManager>().BDStart(contraCif);

        //GetComponent<BDManager>().BDStart(EncryptAsim("hola soc en raul", GetKey()));
    }
    public void Send()
    {
        //Aqui se encripta
        //byte[] a = Encrypt($"{nick.text}/{score.text}", xd());
        byte[] a = EncryptAsim($"{playerInfo.nick}/{playerInfo.email}/{playerInfo.score}", GetKey());

        string aS = System.Text.Encoding.ASCII.GetString(a);
        Debug.Log(aS);
        Debug.Log(System.Text.Encoding.ASCII.GetBytes(aS).Length);

        GetComponent<BDManager>().BDStart(a);
    }


    public byte[] EncryptAsim(string _pw, RSA _key)
    {
        byte[] plainBytes = Encoding.ASCII.GetBytes(_pw);
        RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;

        return _key.Encrypt(plainBytes, padding);
    }

    public byte[] EncryptAsim(byte[] _pw, RSA _key)
    {
        //byte[] plainBytes = Encoding.ASCII.GetBytes(_pw);
        RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;

        return _key.Encrypt(_pw, padding);
    }

    public RSA GetKey()
    {
        byte[] crtData = File.ReadAllBytes("C://Users/super/Downloads/ServerConCifrado/CLAUS/Claus/Lluis.crt");
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
        byte[] messageBytes = Encoding.ASCII.GetBytes(plainText);

        TwofishEngine twofish = new TwofishEngine();
        twofish.Init(true, new KeyParameter(passwordBytes));

        byte[] encrypted = new byte[twofish.GetBlockSize()];
        twofish.ProcessBlock(messageBytes, 0, encrypted, 0);

        return encrypted;
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
