using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUiManager : MonoBehaviour
{
    public GameObject matchPanel;
    public TMP_Text timeDisplay;
    private float matchTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (matchPanel.activeInHierarchy)
        {
            if (matchTime == 0f)
            {
                matchTime = Time.time;
            }
            else
            {
                Debug.Log(Time.time - matchTime);
                float currentTime = Time.time - matchTime;
                int minutes = Mathf.FloorToInt(currentTime / 60);
                int seconds = Mathf.FloorToInt(currentTime % 60);
                string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
                timeDisplay.text = timeString;
            }
        }
        else
        {
            matchTime = 0;
        }
    }
}
