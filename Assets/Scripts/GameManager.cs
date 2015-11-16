using UnityEngine;
using System.Collections;

enum GameState {Menu, Game};

public class GameManager : MonoBehaviour
{
    private GameState _gameState;
    private GameObject _menu;
    private GameObject _game;

    private void Awake ()
    {
        //GlobalVars.GetInstance ();
        _menu = GameObject.Find("Menu") as GameObject;
        _game = GameObject.Find("Game") as GameObject;
        _game.SetActive(false);
        Debug.Log(_menu);
    }

	private void Start ()
    {
        if(_gameState == null)
        {
            _gameState = GameState.Menu;
        }
	}

	private void Update ()
    {
	}

    private void _changeState(GameState newState)
    {
        _resetState();
        _gameState = newState;

        if(_gameState == GameState.Game)
        {
            _game.SetActive(true);
        }
    }
    private void _resetState()
    {
        _menu.SetActive(false);
        _game.SetActive(false);
    }

    public void ToGame()
    {
        _changeState(GameState.Game);
    }
}
