using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour {

    [SerializeField] private List<GameObject> _bullets = new List<GameObject>();
    [SerializeField] private GameObject _bullet;

    private void Start()
    {
        for(int i =0; i < 8; ++i)
        {
            CreateNew();
        }
    }

    public GameObject Spawn()
    {
        for (int i = 0; i < _bullets.Count; ++i)
        {
            if ( !_bullets[i].activeInHierarchy )
            {
                _bullets[i].SetActive(true);
                return _bullets[i];
            }
        }

        GameObject obj = CreateNew ();
        obj.SetActive (true);
        return obj;
    }

    private GameObject CreateNew()
    {
        GameObject obj = GameObject.Instantiate( _bullet ) as GameObject;
        _bullets.Add ( obj );
        obj.transform.parent = GlobalVars.Instance.Game.transform;
        obj.SetActive( false );
        return obj;
    }
}
