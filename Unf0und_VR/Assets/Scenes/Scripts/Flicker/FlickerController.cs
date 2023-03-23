using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerController : MonoBehaviour
{
    public GameObject FlickerCanvas;
    public void FlickerControl()
    {
        FlickerCanvas.SetActive(false);
    }
}
