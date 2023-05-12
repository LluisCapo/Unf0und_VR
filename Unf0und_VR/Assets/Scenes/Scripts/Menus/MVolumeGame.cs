
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MVolumeGame : MonoBehaviour
{
    private List<AudioSource> audioSource;
    public Slider volumeSlider;
    private float volumeValue;
    private void Start()
    {
        audioSource = new List<AudioSource>();
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        volumeValue = volumeSlider.value;
        foreach (AudioSource source in sources)
        {
            audioSource.Add(source);
        }
    }
    public void ChangeVolume()
    {
        if(volumeSlider.value != volumeValue)
        {
            volumeValue = volumeSlider.value;
            foreach (AudioSource source in audioSource)
            {
                source.volume = volumeSlider.value;
            }
        }

    }



}
