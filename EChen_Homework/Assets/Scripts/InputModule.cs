using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputModule 
{
    public abstract bool PressDown<T>(T key) where T : struct;

    public abstract bool PressAndHold<T>(T key) where T : struct;
}
