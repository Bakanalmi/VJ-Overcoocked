using UnityEngine;

/// <summary>
/// Attach this class to make object pickable.
/// </summary>
public class SpawnItem : MonoBehaviour
{
    // Reference to the food prefab to be generated
    public GameObject foodPrefab;
    // Reference the position to be created
    public Transform theDest;

    /// <summary>
    /// Method called on initialization.
    /// </summary>
    private void Update()
    {
        // Get the number of childs
        int numChild = transform.childCount;
        // Generates a new child if numChild == 0
        if (numChild == 0)
        {
            GameObject food = Instantiate(foodPrefab, theDest.position, Quaternion.identity, theDest);
            food.GetComponent<Rigidbody>().isKinematic = true;
            food.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}