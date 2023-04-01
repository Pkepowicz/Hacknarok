using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    void Start()
    {
        // Set the initial value of the slider to the current volume of the audio source
        slider.value = audioSource.volume;
    }

    void Update()
    {
        // Update the volume of the audio source based on the value of the slider
        audioSource.volume = slider.value;
    }
}