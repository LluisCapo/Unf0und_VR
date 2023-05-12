using UnityEngine;
using System.Collections;

public class CapRecorder : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.F10))
        {
            string screenshotIMGName = System.DateTime.Now.ToString();
            string subString = screenshotIMGName.Replace('/', '_');
            string gypsy = subString.Replace(':', '_');
            Debug.Log("Screen shot captured: " + gypsy + ".png");
            ScreenCapture.CaptureScreenshot(gypsy + ".png");
        }
    }
}