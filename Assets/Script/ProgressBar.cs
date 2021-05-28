using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Gradient gradient;
   
    public void SetProgressBar (int value)
    {
        slider.value = value;
    }   
}
