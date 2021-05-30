
using System;
using System.Collections;
using UnityEngine;

public class Koala : MonoBehaviour
{
    //public GameObject Koala;

    public Transform cam;

    public CharacterController KoalaController;

    public float horizontalMove;
    public float verticalMove;


    public GameObject SonidoCortar;
    public GameObject progressBar;

    private float speed = 3.5f; //se ha hardcodeado, ya que unity lo pone por defecto en 0, y asi nos evitamos el error de speed = 0
    public float gravitity = -9.81f;

    public float turnSmootTime = 0.1f;

    [Range(0, 1)]
    private int State;
    //State = 0 : El Koala tiene total libertad de movimiento
    //State = 1 : El Koala está ocupado con alguna tarea
    
    float turnSmoothVelocity; //velocidad al girar el personaje

    Vector3 velocity;



    // Start is called before the first frame update
    void Start()
    {
        State = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == 0)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalMove, 0f, verticalMove).normalized;

            if (direction.magnitude >= 0.1f) //si detectamos movimiento, actuamos de la siguiente manera:
            {

                //configuración del giro de rotación sobre el eje Y
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //angulo que indica los grados de giro en un movimiento
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmootTime);

                //instrucciones de rotación
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                //instrucciones de movimiento
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                transform.Translate(moveDir * speed * Time.deltaTime);
                KoalaController.Move(moveDir.normalized * speed * Time.deltaTime);

            }
            velocity.y += gravitity * Time.deltaTime;
            KoalaController.Move(velocity * Time.deltaTime);
        }
    }

    public void SetState(int state)
    {
        State = state;
    }

    public int GetState() { return State;  }
}
