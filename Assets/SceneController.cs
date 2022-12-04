using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject _enemy;
    private GameObject _senemy;
    private int x;
    private int z;
    public int count = 5;
    public float baseSpeed = 3.0f;
    public float speed = 3.0f;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < count; i++)
        {
            //_enemy = Instantiate(enemyPrefab) as GameObject;
            //int x = Random.Range(-1, 1) * 20;
            //int z = Random.Range(-1, 1) * 20;
            //_enemy.transform.position = new Vector3(x, 1, z);
            //float angle = Random.Range(0, 360);
            //_enemy.transform.Rotate(0, angle, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            WanderingAI s = _enemy.GetComponent<WanderingAI>();
            if (s != null)
                s.speed = speed;
            x = Random.Range(-1, 1) * 20;
            z = Random.Range(-1, 1) * 20;
            _enemy.transform.position = new Vector3(x, 1, z);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
        if (_senemy == null)
        {
            _senemy = Instantiate(enemyPrefab) as GameObject;
            WanderingAI s = _senemy.GetComponent<WanderingAI>();
            if (s != null)
                s.speed = speed;
            x = Random.Range(-1, 1) * 20;
            z = Random.Range(-1, 1) * 20;
            _senemy.transform.position = new Vector3(x, 1, z);
            float sangle = Random.Range(0, 360);
            _senemy.transform.Rotate(0, sangle, 0);
        }
    }
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}
