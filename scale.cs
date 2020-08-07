using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {   GUITexture gui = this.GetComponent<GUITexture>();
        Debug.Log(Screen.width);
        var newInset = new Rect(0, 0, Screen.width, Screen.height);
        gui.pixelInset = newInset;
    }

    
}
