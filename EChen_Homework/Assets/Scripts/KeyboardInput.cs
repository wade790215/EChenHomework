using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : InputModule
{    
    //TODO�@�۩w�q����??
    public override bool PressAndHold<T>(T key)
    {       
        return true;
    }

    public override bool PressDown<T>(T key)
    {
        return true;
    }
}
