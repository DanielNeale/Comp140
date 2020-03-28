using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Collections;

public class ArduinoComm : MonoBehaviour
{
    [SerializeField]
    private int commPort = 0;
    private SerialPort serial = null;


    void Start()
    {
        ConnectToSerial();
    }


    void ConnectToSerial()
    {
        Debug.Log("Attempting Serial: " + commPort);

        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();

        Debug.Log("Connected");
    }


    void Update()
    {
        WriteToArduino("R");
        string output = ReadFromArduino(50);
        
        if (output != null)
        {
            GetComponent<RailController>().setRails(output);
        }
    }


    void WriteToArduino(string message)
    {
        serial.WriteLine(message);
        serial.BaseStream.Flush();
    }


    public string ReadFromArduino(int timeout = 0)
    {
        serial.ReadTimeout = timeout;
        try
        {
            return serial.ReadLine();
        }
        catch (TimeoutException e)
        {
            return null;
        }
    }


    void OnDestroy()
    {
        Debug.Log("Exiting");
        serial.Close();
    }
}
