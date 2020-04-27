using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoComm : MonoBehaviour
{
    [SerializeField]
    private int commPort = 0;
    private SerialPort serial = null;


    void Start()
    {
        ConnectToSerial();
    }


    /// <summary>
    /// Attempts to connect to the arduino
    /// </summary>
    void ConnectToSerial()
    {
        Debug.Log("Attempting Serial: " + commPort);

        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();

        Debug.Log("Connected");
    }


    /// <summary>
    /// Asks arduino to send the state of the three switches
    /// </summary>
    void Update()
    {
        WriteToArduino("R");
        string output = ReadFromArduino(50);
        
        if (output != null)
        {
            GetComponent<RailController>().setRails(output);
        }
    }


    /// <summary>
    /// Writes a message to arduino
    /// </summary>
    /// <param name="message"></param>
    /// The message sent to the arduino
    void WriteToArduino(string message)
    {
        serial.WriteLine(message);
        serial.BaseStream.Flush();
    }


    /// <summary>
    /// Reads the latest message from the arduino
    /// </summary>
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


    /// <summary>
    /// Closes the connection to the arduino when the game stops
    /// </summary>
    void OnDestroy()
    {
        Debug.Log("Exiting");
        serial.Close();
    }
}
