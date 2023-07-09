using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class SusTimer : MonoBehaviour
{
    int Hour = 12, Minute = 0;
    [SerializeField]
    float TickDuration, BlinkDuration;
    [SerializeField]
    TextMeshProUGUI Clock;
    float timer;
    bool Waiting = false; 
    string Symbol = ":";
    private void Start()
    {
        timer = TickDuration;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Update time
            Minute += 15;
            if (Minute >= 60)
            {
                Hour += Minute / 60;
                Minute %= 60;
                if (Hour >= 12) Hour = 1;
            }

            // Reset Timer
            timer = TickDuration;
        }
        // Update Clock UI
        if(!Waiting) StartCoroutine(BlinkTimer());
    }
    IEnumerator BlinkTimer()
    {
        if (Hour < 10) Clock.text = "0" + Hour + Symbol;
        else Clock.text = Hour + Symbol;
        if (Minute == 0) Clock.text += "00";
        else Clock.text += Minute;
        if (Symbol.Equals(":")) Symbol = " ";
        else Symbol = ":";

        // Timer
        Waiting = true;
        yield return new WaitForSeconds(BlinkDuration);
        Waiting = false;
    }
}
