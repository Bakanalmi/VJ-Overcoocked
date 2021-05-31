using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateAction : MonoBehaviour
{
    public GameObject lid;

    public Transform open;
    public Transform close;

    // Start is called before the first frame update
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            CloseLid(close);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            OpenLid(open);
    }

    private void OpenLid(Transform place)
    {
        // Set Slot as a parent
        lid.transform.SetParent(place);

        // Reset position and rotation
        lid.transform.localPosition = Vector3.zero;
        lid.transform.localRotation = Quaternion.identity;
    }

    private void CloseLid(Transform place)
    {
        // Set Slot as a parent
        lid.transform.SetParent(place);

        // Reset position and rotation
        lid.transform.localPosition = Vector3.zero;
        lid.transform.localRotation = Quaternion.identity;
    }
}
