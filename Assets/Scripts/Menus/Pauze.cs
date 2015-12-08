using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pauze : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Text _text;
    private int _score;

	void Update ()
    {
        _score = _gameManager.Score;
        _text.text = _score.ToString();
	}
}
