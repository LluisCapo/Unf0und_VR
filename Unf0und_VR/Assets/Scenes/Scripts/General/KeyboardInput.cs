using UnityEngine;
using UnityEngine.UI;

public class KeyboardInput : MonoBehaviour
{
    public InputField inputField;

    private string currentInput = "";

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (char c in Input.inputString)
            {
                if (c == '\b') // Backspace
                    if (currentInput.Length > 0)
                        currentInput = currentInput.Substring(0, currentInput.Length - 1);

                else if (c == '\n' || c == '\r')
                {
                    inputField.text = currentInput;
                    currentInput = "";
                }
                else
                    currentInput += c;
            }
        }
    }
}