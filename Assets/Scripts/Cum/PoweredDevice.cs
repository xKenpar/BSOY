using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredDevice : MonoBehaviour 
{
    public bool m_powered = false;

    virtual public void PowerOn() { }
    virtual public void PowerOff() { }
}
