using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

[Serializable]
public class PooledAudios
{
	public string Name;
	public AudioClip soundToPool;
}


public class AudioManager : MonoBehaviour
{

	private static AudioManager _instance = null;
	public static AudioManager Instance => _instance;

	AudioSource _audio;

	[SerializeField]
	private List<PooledAudios> pooledSounds = new List<PooledAudios>();

	[SerializeField]
	private Dictionary<string, AudioClip> _items = new Dictionary<string, AudioClip>();

	void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}

		for (int i = 0; i < pooledSounds.Count; i++)
		{
			PooledAudios l = pooledSounds[i];
			_items.Add(l.Name, l.soundToPool);
		}
		_audio = GetComponent<AudioSource>();
	}

	public void PlaySound(string _name)
    {
		_audio.PlayOneShot(_items[_name]);
    }

	public void PlaySoundOnPosition(string _name, Vector3 _position)
    {
		AudioSource.PlayClipAtPoint(_items[_name], _position);
    }

	public void PlaySoundAttachedAtPosition(string _name, GameObject _go)
	{
		var tempGO = new GameObject("TempAudio"); // create the temp object
		tempGO.transform.position = _go.transform.position; // set its position
		var aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
		aSource.clip = _items[_name]; // define the clip
		tempGO.transform.parent = _go.transform;					 // set other aSource properties here, if desired
		aSource.Play(); // start the sound
		Destroy(tempGO, _items[_name].length); // destroy object after clip duration
		//return aSource; // return the AudioSource reference
	}
}