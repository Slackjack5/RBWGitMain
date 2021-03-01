using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    public AudioMixerGroup mixerGroupEffects;
    public AudioMixerGroup mixerGroupMusic;
    public AudioMixer musicMixer;
    public float fadeSpeed = .006f;
    public bool fadeWater = false;


    //Fades
    public bool fadeIdleOcean = false;
    public bool fadeReturn = false;
    private bool tutorialMusicStopped=false;
    private bool endReached = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
            if (s.name== "IdleSong")
            {
            s.source.outputAudioMixerGroup = mixerGroupMusic;
            }
            else if (s.name == "Music-RunFastShootAliens")
            {
            s.source.outputAudioMixerGroup = mixerGroupMusic;
            }
            else
            {
               // s.source.outputAudioMixerGroup = mixerGroupEffects; 
            }
        }

       
        
    }

    private void Start()
    {

        //Play Music
        instance.Play("IdleSong");
        instance.Play("UnderwaterSong");
        instance.Play("RBWCreepy");
    }

    private void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(fadeIdleOcean)
        {
            FadeDown("IdleSong");
            FadeUp("UnderwaterSong");
        }

        if(fadeReturn)
        {
            Debug.Log("fading sound");
            FadeReturn("IdleSong");
            //Add other songs
            FadeSilent("UnderwaterSong");
        }

        if(fadeWater)
        {
            FadeSilent("Water");
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    // Update is called once per frame
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    // Update is called once per frame
    public void PlaySound(string name, float pitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = pitch;
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.volume > 0)
        {
            s.source.volume -= .003f;
        }
        else
        {
            s.source.Stop();
        }
    }

    public void FadeDown(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.volume > 0.01)
        {
            s.source.volume -= fadeSpeed;
        }

    }

    public void FadeSilent(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.volume > 0)
        {
            s.source.volume -= fadeSpeed;
        }

    }


    public void FadeUp(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.volume < 0.3)
        {
            s.source.volume += fadeSpeed;
        }

    }

    public void SoundReset(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.volume < 0.3)
        {
            s.source.volume = 0.3f;
        }

    }

    public void QuickStop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 0f;


    }

    public void FadeReturn(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.volume < 0.3)
        {
            s.source.volume += fadeSpeed;
        }
        else
        {
            fadeReturn = false;
        }

    }


    public void lowPassEnable()
    {
        musicMixer.SetFloat("lowPassLevel", 300);
        musicMixer.SetFloat("lowPassLevel2", 10000);
    }
    public void lowPassDisable()
    {
        musicMixer.SetFloat("lowPassLevel", 22000);
        musicMixer.SetFloat("lowPassLevel2", 22000);
    }

    public void SetVolume(float volume)
    {
        musicMixer.SetFloat("volume", volume);
    }
}
