using UnityEngine;
using System.Collections;

enum State {Convoy, Attack};

public class Enemy : MonoBehaviour
{
    private int _scoreConvoy;
    private int _scoreCharge;
    private int _fireRate;
    private State _state;

	void Start () {
        if(_state == null)
        {
            _state = State.Convoy;
        }
	}

	void Update () {

        switch(_state)
        {
            case State.Convoy:
                break;
            default:
                break;
        }
	}

    void fire()
    {
        //fire bullet
    }
}
