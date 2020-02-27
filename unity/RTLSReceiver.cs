using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThreeByte.Network;
using System;
using UnityEngine.UI;
using System.Text;

using RTLSProtocol;

public class RTLSReceiver : MonoBehaviour
{
    //ThreeByte.Network ask olaaf
    SimpleUDPListener link;

    public int port = 1234;
    public bool acceptMulticast = false;

    Vector3 position = Vector3.zero;
    void Start()
    {
        List<string> IPs=( IPManager.GetAllIPs(IPManager.ADDRESSFAM.IPv4, true));

        foreach (string ip in IPs)
            Debug.Log(ip);

        link = new SimpleUDPListener(port, acceptMulticast);
        link.DataReceived += Link_DataReceived;

       
    }

    private void Link_DataReceived(object sender, EventArgs e)
    {
        var response = sender as Byte[];

        //Debug.Log(response);

        parseAndPrintSerializedBytes( response);
        
    }

    private void parseAndPrintSerializedBytes(byte[] serialized)
    {
        TrackableFrame frame = TrackableFrame.Parser.ParseFrom(serialized);

        //Debug.Log("Frame ID:"+ frame.FrameID);

        foreach (Trackable trackable in frame.Trackables)
        {
            try
            {
                position.x = (float)trackable.Position.X;
                position.y = (float)trackable.Position.Y;
                position.z = (float)trackable.Position.Z;

                //Debug.Log("Name: " + trackable.Name + " x: " + trackable.Position.X + " y: " + trackable.Position.Y + " z: " + trackable.Position.Z);

            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
               
        }
            
        
    }

    void Update()
    {
        transform.localPosition = position;
    }

void OnApplicationQuit()
    {
        link.Close();
    }
}
