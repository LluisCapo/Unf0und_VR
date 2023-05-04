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

public class BDEncryption : MonoBehaviour
{
    private void Start()
    {
        Send();
    }
    public void Send()
    {
        //Aqui se encripta
        //byte[] a = Encrypt($"{nick.text}/{score.text}", xd());
        byte[] a = Encrypt($"pablo/69", xd());

        string aS = System.Text.Encoding.ASCII.GetString(a);
        Debug.Log(aS);
        Debug.Log(System.Text.Encoding.ASCII.GetBytes(aS).Length);

        GetComponent<BDManager>().BDStart(a);
    }


    public byte[] Encrypt(string _pw, RSA _key)
    {
        byte[] plainBytes = Encoding.ASCII.GetBytes(_pw);
        RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;

        return _key.Encrypt(plainBytes, padding);
    }

    public RSA xd()
    {
        byte[] crtData = File.ReadAllBytes("C://Users/super/Downloads/ServerConCifrado/CLAUS/Claus/Lluis.crt");
        X509Certificate2 cert = new X509Certificate2(crtData);

        // Obtener la clave pública del certificado
        RSA publicKey = cert.GetRSAPublicKey();
        return publicKey;
    }

    public string GenerarContraseña()
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

        // Imprimir la clave generada
        byte[] bytesToHex = new byte[] { 0xAF, 0x3D, 0x12, 0x45 };

        return BitConverter.ToString(symmetricKey).Replace("-", "");
    }
}
