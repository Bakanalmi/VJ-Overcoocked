using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoVitalEfecto : MonoBehaviour
{
    // Start is called before the first frame update

    public float TiempoVital;   
    void Start()
    {
        Destroy(gameObject, TiempoVital);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
