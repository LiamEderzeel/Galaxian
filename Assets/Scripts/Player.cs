using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float _inputHorizontal;
    private float _speed;
	[SerializeField] private GameObject _bullet;
	private Bullet _bulletScript;

	private void Awake ()
    {
        //_bullet = Resources.Load("bullet");
		_bullet = Instantiate(_bullet, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation) as GameObject;

        _speed = 10f;
		_bulletScript = _bullet.gameObject.GetComponent<Bullet>();
		_bulletScript.Player = gameObject;
	}

	private void Start ()
    {
	}

	private void Update ()
    {
        GetInput();
        transform.Translate(Vector3.right * Time.deltaTime * _inputHorizontal * _speed);
		if(Input.GetKeyDown(KeyCode.Space) != false){
			_bullet.GetComponent<Bullet>().Fired = true;
		}
	}

    private void OnCollisionEnter()
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }

    private void GetInput()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
    }

    private void Die()
    {

    }
}
