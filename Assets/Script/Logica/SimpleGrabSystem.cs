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

    [SerializeField]
    private Transform slotSoup;

    // Reference to the currently held item.
    public PickableItem pickedItem;

    public Koala KoalaController;

    public Collider hit = null;
    public Collider dishSlot = null;

    private bool FoodAvailable = false;
    private bool placeItem = false;
    private bool cutAvailable;
    private bool dish;

    /// <summary>
    /// Method called very frame.
    /// </summary>
    private void Update()
    {
        // Execute logic only on button pressed
        if (Input.GetKeyDown(KeyCode.Space) && KoalaController.GetState() == 0)
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
        item.transform.localRotation = Quaternion.identity;
    }

    /// <summary>
    /// Method for dropping item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void DropItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;

        if (placeItem)
        {
            PlaceItem(item);
        }

        else if (dish)
        {
            PlaceItemDish(item);
        }
        
        else
        {
            // Remove parent
            item.transform.SetParent(null);

            // Enable rigidbody
            item.Rb.isKinematic = false;

            // Add force to throw item a little bit
            item.Rb.AddForce(slot.transform.forward * 200);
        }
        hit = null;
        dishSlot = null;
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
        item.transform.localRotation = Quaternion.identity;

        if (hit.transform.CompareTag("Olla"))
        {
            var cookItem = item.transform.GetComponent<CookItem>();
            if (cookItem != null)
            {
                if (cookItem.GetState() == "Cut")
                cookItem.Cook();
            }
        }
    }

    private void PlaceItemDish(PickableItem item)
    {
        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        // Set Slot as a parent
        item.transform.SetParent(dishSlot.transform);

        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            FoodAvailable = false;
        }

        else if (other.gameObject.CompareTag("cuttingTable"))
        {
            placeItem = false;
            cutAvailable = false;
        }

        else if (other.gameObject.CompareTag("Table"))
        {
            placeItem = false;
        }

        else if (other.gameObject.CompareTag("Dish"))
        {
            FoodAvailable = false;
        }

        else if (other.gameObject.CompareTag("FoodSlot"))
        {
            dish = false;
        }

        else if (other.gameObject.CompareTag("Paella") || other.gameObject.CompareTag("Olla"))
        {
            placeItem = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            if (other.transform.parent == null || !other.transform.parent.CompareTag("FoodSlot"))
            {
                FoodAvailable = true;
                hit = other;
            }
            if (!other.transform.GetComponent<CookItem>().cooking && slot.childCount == 1 && other.transform.parent.CompareTag("Olla") && 
                slot.GetChild(0).GetChild(2).childCount == 0 && slot.GetChild(0).CompareTag("Dish"))
            {
                var item = other.transform.GetComponent<PickableItem>();

                // Disable rigidbody and reset velocities
                item.Rb.isKinematic = true;
                item.Rb.velocity = Vector3.zero;
                item.Rb.angularVelocity = Vector3.zero;

                // Set Slot as a parent
                item.transform.SetParent(slot.GetChild(0).GetChild(2));

                // Reset position and rotation
                item.transform.localPosition = Vector3.zero;
                item.transform.localRotation = Quaternion.identity;
            }
        }

        else if (other.gameObject.CompareTag("cuttingTable"))
        {
            if (other.transform.childCount == 1)
            {
                placeItem = true;
                hit = other;
            }
            cutAvailable = true;
        }

        else if (other.gameObject.CompareTag("Table"))
        {
            if (other.transform.childCount == 0)
            {
                placeItem = true;
                hit = other;
            }
        }

        else if (other.gameObject.CompareTag("Dish"))
        {
            if (other.transform.childCount == 5)
            {
                FoodAvailable = true;
                hit = other;
            }
        }

        else if (other.gameObject.CompareTag("FoodSlot") && pickedItem != null)
        {
            if (other.transform.childCount == 0 && pickedItem.foodName != "Dish")
            {
                dish = true;
                dishSlot = other;
            }
        }

        else if (other.gameObject.CompareTag("Paella") || other.gameObject.CompareTag("Olla"))
        {
            if (other.transform.childCount == 1)
            {
                placeItem = true;
                hit = other;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && KoalaController.GetState() == 0)
        {
            var cookItem = other.transform.GetComponent<CookItem>();
            if (cookItem != null)
            {
                if (cookItem.GetState() == "Raw" && cutAvailable)
                {
                    KoalaController.SetState(1); //Koala se debe encontrar ocupado
                    //Debug.Log("Entro en alimento a punto de ser cortado");
                    cookItem.Cut();
                }
            }
        }   
    }
}