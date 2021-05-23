using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookItem : MonoBehaviour
{
    public GameObject MyMainGameObject;
    public GameObject[] OtherMeshMaterials;

    public string[] States;

    private int State;
    private int maxMaterials;

    // Start is called before the first frame update
    void Start()
    {
        maxMaterials = OtherMeshMaterials.Length - 1;
        State = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetState()
    {
        return States[State];
    }

    public void Cut()
    {
        State++;
        UpdateMesh();
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
