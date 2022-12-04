using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Text scoreLabel;
    [SerializeField]
    private SettingsPopus settingsPopus;
    [SerializeField]
    private Text lifeLabel;
    private int _score;
    private int _life;
	// Use this for initialization
	void Start () {
        _score = 0;
        _life = 3;
        scoreLabel.text = _score.ToString();
        lifeLabel.text = _life.ToString();
        settingsPopus.Close();
	}
	
	// Update is called once per frame
    public void OnOpenSettings()
    {
        settingsPopus.Open();
    }
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.AddListener(GameEvent.LIFE_CHANGED, OnLifeChanged);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.RemoveListener(GameEvent.LIFE_CHANGED, OnLifeChanged);
    }
    private void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }
    private void OnLifeChanged()
    {
        _life--;
        if (_life == 0)
            _life = 3;
        lifeLabel.text = _life.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isShowing = settingsPopus.gameObject.activeSelf;
            settingsPopus.gameObject.SetActive(!isShowing);
            if (isShowing)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
