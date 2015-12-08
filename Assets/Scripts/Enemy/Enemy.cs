using UnityEngine;
using System.Collections;
public delegate void EnemyDied(Enemy theEnemy);

enum State {Convoy, Attack};

public class Enemy : MonoBehaviour
{
    public event EnemyDied _iDied;
    private int _scoreConvoy = 30;
    private int _scoreCharge = 60;
    private int _fireRate;
    private State _state;
    private int _chance = 15;
    private int _random;
    [SerializeField] private float _offset;
    [SerializeField] private Vector3 _centerPosition;
    private float _timer;

    private void Start ()
    {
        _centerPosition = gameObject.transform.localPosition;
        if(_state == null)
        {
            _state = State.Convoy;
        }
        _timer = Time.time + Random.Range(5,30);
    }

    private void Update ()
    {
        switch(_state)
        {
            case State.Convoy:
                if(_timer < Time.time)
                {
                    _random = Random.Range(1,100);
                    if(_random <= _chance)
                    {
                        Detach();
                    }
                    _timer = Time.time + Random.Range(10,30);
                }
                break;
            case State.Attack:
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            _iDied(gameObject.GetComponent<Enemy>());
            Holding();
           // Detach();
        }
        if(collision.gameObject.name == "Player")
        {
            Holding();
        }
    }

    private void ChangeState(State newState)
    {
        _state = newState;
    }

    private int Side()
    {
        if(Random.Range(1,100) > 50)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    private void fire()
    {
        //fire bullet
    }

    private void Detach()
    {
        ChangeState(State.Attack);
        StartCoroutine(Arc());
        _state = State.Attack;
    }

    private void Return()
    {
        StopCoroutine(Charge());
        gameObject.transform.parent = GlobalVars.Instance.Convoy.transform;
        gameObject.transform.localPosition = new Vector3(_centerPosition.x, GlobalVars.Instance.MainCameraHeight/2+1, _centerPosition.z);
        StartCoroutine(Lerp());
    }

    private void Holding()
    {
        gameObject.transform.parent = GlobalVars.Instance.Convoy.transform;
        ChangeState(State.Convoy);
        gameObject.transform.position = new Vector3(0, 0, -20);
        gameObject.SetActive(false);
    }

    private IEnumerator Arc()
    {
        gameObject.transform.parent = GlobalVars.Instance.Game.transform;

        float iterator = 0;
        Vector3 startPosition = gameObject.transform.position;
        int side = Side();

        while(Mathf.PI/2 >= iterator)
        {
            _offset = Mathf.Sin(iterator * 2);
            gameObject.transform.position = startPosition + new Vector3(0, _offset, 0);
            iterator += Time.deltaTime;
            gameObject.transform.Translate(new Vector3(iterator * side, 0, 0));
            yield return null;
        }
        StartCoroutine(Charge());
        yield break;
    }

    private IEnumerator Charge()
    {
        float iterator = Mathf.PI;
        Vector3 startPosition = gameObject.transform.position;
        int random = Random.Range(2,4);
        int side = Side();

        while(gameObject.transform.position.y > GlobalVars.Instance.MainCameraHeight/2*-1)
        {
            _offset = Mathf.Sin(iterator) * side;
            gameObject.transform.position = startPosition + new Vector3(_offset * random, 0, 0);
            startPosition += new Vector3(0, Time.deltaTime * -1, 0);
            iterator += Time.deltaTime;
            yield return null;
        }
        Return();
        yield break;
    }

    private IEnumerator Lerp()
    {

        Vector3 _startPos;
        Vector3 _endPos;
        float _timeStartedLerping;
        float _timeTakenDuringLerping = 1;
        float _percentageComplete = 0;

        _timeStartedLerping = Time.time;
        _startPos = gameObject.transform.localPosition;
        _endPos = _centerPosition;

        while(_percentageComplete <= 1f)
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            _percentageComplete = timeSinceStarted / _timeTakenDuringLerping;

            gameObject.transform.localPosition = Vector3.Lerp(_startPos, _endPos, _percentageComplete);
            yield return null;
        }
        yield break;
    }


    public int Score
    {
        get
        {
            if(_state == State.Convoy)
            {
                return _scoreConvoy;
            }
            else
            {
                return _scoreCharge;
            }
        }
    }
}
