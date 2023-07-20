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
        Debug.Log("updateGemProgress "+ (LevelManager.Instance.Gems - LevelManager.Instance.prevMileStone()));
        mSlider.value = ((LevelManager.Instance.Gems - LevelManager.Instance.prevMileStone()) / (float)LevelManager.Instance.nextMileStone());
        Debug.Log("Mslider mSlider.value "+ mSlider.value);
    }
    
}
