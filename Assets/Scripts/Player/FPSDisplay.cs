using System;
using UnityEngine;
using System.Globalization;

public class FPSDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    //deltaTime will be updated once per frame
    private float deltaTime = 0.0f;
    private GUIStyle style;
    private Rect rect;
    private string fpsText;
    private NumberFormatInfo numberFormat;

    private void Awake()
    {
        // Set the target frame rate to 60 FPS
        Application.targetFrameRate = 60; // Limit to 60 FPS
        
        // Cache NumberFormatInfo to avoid allocations
        numberFormat = new NumberFormatInfo();
        numberFormat.NumberDecimalDigits = 1;

        // Initialize style once
        style = new GUIStyle();
        style.fontSize = 24;
        style.normal.textColor = Color.green;
        style.alignment = TextAnchor.UpperLeft;

        // Initialize label position
        //rect = new Rect(10, 10, 200, 30);
        
        int W = Screen.width, H = Screen.height;
        
        rect = new Rect(10, 10, W, H * 2 / 100);
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f; // Smooth the delta time value
        
        // Format FPS string using cached number format to avoid boxing
        float fps = 1.0f / deltaTime;
        fpsText = fps.ToString("N", numberFormat) + " FPS";
    }
    
    void OnGUI()
    {
        GUI.Label(rect, fpsText, style);
    }
}
