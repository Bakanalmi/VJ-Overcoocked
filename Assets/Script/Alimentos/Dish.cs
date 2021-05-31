using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public GameObject lettuce_salad;
    private string lettuce_state;
    public GameObject tomatoe_salad;
    private string tomatoe_state;
    private string Onion_state;
    //public GameObject foodPrefab;
    //public GameObject foodPrefab;
    //public GameObject foodPrefab;
    //public GameObject foodPrefab;
    //public GameObject foodPrefab;
    //public GameObject foodPrefab;
    //public GameObject foodPrefab;
    //public GameObject foodPrefab;
    //public GameObject foodPrefab;

    public GameObject[] slots;
    public string[] food;
    private bool completed;
    // Start is called before the first frame update
    void Start()
    {
        food[0] = "";
        food[1] = "";
        food[2] = "";
        food[3] = "";
        food[4] = "";
        completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            for (int i = 0; i < 5; ++i)
            {
                if (slots[i].transform.childCount != 0)
                {
                    food[i] = slots[i].transform.GetComponentInChildren<PickableItem>().foodName;
                    if (food[i] == "Lettuce")
                        lettuce_state = slots[i].transform.GetComponentInChildren<CookItem>().GetState();
                    else if (food[i] == "Tomatoe")
                        tomatoe_state = slots[i].transform.GetComponentInChildren<CookItem>().GetState();
                    else if (food[i] == "Onion")
                        Onion_state = slots[i].transform.GetComponentInChildren<CookItem>().GetState();
                    slots[i].transform.GetComponentInChildren<PickableItem>().Change();
                }

                else
                    food[i] = "";
            }

            Salad();
            Soup();
        }
    }

    private void Salad()
    {
        if (lettuce_state == "Cut" && tomatoe_state == "Cut") {
            int numFoodCorrect = 0;
            for (int i = 0; i < 5; ++i)
            {
                if (food[i] == "Tomatoe" || food[i] == "Lettuce")
                    ++numFoodCorrect;
            }

            if (numFoodCorrect == 2)
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (slots[i].transform.childCount != 0)
                        DestroyImmediate(slots[i].transform.GetChild(0).gameObject);
                }
                GameObject lettuce = Instantiate(lettuce_salad, slots[1].transform.position, Quaternion.identity, slots[1].transform);
                lettuce.GetComponent<Rigidbody>().isKinematic = true;
                GameObject tomatoe = Instantiate(tomatoe_salad, slots[2].transform.position, Quaternion.identity, slots[2].transform);
                tomatoe.GetComponent<Rigidbody>().isKinematic = true;
                completed = true;
            }
        }
    }

    private void Soup()
    {
        if (tomatoe_state == "Cooked" || Onion_state == "Cooked")
        {
            int numFoodCorrect = 0;
            for (int i = 0; i < 5; ++i)
            {
                if (food[i] == "Tomatoe" || food[i] == "Onion")
                    ++numFoodCorrect;
            }

            if (numFoodCorrect == 1)
                completed = true;
        }
    }
}
