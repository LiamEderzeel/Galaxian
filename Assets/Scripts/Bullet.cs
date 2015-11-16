using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private bool _fired;
    private Vector3 _startPos;
    private float _speed;
	private bool Fired
	{
		get{ return _fired;}
		set{ _fired= value;}
	}

    void Awake ()
    {
        _startPos = transform.position;
    }

	void Start ()
    {
	}

	void Update ()
    {
        if(_fired)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _speed);
        }

//        if(transform.position > blabla)
//        {
//            Reset();
//        }
	}

//    void OnCollisionEnter(Collision collision)
//    {
//		if(collision.tag == "Enemy")
//        {
//            Reset();
//        }
//    }

    void Reset ()
    {
        _fired = false;
        transform.position = _startPos;
    }
}
