using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float _inputHorizontal;
    private float _speed;

	void Awake ()
    {
        _speed = 5f;
	}

	void Start ()
    {
	}

	void Update ()
    {
        GetInput();
        transform.Translate(Vector3.right * Time.deltaTime * _inputHorizontal * _speed);
	}

    void GetInput()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
    }
}
