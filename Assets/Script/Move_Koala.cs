using UnityEngine;

public class Move_Koala : MonoBehaviour
{
    //public GameObject Koala;

    public float horizontalMove;
    public float verticalMove;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.LeftArrow)) gameObject.transform.Translate(horizontalMove*speed, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.RightArrow)) gameObject.transform.Translate(horizontalMove * speed, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.UpArrow)) gameObject.transform.Translate(0.0f, 0.0f, verticalMove * speed);

        if (Input.GetKey(KeyCode.DownArrow)) gameObject.transform.Translate(0.0f, 0.0f, verticalMove * speed);
    }
}
