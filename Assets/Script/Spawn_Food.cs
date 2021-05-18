using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Food : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform theDest;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int grabed = theDest.hierarchyCount;

            if (Input.GetKeyDown(KeyCode.Space) && grabed == 8)
            {
                Debug.Log("hola");
                GameObject food = (GameObject)Instantiate(foodPrefab, theDest.position, foodPrefab.transform.rotation);
                food.GetComponent<MeshCollider>().enabled = false;
                food.GetComponent<Rigidbody>().useGravity = false;
                food.transform.position = theDest.position;
                food.transform.parent = GameObject.Find("Destination").transform;
            }
        }
    }
}
