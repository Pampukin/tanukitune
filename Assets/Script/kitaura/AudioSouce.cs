using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSouce : MonoBehaviour
{
    public static AudioSource[] audioSources;
    public static AudioSource hitsound; //ヒットした時の音
    public static  AudioSource prosound;
    public static AudioSource dimsound;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        prosound = audioSources[0]; //1番目の音を呼ぶ
        hitsound = audioSources[1]; //2番目の音を呼ぶ
        dimsound = audioSources[2]; //3番目の音を呼ぶ
    }

    // Update is called once per frame
    void Update()
    {

    }
    //撃退音を鳴らす
    public static void play0()
    {
        hitsound.PlayOneShot(hitsound.clip);
    }

    //進行音を鳴らす
    public static void play1()
    {
        prosound.PlayOneShot(prosound.clip); 
    }

    //退行音を鳴らす
    public static void play2()
    {
        dimsound.PlayOneShot(dimsound.clip);
    }

}
