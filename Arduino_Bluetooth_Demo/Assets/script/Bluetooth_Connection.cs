using System;
using UnityEngine;
using UnityEngine.UI;
using ArduinoBluetoothAPI;
using UnityEngine.SceneManagement;

public class Bluetooth_Connection : MonoBehaviour
{
    BluetoothHelper m_helper;
    public InputField device_name;
    public Button subscribed;
    public Button disconnect;
    public Button nextpage;
    public Text state;

    // Start is called before the first frame update
    void Start()
    {
        
        m_helper = BluetoothHelper.GetInstance();
        m_helper.OnConnected += OnConnected;
        m_helper.OnConnectionFailed += OnConnectionFailed;
        m_helper.OnDataReceived += OnDataReceived;
        m_helper.setFixedLengthBasedStream(1); //data is received byte by byte
        device_name.text = null;
    }

    public void subscribe_function()
    {
        if(!string.IsNullOrEmpty(device_name.text))
        {
            m_helper.setDeviceName(device_name.text);
            m_helper.Connect();
        }
    }

    void OnConnected(BluetoothHelper helper)
    {
        m_helper.StartListening();
        subscribed.gameObject.SetActive(false);
        disconnect.gameObject.SetActive(true);
        nextpage.gameObject.SetActive(true);
        state.text = "connected to "+device_name.text;
    }

    void OnConnectionFailed(BluetoothHelper helper)
    {
        state.text="Failed to connect";
        subscribed.gameObject.SetActive(true);
        disconnect.gameObject.SetActive(false);
        nextpage.gameObject.SetActive(false);
    }

    void OnDataReceived(BluetoothHelper helper)
    {
        string msg = helper.Read();

        
    }

    public void disconnect_function() {
        state.text = "Disconnect";
        m_helper.Disconnect();
        subscribed.gameObject.SetActive(true);
        disconnect.gameObject.SetActive(false);
        nextpage.gameObject.SetActive(false);
    }

    public void nextpage_function() {
        if (m_helper.isConnected()) {SceneManager.LoadScene("Control_scene");}
    }

    // Update is called once per frame
    void Update()
    {

    }
}