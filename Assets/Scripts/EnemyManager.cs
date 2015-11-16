using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {
    private List<Enemy> _convoy = new List<Enemy>();
    private List<Enemy> _dead = new List<Enemy>();

	private float _screenHeigth;
	private float _screenWidth;
	private float _convoyWidth;
	private float _convoyWidthInterfall;
	private float _widthPrecentage = 0.6f;
	private int _enemyAmount = 10;
	[SerializeField] private GameObject _enemy;
	private float _mainCameraHeight;
	private float _mainCameraWidth;

	private void Awake ()
	{
		_mainCameraHeight = 2f * Camera.main.orthographicSize;
		_mainCameraWidth = _mainCameraHeight * Camera.main.aspect;
		
		_screenHeigth = _mainCameraHeight;
		_screenWidth = _mainCameraWidth;
		_convoyWidth = _screenWidth * _widthPrecentage;
		
		_convoyWidthInterfall = _convoyWidth  / 9;
	}
	
	private void Start ()
	{
		GenerateEnemys();
	}

	private void Update ()
	{
	}

	private void GenerateEnemys() {
		float _x = _convoyWidth / 2 * -1;
		float _y = _convoyWidth / 2;
		for(int i = 0; i < _enemyAmount; ++i)
		{
			GameObject _newEnemy = Instantiate(_enemy, new Vector3(_x, _y, 0), this.transform.rotation) as GameObject;
			_newEnemy.name = "Enemy" + i;
			_x += _convoyWidthInterfall;
		}
		_x = _convoyWidth / 2 * -1;
		_y += _convoyWidthInterfall;
		for(int i = 0; i < _enemyAmount; ++i)
		{
			GameObject _newEnemy = Instantiate(_enemy, new Vector3(_x, _y, 0), this.transform.rotation) as GameObject;
			_newEnemy.name = "Enemy" + i;
			_x += _convoyWidthInterfall;
		}
		_x = _convoyWidth / 2 * -1;
		_y += _convoyWidthInterfall;
		for(int i = 0; i < _enemyAmount; ++i)
		{
			GameObject _newEnemy = Instantiate(_enemy, new Vector3(_x, _y, 0), this.transform.rotation) as GameObject;
			_newEnemy.name = "Enemy" + i;
			_x += _convoyWidthInterfall;
		}
		_x = _convoyWidth / 2 * -1;
		_y += _convoyWidthInterfall;
		for(int i = 0; i < _enemyAmount; ++i)
		{
			GameObject _newEnemy = Instantiate(_enemy, new Vector3(_x, _y, 0), this.transform.rotation) as GameObject;
			_newEnemy.name = "Enemy" + i;
			_x += _convoyWidthInterfall;
		}
		_x = _convoyWidth / 2 * -1;
		_y += _convoyWidthInterfall;
		for(int i = 0; i < _enemyAmount; ++i)
		{
			GameObject _newEnemy = Instantiate(_enemy, new Vector3(_x, _y, 0), this.transform.rotation) as GameObject;
			_newEnemy.name = "Enemy" + i;
			_x += _convoyWidthInterfall;
		}
	}
}
