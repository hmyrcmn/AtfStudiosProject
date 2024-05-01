using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class sceneManager : MonoBehaviour
{

    // Ana menü butonuna bağlanacak metot
    public void LoadMainMenu()
    {
        // Ana menü sahnesine geçiş
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameScene()
    {
        // Ana menü sahnesine geçiş
        SceneManager.LoadScene("Game");
    }


}
