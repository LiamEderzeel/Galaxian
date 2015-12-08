using UnityEngine;
using System.Collections;

public class BulletEnemy : MonoBehaviour {
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

        gameObject.transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(gameObject.transform.position.y < _screenHeight / 2*-1)
        {
            Reset();
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
        gameObject.SetActive(false);
        transform.position = _holding;
    }
}
