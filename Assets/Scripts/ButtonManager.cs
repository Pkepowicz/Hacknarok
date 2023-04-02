using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons;

    private int currentButtonIndex = 0;

    void Start()
    {
        // Disable all buttons except for the first one
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void OnButtonClick()
    {
        // Increment the current button index
        currentButtonIndex++;

        // Disable the previous button
        buttons[currentButtonIndex - 1].interactable = false;

        // Enable the next button
        buttons[currentButtonIndex].interactable = true;
    }
}
