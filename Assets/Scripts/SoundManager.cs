using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    public static AudioClip click, click2, collect, Walk, drop, list, djed;
    static AudioSource audioSrc;

    void Start(){
        click = Resources.Load<AudioClip>("click");
        click2 = Resources.Load<AudioClip>("click2");
        collect = Resources.Load<AudioClip>("collect");
        Walk = Resources.Load<AudioClip>("walk");
        drop = Resources.Load<AudioClip>("drop");
        list = Resources.Load<AudioClip>("list");
        djed = Resources.Load<AudioClip>("djed");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update(){

    }

    public static void PlaySound(string clip){
        switch (clip){
            case "click":
                audioSrc.PlayOneShot(click);
                break;
            case "click2":
                audioSrc.PlayOneShot(click2);
                break;
            case "collect":
                audioSrc.PlayOneShot(collect);
                break;
            case "drop":
                audioSrc.PlayOneShot(drop);
                break;
            case "list":
                audioSrc.PlayOneShot(list);
                break;
            case "djed":
                audioSrc.PlayOneShot(djed);
                break;
        }
    }
}
