using UnityEngine;

public class Move_Koala : MonoBehaviour
{

    //public GameObject Koala;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) gameObject.transform.Translate(-0.10f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.RightArrow)) gameObject.transform.Translate(+0.10f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.UpArrow)) gameObject.transform.Translate(0.0f, 0.0f, +0.1f);

        if (Input.GetKey(KeyCode.DownArrow)) gameObject.transform.Translate(0.0f, 0.0f, -0.1f);
    }
}
