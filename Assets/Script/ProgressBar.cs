using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public GameObject Canvas;
    public GameObject KoalaHead;
    public GameObject clocker;
    private float Timerlife;

    private void Start()
    {
        Timerlife = 8f;
        slider.value = slider.maxValue;
        Destroy(gameObject, Timerlife);

    }

    private void Update()
    {
        clocker.transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);

        slider.value = -0.0005f;

       
     }

    public void SetProgressBar (int value)
    {
        slider.value = value;
    }   
}
