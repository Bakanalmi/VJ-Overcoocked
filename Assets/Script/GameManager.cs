
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public float restartDelay = 2f; //tiempo de retraso entre el fin del juego y el restart

    public bool GameHasFinish = false;
   public void EndGame()
    {
        Debug.Log("En breves reiniciamos el juego: GAME-OVER");
        if (GameHasFinish) Invoke("Restart",restartDelay);
    }


    void Restart()
    {
        GameHasFinish = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //devolvemos a la escena inicial de cocina

    }
}
