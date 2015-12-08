using UnityEngine;
using System.Collections;

public class BulletEnemy : MonoBehaviour {
    private bool _fired;
	private GameObject _player;
    private Vector3 _holding = new Vector3(0, -20, 0);
    private float _speed = 5f;
	private float _screenHeight;

    private void Awake ()
    {
        gameObject.transform.position = _holding;
    }

	private void Start ()
    {
		_screenHeight = GlobalVars.Instance.MainCameraHeight;
	}

	private void Update ()
    {

        if(_fired)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime * _speed);
        }

		if(gameObject.transform.position.y < _screenHeight / 2*-1)
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
		if(collision.gameObject.tag == "Player")
        {
            Reset();
        }
    }

    private void Reset ()
    {
        _fired = false;
        transform.position = _holding;
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
