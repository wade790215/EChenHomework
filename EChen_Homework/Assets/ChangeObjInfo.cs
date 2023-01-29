using UnityEngine;
using System;

public class ChangeObjInfo : MonoBehaviour
{    
    private Texture texture;
    public Texture Texture
    {
        get { return texture; }
        set { texture = value; }
    }
    public ColorPoint colorPoint;
}

[Serializable]
public class ColorPoint
{
    public Color Color;
    public Vector3 Position; 
}
