using UnityEngine;

/// <summary>
/// Simple example of Grabbing system.
/// </summary>
public class SimpleGrabSystem : MonoBehaviour
{
    // Reference to the character camera.
    [SerializeField]
    private Transform character;

    // Reference to the slot for holding picked item.
    [SerializeField]
    private Transform slot;

    // Reference to the currently held item.
    private PickableItem pickedItem;

    private Collider hit = null;

    private bool FoodAvailable = false;
    private bool CutFoodAvailable = false;

    /// <summary>
    /// Method called very frame.
    /// </summary>
    private void Update()
    {
        // Execute logic only on button pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if player picked some item already
            if (pickedItem)
            {
                // If yes, drop picked item
                DropItem(pickedItem);
            }
            else
            {
                // If player can pick an item in front of him
                if (FoodAvailable)
                {
                    // Check if object is pickable
                    var pickable = hit.transform.GetComponent<PickableItem>();

                    // If object has PickableItem class
                    if (pickable)
                    {
                        // Pick it
                        PickItem(pickable);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Method for picking up item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void PickItem(PickableItem item)
    {
        // Assign reference
        pickedItem = item;

        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        // Set Slot as a parent
        item.transform.SetParent(slot);

        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;

    }

    /// <summary>
    /// Method for dropping item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void DropItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;

        if (CutFoodAvailable)
        {
            PlaceItem(item);
        }
        
        else
        {
            // Remove parent
            item.transform.SetParent(null);

            // Enable rigidbody
            item.Rb.isKinematic = false;

            // Add force to throw item a little bit
            item.Rb.AddForce(item.transform.forward * 200);
        }
    }

    /// <summary>
    /// Method for placing the item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void PlaceItem(PickableItem item)
    {
        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        // Set Slot as a parent

        item.transform.SetParent(hit.transform);

        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            FoodAvailable = false;
            hit = null;
        }

        else if (other.gameObject.CompareTag("cuttingTable"))
        {
            CutFoodAvailable = false;
            hit = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            FoodAvailable = true;
            hit = other;
        }

        else if (other.gameObject.CompareTag("cuttingTable"))
        {
            if (other.transform.childCount == 0) 
            {
                CutFoodAvailable = true;
                hit = other;
            }
        }
    }
}