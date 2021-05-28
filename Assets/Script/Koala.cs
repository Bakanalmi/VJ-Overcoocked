
using UnityEngine;

public class Koala : MonoBehaviour
{
    //public GameObject Koala;

    public Transform cam;

    public CharacterController KoalaController;

    public float horizontalMove;
    public float verticalMove;


    public GameObject SonidoCortar;

    private float speed = 3.5f; //se ha hardcodeado, ya que unity lo pone por defecto en 0, y asi nos evitamos el error de speed = 0
    public float gravitity = -9.81f;

    public float turnSmootTime = 0.1f;

    [Range(0, 1)]
    public int State = 0;
    //State = 0 : El Koala tiene total libertad de movimiento
    //State = 1 : El Koala está ocupado con alguna tarea
    
    float turnSmoothVelocity; //velocidad al girar el personaje

    Vector3 velocity;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        StateAnalyse(); //Analizamos el estado donde nos encontramos


        //Swithc case de los movimientos en el planol
        //if (Input.GetKey(KeyCode.LeftArrow)) gameObject.transform.Translate(horizontalMove * speed * Time.deltaTime, 0.0f, 0.0f);

        //if (Input.GetKey(KeyCode.RightArrow)) gameObject.transform.Translate(horizontalMove * speed * Time.deltaTime, 0.0f, 0.0f);

        //if (Input.GetKey(KeyCode.UpArrow)) gameObject.transform.Translate(0.0f, 0.0f, verticalMove * speed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.DownArrow)) gameObject.transform.Translate(0.0f, 0.0f, verticalMove * speed * Time.deltaTime);


        //Configuración del angulo de rotación




        //TODO: Configuración de la rotación con el MOUSE

       



    }


    public void StateAnalyse()
        
    {
        if (State == 0)
        {
            //no debemos hacer nada, el Koala debe continuar con su actividad
        }

        if (State == 1) //Koala Ocupado
        {

            State = 0;
            Instantiate(SonidoCortar); //ejecutamos el EFECTO CORTAR alimentos
            float Timer = 0f;
            float FrozenTime = 8.0f;
            while (Timer < FrozenTime)
            {
                Timer += Time.deltaTime;
            }
            




            //Aparición de la barra de tiempo






        }

    }


    public void SetState(int state)
    {
        State = state;
    }

    public int GetState() { return State;  }
}
