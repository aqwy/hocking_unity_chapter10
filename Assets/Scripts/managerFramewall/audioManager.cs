using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour, IGameManager
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource music1source;
    [SerializeField] private string introBGMusic;
    [SerializeField] private string levelBGMusic;
    public managerStatus status { get; private set; }
    private NetworkService network;
    public void playIntroMusic()
    {
        playMusic(Resources.Load("Music/" + introBGMusic) as AudioClip);
    }
    public void playLevelMusic()
    {
        playMusic(Resources.Load("Music/" + levelBGMusic) as AudioClip);
    }
    private void playMusic(AudioClip clip)
    {
        music1source.clip = clip;
        music1source.Play();
    }
    public void stopMusic()
    {
        music1source.Stop();
    }
    public void playSound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }
    public float soundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }
    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }
    public void Startup(NetworkService service)
    {
        Debug.Log("audio manager starting...");
        network = service;
        soundVolume = 1f;
        status = managerStatus.Started;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
