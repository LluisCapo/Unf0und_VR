
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVolumeGame : MonoBehaviour
{
    private List<AudioSource> audioSource;
    public Slider volumeSlider;

    private void Start()
    {
        audioSource = new List<AudioSource>();
        AudioSource[] sources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource source in sources)
        {
            audioSource.Add(source);
        }
    }
    private void FixedUpdate()
    {
        foreach (AudioSource source in audioSource)
        {
            source.volume = volumeSlider.value;
        }
    }



}
