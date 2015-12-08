using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

    public static GlobalVars Instance;
    public static GlobalVars GetInstance()
    {
        if(Instance == null)
        {
            GameObject g = new GameObject("__GlobalVars");
            Instance = g.AddComponent<GlobalVars>();
        }
        return Instance;
    }

    private Camera _mainCamera = Camera.main;
    private float _mainCameraHeight;
    private float _mainCameraWidth;
    private GameObject _game;
    private GameObject _convoy;
    private GameObject _player;

	private void Awake ()
    {
        _mainCameraHeight = 2f * _mainCamera.orthographicSize;
        _mainCameraWidth = _mainCameraHeight * _mainCamera.aspect;
        _game = GameObject.Find("Game");
        _convoy = GameObject.Find("Convoy");
        _player = GameObject.Find("Player");
	}

    public Camera MainCamera
    {
        get { return _mainCamera; }
    }

    public float MainCameraHeight
    {
        get { return _mainCameraHeight; }
    }

    public float MainCameraWidth
    {
        get { return _mainCameraWidth; }
    }

    public GameObject Game
    {
        get { return _game; }
    }

    public GameObject Convoy
    {
        get { return _convoy; }
    }

    public GameObject Player
     {
         get { return _player; }
     }
}
