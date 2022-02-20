using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    [SerializeField] PowerSource[] Sources;
    [SerializeField] PoweredDevice[] Devices;
    [SerializeField] bool Mode = false; //TODO enum, 0 = And 1 = Or
    bool m_powered = false;
    void Start(){
        if (Sources.Length == 0){
            Debug.LogError("No Source In PowerDevice!");
        }else{
            foreach (PowerSource source in Sources){
                source.ConnectDevice(this);
            }
        }

        UpdatePower();
    }

    public void UpdatePower(){
        bool temp = Mode ? false : true;
        foreach (PowerSource source in Sources){
            if (Mode) temp = temp || source.m_powered;
            else temp = temp && source.m_powered;
        }

        if (temp && !m_powered){
            m_powered = true;
            PowerOn();
        }else if(!temp && m_powered){
            m_powered = false;
            PowerOff();
        }
    }

    void PowerOn(){
        foreach (PoweredDevice device in Devices){
            if(!device.m_powered) device.PowerOn();
        }
    }

    void PowerOff() {
        foreach (PoweredDevice device in Devices) {
            if (device.m_powered) device.PowerOff();
        }
    }
}
