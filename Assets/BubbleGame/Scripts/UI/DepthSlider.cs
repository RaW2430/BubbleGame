using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DepthSlider : MonoBehaviour
{
    public float maxDepth = 10984f;
    public float value = 0;
    public float ratio=>value/maxDepth;
    
    public Slider slider;
    private PlayerAttributes playerAttributes;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (playerAttributes == null)
        {
            playerAttributes = FindObjectOfType<PlayerAttributes>();
        }
        value = playerAttributes.transform.position.y+114;
        slider.value = ratio;
    }
}
