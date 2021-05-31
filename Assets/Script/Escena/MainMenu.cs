using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button PlayButton;
    public Button Scenen1;
    public Button Scenen2;
    private int indexScene;


    public void Start()
    {
        indexScene = 1;

        Scenen1.onClick.AddListener(delegate { TaskOnClick(1); });
        Scenen2.onClick.AddListener(delegate { TaskOnClick(2); });

    }


    private void TaskOnClick(int index)
    {
        indexScene = index;
    }

    public void SwapScene()
    {

        //SceneManager.LoadScene("SampleScene"); 

        //SceneManager.LoadScene();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(indexScene);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
