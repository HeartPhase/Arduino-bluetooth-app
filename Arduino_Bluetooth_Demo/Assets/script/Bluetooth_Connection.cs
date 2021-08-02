using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluetooth_Connection : MonoBehaviour
{
    /// <summary>
    /// ���������豸
    /// </summary>
    public void ScanBluetooth()
    {
        Debug.Log("scaning");
        //Show("��ʼ���������豸...");
        BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, (address, name) =>
        {
            //Show("�������������豸");
            Debug.Log(address + "  " + name);
            //AddPeripheral(name, address);
        },
            (address, name, rssi, advertisingInfo) =>
            {
                //Show("����Ϣ");
                if (advertisingInfo != null)
                    Debug.Log("the bluetooth list is not empty!!!");
                    //BluetoothLEHardwareInterface.Log(string.Format("Device: {0} RSSI: {1} Data Length: {2} Bytes: {3}", name, rssi, advertisingInfo.Length, BytesToString(advertisingInfo)));
                //log address name rssi advertisingInfo
            });

    }

    // Start is called before the first frame update
    void Start()
    {
        ScanBluetooth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
