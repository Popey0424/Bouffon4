using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SliderValue : MonoBehaviour
{
    public TMP_Text TextValue;
    public Slider Slider;
    

    public void OnValueChanged(float newValue)
    {
        int valueInt = (int)Mathf.Round(newValue * 100.0f);
        TextValue.text = valueInt.ToString();
    }

    //public void OnSFXValuechanged(float newValue)
    //{
    //    if (newValue < 0.01f)
    //        newValue = 0.01f;

    //    float volume = Mathf.Log10(newValue) * 20;

    //    Mixer.SetFloat("SFX_Volumle", volume);
    //}
}
