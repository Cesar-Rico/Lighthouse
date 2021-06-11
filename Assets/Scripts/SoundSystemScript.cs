using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystemScript : MonoBehaviour
{
    public static AudioClip sampleSoundtrack;
    public static AudioClip sampleSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        //SOUNDS
        //Los nombres en comillas "" son las pistas de musica en la carpeta resources(sin extension)
        sampleSound = Resources.Load<AudioClip>("Sound_sample");

        //SOUNDTRACKS
        //Los nombres en comillas "" son las pistas de musica en la carpeta resources(sin extension)
        sampleSoundtrack = Resources.Load<AudioClip>("Soundtrack_sample");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
	{
        switch (clip)
		{
            case "Sound_sample":
                audioSrc.PlayOneShot(sampleSound);
                break;
        }
	}

    public static void PlaySoundtrack(string clip2)
    {
        audioSrc.loop = true;
        audioSrc.Stop();
        switch (clip2)
        {
            case "Soundtrack_sample":              
                audioSrc.clip = sampleSoundtrack;   
                break;
        }
        audioSrc.Play();
    }

    public static void Stop()
    {
        audioSrc.Stop();
    }
}
