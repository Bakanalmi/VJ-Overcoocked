using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    // Use this for initializatio
    public int minutes; //Amount of initial minutes. This variable doesn't change its value during the execution of the game.
    
    public int seconds; //Amount of initial seconds. This variable doesn't change its value during the execution of the game.

    private int m, s; //Current time values. These variables are modified as time goes by.

    
    public Text timerText; //Here we will save a reference of the text element of the Canvas.


    public void Start()
    {

        m = minutes;
        s = seconds;
        writeOnTimer(m, s);
        Invoke("updateTimer", 1f);
    }

    public void stopTimer()
    {

    }

    public void updateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                //TODO: finalizar el juego
            }
            else
            {
                --m;
                s = 59;
            }
        }
        writeOnTimer(m, s);
        Invoke("updateTimer", 1f);

    }

    private void writeOnTimer(int m, int s)
    {
        if (s<10) //la variable de los segundos solo tiene un digito
        {
            timerText.text = m.ToString() + ":0" + s.ToString();
        }

        else
        {
            timerText.text = m.ToString() + ":" + s.ToString();
        }

    }



}
