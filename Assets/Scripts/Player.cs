using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float _inputHorizontal;
    private float _speed;
	[SerializeField] private GameObject _bullet;
	private Bullet _bulletScript;

	void Awake ()
    {
//        _bullet = Resources.Load("bullet");
		_bullet = Instantiate(_bullet, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation) as GameObject;
        _speed = 5f;
		_bulletScript = _bullet.gameObject.GetComponents<Bullet>();

	}

	void Start ()
    {
		Debug.Log (_bullet);

	}

	void Update ()
    {
        GetInput();
        transform.Translate(Vector3.right * Time.deltaTime * _inputHorizontal * _speed);
		if(Input.GetButtonDown("Fire1") != null){
			//_bullet.GetComponents<Bullet>().Fired = true;
		}
	}

    void GetInput()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
    }
}
