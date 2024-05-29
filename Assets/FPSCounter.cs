using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public float SmoothSpeed = 1f;
    float fps, smoothFps;
    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        fps = 1f / Time.smoothDeltaTime;
        if (Time.timeSinceLevelLoad < 0.1f) smoothFps = fps;
        smoothFps += (fps - smoothFps) * Mathf.Clamp(Time.deltaTime * SmoothSpeed, 0, 1);
        text.text = ((int)smoothFps).ToString() + " fps";
    }
}