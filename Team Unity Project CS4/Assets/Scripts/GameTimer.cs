using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float targetTime;
    TextMeshProUGUI gameTimerUI;
    bool isCounting = true;

    // Start is called before the first frame update
    void Start()
    {
        isCounting = true;
        gameTimerUI = gameObject.GetComponent<TextMeshProUGUI>();
        UpdateGameTimerUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting)
        { 
        targetTime -= Time.deltaTime;
        UpdateGameTimerUI();
        }

        if (targetTime <= 0.0f)
        {
            TimerEnd();
        }
    }

    private void TimerEnd()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            player.GetComponent<PlayerHealth>().KillPlayer();
        }
        else
        {
            Debug.LogError("PLAYER NOT FOUND!");
        }
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    private void UpdateGameTimerUI()
    {
        gameTimerUI.text = "TIME: " + (int) targetTime;
    }
}
