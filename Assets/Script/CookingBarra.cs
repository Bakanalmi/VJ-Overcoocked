using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingBarra : MonoBehaviour
{
    public Image barraCooking;

    public Canvas UI;

    public float maxTime;
    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        UI.enabled = false;
        maxTime = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        barraCooking.fillAmount = currentTime / maxTime;
    }

    public void ChangeVisibilityCanvas()
    {
        UI.enabled = !UI.enabled;
    }
}
