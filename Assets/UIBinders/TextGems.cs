using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextGems : MonoBehaviour
{
    [SerializeField] private TMP_Text mText;
    // Start is called before the first frame update
    private void Awake()
    {
        mText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = "Gems :" + LevelManager.Instance.GetGemsCount() + " / "+ LevelManager.Instance.nextMileStone();
    }
}
