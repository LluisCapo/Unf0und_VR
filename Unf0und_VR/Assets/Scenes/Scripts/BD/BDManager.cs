using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;

public class BDManager : MonoBehaviour
{
    public BDInfoManager CurrentGameInfo;
    public BDInfoManager InfoFromTheServer;

    BDInfoManager _BDInfo;

    public void BDStart()
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
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine($"{CurrentGameInfo.nick[0]}/{CurrentGameInfo.email[0]}/{CurrentGameInfo.score[0]}");
            sw.Flush();

            _BDInfo = null;

            while ((data = sr.ReadLine()) != null)
                _BDInfo = JsonConvert.DeserializeObject<BDInfoManager>(data);

            InfoFromTheServer.nick = _BDInfo.nick;
            InfoFromTheServer.email = _BDInfo.email;
            InfoFromTheServer.score = _BDInfo.score;

            reciver.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }

    /*private void BdInsetSelect(String _nick, String _email, String _score)
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
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine($"{_nick}/{_email}/{_score}");
            sw.Flush();

            _BDInfo = null;

            while ((data = sr.ReadLine()) != null)
                _BDInfo = JsonConvert.DeserializeObject<BDInfoManager>(data);

            currentBDInfo.nick = _BDInfo.nick;
            currentBDInfo.email = _BDInfo.email;
            currentBDInfo.score = _BDInfo.score;

            reciver.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }*/

}
