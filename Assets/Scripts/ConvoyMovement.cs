using UnityEngine;
using System.Collections;

public class ConvoyMovement : MonoBehaviour {
    private bool _left;
    private float _speed = 1;

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
            transform.Translate(new Vector3(Time.deltaTime * _speed * -1,0,0));
        }
        else
        {
            transform.Translate(new Vector3(Time.deltaTime * _speed,0,0));
        }
    }
}
