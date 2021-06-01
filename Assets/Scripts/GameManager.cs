
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

   
{
    bool gameHasEnded = false;
    public float restartDelay = 0.5f;

    public void EndGame ()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
            //restart game
            Invoke("Restart", restartDelay);
        }
        
        
        
    }
    void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
