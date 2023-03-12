using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private float _velocityTime = 0.1f;
    private float _timeScale;
    private float _fixedDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
         _timeScale = Time.timeScale;
        _fixedDeltaTime = Time.fixedDeltaTime;
    }

    public void StartControlTime()
    {
        StartCoroutine(ControlTime());
        /*Time.timeScale = _velocityTime;
        Time.fixedDeltaTime = _fixedDeltaTime * _velocityTime;
        Invoke("PauseControlTime", 3);*/
    }

    public void PauseControlTime()
    {
        Time.timeScale = _timeScale;
        Time.fixedDeltaTime = _fixedDeltaTime;
    }

    private IEnumerator ControlTime()
    {
        Time.timeScale = _velocityTime;
        Time.fixedDeltaTime = _fixedDeltaTime * _velocityTime;

        yield return new WaitForSeconds(0.2f);

        Time.timeScale = _timeScale;
        Time.fixedDeltaTime = _fixedDeltaTime;
    }
}
