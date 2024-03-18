using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [Header("Slider Settings")]
    [SerializeField] Slider _soundSlider;
    [SerializeField] AudioMixer _masterMixer;

    // Start is called before the first frame update
    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    private void SetVolume(float value)
    {
        if (value < 1) value = 0.001f;

        RefreshSlider(value);
        PlayerPrefs.SetFloat("SavedMasterVolume", value);
        _masterMixer.SetFloat("MasterVolume", Mathf.Log10(value / 100) * 20f);
    }

    private void RefreshSlider(float value)
    {
        _soundSlider.value = value;
    }

    public void SetValueFromSlider()
    {
        SetVolume(_soundSlider.value);
    }
}
