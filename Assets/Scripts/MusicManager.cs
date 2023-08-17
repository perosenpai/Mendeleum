using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour{
    [SerializeField] Slider slider;

    void Start(){
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
    }

    public void ChangeVolume(){
        AudioListener.volume = slider.value;
        Save();
    }

    private void Load(){
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    void Save(){
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }
}
