using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Koala : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(-0.1f, 0.0f, 0.0f);
                
        }
    }
}
