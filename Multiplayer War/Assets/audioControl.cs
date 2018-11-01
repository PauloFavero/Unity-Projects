using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioControl : MonoBehaviour {


    public Slider masterSlider;
    public AudioSource[] masterAudio;
    public Slider effectsSlider;
    public AudioSource[] effectsAudio;
    public Slider musicSlider;
    public AudioSource[] musicAudio;

    public void Start()
    {
        masterSlider.value = 0.4f;
        effectsSlider.value = 0.4f;
        musicSlider.value = 0.4f;
        //Adds a listener to the main slider and invokes a method when the value changes.
        masterSlider.onValueChanged.AddListener(delegate { ValueMasterChangeCheck(); });
        //Adds a listener to the main slider and invokes a method when the value changes.
        effectsSlider.onValueChanged.AddListener(delegate { ValueEffectsChangeCheck(); });
        //Adds a listener to the main slider and invokes a method when the value changes.
        musicSlider.onValueChanged.AddListener(delegate { ValueMusicChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueMasterChangeCheck()
    {
        Debug.Log(masterSlider.value);
        for (int i = 0; i < masterAudio.Length; i++)
        {
            masterAudio[i].volume = masterSlider.value;
        }
    }
    public void ValueEffectsChangeCheck()
    {
        Debug.Log(effectsSlider.value);
        for (int i = 0; i < effectsAudio.Length; i++)
        {
            effectsAudio[i].volume = effectsSlider.value;
        }
    }
    public void ValueMusicChangeCheck()
    {
        Debug.Log(musicSlider.value);
        for (int i = 0; i < musicAudio.Length; i++)
        {
            musicAudio[i].volume = musicSlider.value;
        }
    }
}
