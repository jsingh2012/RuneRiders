using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemProgress : MonoBehaviour
{
    
    public Slider mSlider;
    // Start is called before the first frame update

    private void Awake()
    {
        mSlider = GetComponent<Slider>();
        GemScript.onGemCollected += updateGemProgress;
    }

    private void updateGemProgress(Gem gem)
    {
        mSlider.value = (GameManager.Instance.TotalGemValue / 10f);
        Debug.Log("Mslider mSlider.value "+ mSlider.value);
    }
    
}
