using UnityEngine;
using UnityEngine.UI;
using System.Collections;

enum GameState {Menu, Game, GameOver};

public class GameManager : MonoBehaviour
{
    private GameState _gameState;
    private GameObject _menu;
    private GameObject _game;
    private GameObject _gameOver;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private GameObject _player;
    private int _lives = 3;
    private Text _HUDLive;
    private Text _HUDScore;
    private int _score;

    private void Awake ()
    {
        GlobalVars.GetInstance ();
        _menu = GameObject.Find("Menu") as GameObject;
        _game = GameObject.Find("Game") as GameObject;
        _gameOver = GameObject.Find("GameOver") as GameObject;
        _HUDLive = GameObject.Find("Lives").GetComponent<Text>();
        _HUDScore = GameObject.Find("Score").GetComponent<Text>();
        _player.GetComponent<Player>()._iDied += PlayerDied;
        _enemyManager._addScore += AddScore;
        _resetState();
    }

    private void AddScore(int score)
    {
        _score += score;
        _HUDScore.text = _score.ToString();
    }

	private void Start ()
    {
        _changeState(GameState.Menu);
	}

    private void _changeState(GameState newState)
    {
        _resetState();
        _gameState = newState;

        if(_gameState == GameState.Game)
        {
            _game.SetActive(true);
        }
        if(_gameState == GameState.Menu)
        {
            _menu.SetActive(true);
        }
        if(_gameState == GameState.GameOver)
        {
            _gameOver.SetActive(true);
        }
    }

    private void _resetState()
    {
        _menu.SetActive(false);
        _game.SetActive(false);
        _gameOver.SetActive(false);
    }

    public void ToGame()
    {
        _changeState(GameState.Game);
    }

	private void PlayerDied( Player thePlayer )
	{
        if(_lives <= 0)
        {
            _changeState(GameState.GameOver);
        }
        else
        {
            --_lives;
            _HUDLive.text = _lives.ToString();
        }
	}

    private void Reset()
    {
        _score = 0;
        _lives = 3;
    }
}
