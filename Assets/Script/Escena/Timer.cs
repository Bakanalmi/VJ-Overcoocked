
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    // Use this for initializatio
    public int minutes; //Amount of initial minutes. This variable doesn't change its value during the execution of the game.
    
    public int seconds; //Amount of initial seconds. This variable doesn't change its value during the execution of the game.

    private int m, s; //Current time values. These variables are modified as time goes by.

    //public Image Roscon_Timer;

    public AudioMixer audiomixer;
    public Button buttonBackGround;
    public Color colorFlash;
    private bool buttonFlash;

    //public Light myLight;

    
    public TextMeshProUGUI timerText; //Here we will save a reference of the text element of the Canvas.


    public void Start()
    {

        //m = minutes;
        //s = seconds;
        m = 1;
        s = 10;
        writeOnTimer(m, s);
        Invoke("updateTimer", 1f);
        //myLight = GetComponent<Light>();
        buttonFlash = false;

      

    }

    public void stopTimer()
    {
        m = 0;
        s = 0;
        writeOnTimer(m, s);
        Time.timeScale = 0;
        AudioListener.pause = true;
        FindObjectOfType<GameManager>().GameHasFinish = true;
        FindObjectOfType<GameManager>().EndGame();
        

    }

    public void updateTimer()
    {   

        s--;
        if (s < 0)
        {
            
            if (m == 0)
            {
                //TODO: finalizar el juego
              //  Roscon_Timer.enabled = false;
                Invoke("stopTimer", 0f) ;
                
            }
            else
            {
                --m;
                s = 59;
                
              
            }
        }
        else if (s <= 59 && m == 0) //en los últimos 30s, aumentamos la velocidad de la música
        {
            SpeedUpPithc();
            if (s <= 10) //en los ultimos 30s
            {
                changeColorButton();
                buttonFlash = !buttonFlash;
                
                

            }
        }
        float Time_rest = m * 60 + s;
       // Roscon_Timer.fillAmount -= 1.0f/Time_rest * Time.deltaTime;
        writeOnTimer(m, s);
        Invoke("updateTimer", 1f);

    }

    private void changeColorButton()
    {
        
        if (buttonFlash)
        {
            buttonBackGround.image.color = Color.yellow;
        }
        else
        {
            buttonBackGround.image.color = Color.white;

        }


    }

    private void writeOnTimer(int m, int s)
    {
        if (s<10) //la variable de los segundos solo tiene un digito
        {
            timerText.SetText(m.ToString() + ":0" + s.ToString());
        }

        else
        {
            timerText.SetText( m.ToString() + ":" + s.ToString());
        }

    }

    public void SpeedUpPithc()
    {
        float pitch;
        audiomixer.GetFloat("Pitch", out pitch);   
        audiomixer.SetFloat("Pitch", pitch + 0.0085f);
    }





}
