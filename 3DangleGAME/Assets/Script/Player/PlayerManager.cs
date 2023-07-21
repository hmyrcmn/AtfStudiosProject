using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;



public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel; 
    public static bool isGameStarted;
    public GameObject stratingText;

    public static int numberOfCoins;
    //public Text CoinsText;
    public TextMeshProUGUI  CoinsText;
    // Start is called before the first frame update
    void Start()
    {
        gameOver =false;
        Time.timeScale= 1;
        isGameStarted=false;
        numberOfCoins=0;
    }

    // Update is called once per frame
    public void Update()
    {
        if(gameOver){
            Time.timeScale=0 ;
           
            gameOverPanel.SetActive(true); // make see the game over screen 
        }
        CoinsText.text="Coins: "+ numberOfCoins;
        if(SwipeManager.tap){
            isGameStarted=true;
            Destroy(stratingText);
        }
        
    }
}
