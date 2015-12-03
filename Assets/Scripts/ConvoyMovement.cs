using UnityEngine;
using System.Collections;

public class ConvoyMovement : MonoBehaviour {
    private bool _left;

    void Start ()
    {

    }

    void Update ()
    {
        if(transform.position.x > 1)
        {
            _left = true;
        }
        if(transform.position.x < -1)
        {
            _left = false;
        }

        if(_left)
        {
            transform.Translate(new Vector3(-0.01f,0,0));
        }
        else
        {
            transform.Translate(new Vector3(0.01f,0,0));
        }
    }
}
