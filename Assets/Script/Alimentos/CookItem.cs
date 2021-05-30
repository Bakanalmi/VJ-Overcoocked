using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookItem : MonoBehaviour
{
    public GameObject MyMainGameObject;
    public GameObject[] OtherMeshMaterials;
    public GameObject SonidoCortar;

    private CookingBarra cookingBarra;

    private Koala koala;

    public string[] States;
    //State 0: Ingredient cru
    //Sate 1: Ingredient tallat
    //State 2: Ingredient cuinat (opcional, depenent de l'ingredient)

    private int State;
    private int maxMaterials;

    // Start is called before the first frame update
    void Start()
    {
        maxMaterials = OtherMeshMaterials.Length - 1;
        State = 0;
        koala = GameObject.FindGameObjectWithTag("Player").GetComponent<Koala>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cookingBarra != null)
        {
            if (cookingBarra.maxTime > cookingBarra.currentTime)
            {
                Debug.Log(cookingBarra.currentTime);
                cookingBarra.currentTime += Time.deltaTime;
            }
            else
            {
                cookingBarra.ChangeVisibilityCanvas();
                cookingBarra.currentTime = 0f;
                cookingBarra = null;
                State++;
                UpdateMesh();
                koala.SetState(0);
            }
        }
    }

    public string GetState()
    {
        return States[State];
    }

    public void Cut()
    {
        Debug.Log("empiezo a cortar");
        koala.SetState(1);
        cookingBarra = transform.GetComponentInParent<CookingBarra>();
        cookingBarra.ChangeVisibilityCanvas();
        Instantiate(SonidoCortar);
    }

    public void Cook()
    {
        State++;
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        MyMainGameObject.GetComponent<MeshRenderer>().material = OtherMeshMaterials[State].GetComponent<MeshRenderer>().sharedMaterial;
        MyMainGameObject.GetComponent<MeshFilter>().mesh = OtherMeshMaterials[State].GetComponent<MeshFilter>().sharedMesh;
    }
}
