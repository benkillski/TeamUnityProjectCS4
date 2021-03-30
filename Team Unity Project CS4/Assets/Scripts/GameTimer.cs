using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float targetTime;
    TextMeshProUGUI gameTimerUI;

    // Start is called before the first frame update
    void Start()
    {
        gameTimerUI = gameObject.GetComponent<TextMeshProUGUI>();
        UpdateGameTimerUI();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        UpdateGameTimerUI();

        if (targetTime <= 0.0f)
        {
            TimerEnd();
        }
    }

    private void TimerEnd()
    {
        //Kill Player
    }

    private void UpdateGameTimerUI()
    {
        gameTimerUI.text = "TIME: " + (int) targetTime;
    }
}
