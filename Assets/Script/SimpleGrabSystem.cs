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
                // If no, try to pick item in front of the player
                // Create ray from center of the screen
                for (int i = 1; i < 9; ++i)
                {
                    var ray = new Ray();
                    ray.origin = character.position;
                    Vector3 direction = new Vector3().normalized;
                    if (i == 1)
                    {
                        direction = Vector3.forward;
                    }
                    else if ( i == 2)
                    {
                        direction = new Vector3(0f,1f,1f).normalized;
                    }
                    else if (i == 3)
                    {
                        direction = new Vector3(0f,-1f,1f).normalized;
                    }
                    else if (i == 4)
                    {
                        direction = new Vector3(1f,0f,1f).normalized;
                    }
                    else if (i == 5)
                    {
                        direction = new Vector3(-1f,0f,1f).normalized;
                    }
                    else if (i == 6)
                    {
                        direction = new Vector3(1f, 1f, 1f).normalized;
                    }
                    else if (i == 7)
                    {
                        direction = new Vector3(1f, -1f, 1f).normalized;
                    }
                    else if (i == 8)
                    {
                        direction = new Vector3(-1f, 1f, 1f).normalized;
                    }
                    else
                    {
                        direction = new Vector3(-1f, -1f, 1f).normalized;
                    }
                    ray.direction = character.TransformDirection(direction);
                    RaycastHit hit;
                    // Shot ray to find object to pick
                    if (Physics.Raycast(ray, out hit, 1.5f))
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
        item.transform.localEulerAngles = Vector3.zero;

    }

    /// <summary>
    /// Method for dropping item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void DropItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;

        // Remove parent
        item.transform.SetParent(null);

        // Enable rigidbody
        item.Rb.isKinematic = false;

        // Add force to throw item a little bit
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
}