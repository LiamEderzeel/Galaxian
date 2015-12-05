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
    private int _chance = 2;
    [SerializeField] private float _offset;
    private Vector3 _centerPosition;
    private float _timer;
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

    private void Start ()
    {
        _centerPosition = gameObject.transform.position;
        if(_state == null)
        {
            _state = State.Convoy;
        }
    }

    private void Update ()
    {
        switch(_state)
        {
            case State.Convoy:
                int random = Random.Range(1,100);
                if(random < _chance )
                {
                    Detach();
                }
                break;
            case State.Attack:
                gameObject.transform.Translate(new Vector3(0, -0.05f, 0));
                if(gameObject.transform.position.y > GlobalVars.Instance.MainCameraHeight)
                {
                    Debug.Log("test");
                }
                break;
            default:
                break;
        }
    }

    private void fire()
    {
        //fire bullet
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            _iDied(gameObject.GetComponent<Enemy>());
            Reset();
           // Detach();
        }
        if(collision.gameObject.name == "Player")
        {
            Reset();
        }
    }

    private void Detach()
    {
        ChangeState(State.Attack);
        StartCoroutine(Arc());
        _state = State.Attack;
    }

    private void Reset()
    {
        ChangeState(State.Convoy);
        gameObject.transform.position = new Vector3(0, 0, -20);
        gameObject.SetActive(false);
    }

    private IEnumerator Arc()
    {
        gameObject.transform.parent = GlobalVars.Instance.Game.transform;

        float iterator = 0;
        Vector3 startPosition = gameObject.transform.position;

        while(Mathf.PI/2 >= iterator)
        {
            _offset = Mathf.Sin(iterator * 2);
            gameObject.transform.position = startPosition + new Vector3(0, _offset, 0);
            iterator += Time.deltaTime;
            gameObject.transform.Translate(new Vector3(iterator, 0, 0));
            yield return null;
        }
    }

    private void ChangeState(State newState)
    {
        _state = newState;
    }
}
