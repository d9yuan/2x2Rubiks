using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{

    public Transform two_by_two;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(two_by_two);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
