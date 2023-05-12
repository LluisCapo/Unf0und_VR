using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Assertions.Must;
using Unity.Mathematics;

[Serializable]
public class PlatformParts
{
    public string name;
    public GameObject hip;
}

public class PlatformActing : MonoBehaviour
{
    [SerializeField]
    public List<PlatformParts> _Platform = new List<PlatformParts>();
    [SerializeField]
    public Dictionary<string, List<GameObject>> _hipsPlatform = new Dictionary<string, List<GameObject>>();

    //private float _actualTime = 0;

    private void Awake()
    {
        for (int i = 0; i < _Platform.Count; i++)
        {
            PlatformParts l = _Platform[i];
            _hipsPlatform.Add(l.name, new List<GameObject>());
            _hipsPlatform[l.name].Add(l.hip);
        }
    }




    public void Rotate(float _distance, float _speed, string _name, GameObject gm)
    {
        float _time = _distance / _speed;
        //_distance *= 10000;
        //_time *= 10000;
        float _rotation = _speed * _time;
        //GameObject SelectedPart = null;
        //foreach (GameObject g in _hipsPlatform[_name])
        //        SelectedPart = gm;
        char[] nameChar = _name.ToCharArray();
        string axis = nameChar[nameChar.Length - 1].ToString().ToLower();
        //UnityEngine.Random.Range(20, 360)
        StartCoroutine(RotateObject(gm, _time, _speed, _rotation * (_distance *100), axis));

    }
    private IEnumerator RotateObject(GameObject obj, float duration, float speed, float distance, string direction)
    {
        //float angle = 0;
        float timer = 0;
        float directionMultiplier = 1f;

        Quaternion startRotation = obj.transform.rotation;
        Quaternion endRotation;
        switch (direction)
        {
            case "x":
                endRotation = Quaternion.Euler(distance, 0f, 0f) * startRotation;
                break;
            case "y":
                endRotation = Quaternion.Euler(0f, distance, 0f) * startRotation;
                break;
            case "z":
                endRotation = Quaternion.Euler(0f, 0f, distance) * startRotation;
                break;
            default:
                Debug.LogError("Invalid direction parameter");
                yield break;
        }

        

        while (timer < duration)
        {
            float t = timer / duration;
            float angleDelta = speed * Time.deltaTime * directionMultiplier;
            Quaternion currentRotation = Quaternion.Lerp(startRotation, endRotation, t);
            obj.transform.rotation = currentRotation;
            timer += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = endRotation;
    }
    //private IEnumerator RotatePart(GameObject _part, float _time, float _distance, string name)
    //{
    //    if(!_part)
    //    {
    //        yield return null;
    //    }
    //    char[] nameChar = name.ToCharArray();
    //    char axis = nameChar[nameChar.Length - 1];
    //    _actualTime = 0;
    //    _distance *= 10000;
    //    _time *= 10000;
    //    Debug.Log("TIME: " + _time + "    DISTANCE: " + _distance);
    //    //bool _finished = false;
    //    while (_actualTime < _time)
    //    {
    //        _actualTime += Time.deltaTime;
    //        switch (axis)
    //        {
    //            case 'X':
    //                // _part.transform.rotation.x + _distance
    //                _part.transform.Rotate(Mathf.Lerp(_part.transform.rotation.x,360, (_time - 0) / (1 - 0)), 0, 0);
    //                Debug.Log("Rotating" + axis);
    //                break;
    //            case 'Z':
    //                // _part.transform.rotation.y + _distance
    //                _part.transform.Rotate(0, 0, Mathf.Lerp(_part.transform.rotation.y,360, (_time - 0) / (1 - 0)));
    //                Debug.Log("Rotating" + axis);
    //                break;
    //            default:
    //                Debug.LogError("No se ha encontrado nigún eje......(RAUL)");
    //                break;
    //        }
    //    }


    //    yield return null;

    //}




}
