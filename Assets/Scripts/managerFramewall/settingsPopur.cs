using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsPopur : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    public void OnPlayMusic(int selector)
    {
        Managers.theaudio.playSound(sound);
        switch (selector)
        {
            case 1:
                Managers.theaudio.playIntroMusic();
                break;
            case 2:
                Managers.theaudio.playLevelMusic();
                break;
            default:
                Managers.theaudio.stopMusic();
                break;
        }
    }
    public void OnSoundToggle()
    {
        Managers.theaudio.soundMute = !Managers.theaudio.soundMute;
        Managers.theaudio.playSound(sound);
    }
    public void OnMusicToggle()
    {
        Managers.theaudio.musicMute = !Managers.theaudio.musicMute;
        Managers.theaudio.playSound(sound);
    }
    public void OnSoundValue(float volume)
    {
        Managers.theaudio.soundVolume = volume;
    }
    public void OnMusicValue(float volume)
    {
        Managers.theaudio.musicVolume = volume;
    }
}
