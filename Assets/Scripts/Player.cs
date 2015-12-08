using UnityEngine;
using System.Collections;
public delegate void PlayerDied(Player player);

public class Player : MonoBehaviour {
    [SerializeField] private float _respawnTime;
    private Vector3 _playPos;
    private float _inputHorizontal;
    private float _speed;
    [SerializeField] private GameObject _bullet;
    private Bullet _bulletScript;
    public event PlayerDied _iDied;

    private void Awake ()
    {
        _playPos = gameObject.transform.position;
        _bullet = Instantiate(_bullet, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation) as GameObject;
        _bullet.transform.parent = gameObject.transform;
        _speed = 10f;
        _bulletScript = _bullet.gameObject.GetComponent<Bullet>();
        _bulletScript.Player = gameObject;
    }

    private void Update ()
    {
        GetInput();
        transform.Translate(Vector3.right * Time.deltaTime * _inputHorizontal * _speed);
        if(Input.GetKeyDown(KeyCode.Space) != false){
            _bullet.GetComponent<Bullet>().Fired = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(Die());
        }
    }

    private void GetInput()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
    }

    private IEnumerator  Die()
    {
        _iDied(gameObject.GetComponent<Player>());
        gameObject.transform.position = new Vector3(0, 0, -20);
        yield return new WaitForSeconds(_respawnTime);
        gameObject.transform.position = _playPos;

    }
}
