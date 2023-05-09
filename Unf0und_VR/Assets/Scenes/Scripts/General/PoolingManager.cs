using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PooledItems
{
				public string Name;
				public GameObject objectToPool;
				public int Amount;
}


public class PoolingManager : MonoBehaviour
{

    private static PoolingManager _instance = null;
    public static PoolingManager Instance => _instance;


				[SerializeField]
				private List<PooledItems> pooledLists = new List<PooledItems>();

				[SerializeField]
				private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

				void Awake()
				{
					if (_instance == null)
					{
						_instance = this;
						DontDestroyOnLoad(gameObject); //Activar esto si se utiliza ESTE pooling en otras escenas
					}
		//else
			//Destroy(this);

					for(int i = 0; i < pooledLists.Count; i++)
					{
						PooledItems l = pooledLists[i];
						_items.Add(l.Name, new List<GameObject>());

						for(int p = 0; p < l.Amount; p++)
						{
							GameObject tmp;
							tmp = Instantiate(l.objectToPool);
							tmp.SetActive(false);
							_items[l.Name].Add(tmp);
						}
					}
	}

				public GameObject GetPooledObject(string name)
				{
					foreach (GameObject g in _items[name])
						if (!g.activeInHierarchy)
							return g;

					return null;
				}

	public List<GameObject> GetActiveObject(string name)
    {
		List<GameObject> list = new List<GameObject>();
		foreach (GameObject g in _items[name])
			if (g.activeInHierarchy)
				list.Add(g);

		return list;
    }

	public void SetActiveFalseAll(string name)
    {
		List<GameObject> tmp = _items[name];

		for (int i = 0; i < tmp.Count; i++)
			tmp[i].SetActive(false);

		_instance = null;
	}

	public void SetMoreThanOneFalse(string name1, string name2)
    {
		List<GameObject> tmp1 = _items[name1], tmp2 = _items[name2];

		for (int i = 0; i < tmp1.Count; i++)
			tmp1[i].SetActive(false);

		for (int i = 0; i < tmp2.Count; i++)
			tmp2[i].SetActive(false);

		//_instance = null;
	}
}
