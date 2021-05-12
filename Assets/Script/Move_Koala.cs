using UnityEngine;

public class Move_Koala : MonoBehaviour
{
    //public GameObject Koala;

    public float horizontalMove;
    public float verticalMove;

    public float speed = 1.0f; //se ha hardcodeado, ya que unity lo pone por defecto en 0, y asi nos evitamos el error de speed = 0

    public float turnSmootTime = 0.1f;
    float turnSmoothVelocity; //velocidad al girar el personaje


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float targetAngle = Mathf.Atan2(horizontalMove,verticalMove)*Mathf.Rad2Deg; //angulo que indica los grados de giro en un movimiento
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmootTime);

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        

        //Swithc case de los movimientos en el planol
        if (Input.GetKey(KeyCode.LeftArrow)) gameObject.transform.Translate(horizontalMove * speed * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.RightArrow)) gameObject.transform.Translate(horizontalMove * speed * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.UpArrow)) gameObject.transform.Translate(0.0f, 0.0f, verticalMove * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow)) gameObject.transform.Translate(0.0f, 0.0f, verticalMove * speed * Time.deltaTime);


        //Configuración del angulo de rotación
        gameObject.transform.rotation = Quaternion.Euler(0f, angle, 0f);


    }
}
