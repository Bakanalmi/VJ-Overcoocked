using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public GameObject[] slots;
    public string[] food;
    // Start is called before the first frame update
    void Start()
    {
        food[0] = "";
        food[1] = "";
        food[2] = "";
        food[3] = "";
        food[4] = "";
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; ++i)
        {
            if (slots[i].transform.childCount != 0)
            {
                food[i] = slots[i].transform.GetComponentInChildren<PickableItem>().foodName;
                slots[i].transform.GetComponentInChildren<PickableItem>().Change();
            }

            else
                food[i] = "";
        }
    }
}
