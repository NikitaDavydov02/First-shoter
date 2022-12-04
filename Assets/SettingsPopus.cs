using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopus : MonoBehaviour {

    [SerializeField]
    private AudioClip sound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }
    public void OnSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
        Debug.Log("Speed: " + speed);
    }
    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
        Debug.Log("Must play!");
        Managers.Audio.PlaySound(sound);
    }
    public void OnSoundVolume(float volume)
    {
        Managers.Audio.soundVolume = volume;
    }
    public void OnPlayMusic(int selector)
    {
        Managers.Audio.PlaySound(sound);
        switch (selector)
        {
            case 1:
                Managers.Audio.PlayIntroMusic();
                break;
            case 2:
                Managers.Audio.PlayLevelMusic();
                break;
            default:
                Managers.Audio.StopMusic();
                break;
        }
    }
    public void OnMusicToggle()
    {
        Managers.Audio.misicMute = !Managers.Audio.misicMute;
        Managers.Audio.PlaySound(sound);
    }
    public void OnMusicValue(float valume)
    {
        Managers.Audio.musicVolume = valume;
        Managers.Audio.PlaySound(sound);
    }
}
