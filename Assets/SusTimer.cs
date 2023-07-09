using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SusTimer : MonoBehaviour
{
    int Hour = 12, Minute = 0;
    int HourLastSeen = 12;
    [SerializeField]
    float TickDuration, BlinkDuration;
    [SerializeField]
    TextMeshProUGUI Clock, LastSeen, Tasks;
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
        if (Hour > HourLastSeen + 3) { GameObject.Find("Player").GetComponent<Player>().WasSeen();
            Debug.Log(Hour + ", " + HourLastSeen);
        }

        // Update Clock UI
        if(!Waiting) StartCoroutine(BlinkTimer());
    }
    public void WasSeen()
    {
        LastSeen.text = Clock.text;
        HourLastSeen = Hour;
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
    public void DoneTask(int num)
    {
        if(num == 0) Tasks.text = "<s>- Put mess in suitcase</s><br><br>- Hide body";
        if(num == 1) Tasks.text = "<s>- Put mess in suitcase<br><br>- Hide body</s>";
    }
}
