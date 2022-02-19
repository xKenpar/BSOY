using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSource : MonoBehaviour
{
    [SerializeField] List<PowerManager> m_connectedDevices;

    public bool m_powered = false;

    public void PowerOn(){
        if (!m_powered) {
            m_powered = true;
            UpdateDevices();
        }
    }

    public void PowerOff(){
        if (m_powered) {
            m_powered = false;
            UpdateDevices();
        }
    }

    void UpdateDevices(){
        foreach(PowerManager device in m_connectedDevices){
            device.UpdatePower();
        }
    }

    public void ConnectDevice(PowerManager device){
        m_connectedDevices.Add(device);
    }
}
