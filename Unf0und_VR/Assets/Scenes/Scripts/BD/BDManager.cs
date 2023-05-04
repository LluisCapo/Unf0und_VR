using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

[Serializable]
public class JSONInfo
{
    public string[] nick;
    public string[] score;
}

public class BDManager : MonoBehaviour
{
    public void BDStart(byte[] msg)
    {
        String data;
        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint remoteEP = new IPEndPoint(ipAddress, 9000);
        Socket reciver = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            reciver.Connect(remoteEP);
            NetworkStream ns = new NetworkStream(reciver);
            StreamReader sr = new StreamReader(ns);
            ns.Write(msg, 0, msg.Length);

            JSONInfo info = new JSONInfo();

            while ((data = sr.ReadLine()) != null)
                info = JsonConvert.DeserializeObject<JSONInfo>(data);

            Debug.Log(info.nick[0]);

            reciver.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

}
