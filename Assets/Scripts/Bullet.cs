﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private bool _fired;
	private GameObject _player;
    private Vector3 _startPos;
    private float _speed = 5f;
	private float _screenHeight;

    private void Awake ()
    {
        _startPos = transform.position;
    }

	private void Start ()
    {
		_screenHeight = GlobalVars.Instance.MainCameraHeight;
	}

	private void Update ()
    {

        if(_fired)
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * _speed);
            gameObject.transform.parent = GlobalVars.Instance.Game.transform;
        }

		if(gameObject.transform.position.y > _screenHeight/2+1)
		{
			Reset();
		}

		if(!_fired)
		{
			gameObject.transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
		}
	}


	private void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.tag == "Enemy")
        {
            Reset();
        }
    }

    private void Reset ()
    {
        gameObject.transform.parent = GlobalVars.Instance.Player.transform;
        _fired = false;
        transform.position = _startPos;
    }

	public bool Fired
	{
		get{ return _fired;}
		set{ _fired = value;}
	}

	public GameObject Player
	{
		//get{ return _player;}
		set{ _player = value;}
	}
}
