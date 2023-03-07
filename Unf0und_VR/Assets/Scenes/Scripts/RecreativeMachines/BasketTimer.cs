using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class BasketTimer : MonoBehaviour
{
    // 3/3/2023 Lluís Capó

    [SerializeField] int seconds;
    [SerializeField] TMP_Text timeText;

    public UnityEvent timeOut;
    public void StartTimer()
    {
        timeText.gameObject.SetActive(true);
        timeText.text = seconds.ToString();
        StartCoroutine(time());
    }

    public void StopTimer()
    {
        StopCoroutine(time());
        timeText.gameObject.SetActive(false);
    }

    private IEnumerator time()
    {
        for(int i = seconds; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
            timeText.text = i.ToString();
        }

        timeOut.Invoke();
    }
}
