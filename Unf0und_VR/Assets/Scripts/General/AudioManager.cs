using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
}