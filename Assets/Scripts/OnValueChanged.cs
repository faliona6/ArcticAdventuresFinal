using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class OnValueChanged : MonoBehaviour {
    /*
    public Slider MusicVolSlider;
    public AudioSource volumeAudio;

    public void VolumeController()
    {
        volumeAudio.volume = MusicVolSlider.value;
    }
	*/

    public void ChangeVol(float newValue)
    {
        float newVol = AudioListener.volume;
        newVol = newValue;
        AudioListener.volume = newVol;
    }
}
