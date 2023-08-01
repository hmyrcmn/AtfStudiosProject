using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine. SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject stonePrefab;
    public GameObject objelerParent;
    private int numRows = 4; // Satır sayısı
    private int numColumns = 3; // Sütun sayısı
    private float tileSize = 150.0f; // Taşlar arasındaki mesafe

    public GameObject PysStone;
    private int PyStoneNum;
    public int[] RowValues;
    public int currentNum;

    public GameObject player;
    public GameObject Stones;

    private Vector3 startSlidePosition;
    private Vector3 targetSlidePosition;
    private float slideDuration = 0.5f;
    private float slideTimer = 0f;
    private bool isSliding = false;


    public GameObject succesPanel;
    public Animator animator;
    public string currentScene;
  

    void Start()
    {
         currentScene = SceneManager.GetActiveScene().name;
         
        Text PysStoneText = PysStone.GetComponentInChildren<Text>();
        string textValue = PysStoneText.text;
        Debug.Log("pysStone Text: " + textValue);
        PyStoneNum = int.Parse(textValue);
        currentNum = PyStoneNum;

        AddStones();

        animator.SetBool("isGame",true);
         animator.Play("isGame");
    }

    void Update()
    {
        if (isSliding)
        {
            SlideStone();
        }
        if(currentScene=="Level1") {
                 if(currentNum==14  ){
                    // level completer load new scene 
                // SceneManager.LoadSceneAsync((int)(PlayerPrefs.GetInt("level")+2));
                succesPanel.SetActive(true);
                }
        }else {
                if(currentNum ==24  ){
                // level completer load new scene 
            // SceneManager.LoadSceneAsync((int)(PlayerPrefs.GetInt("level")+2));
            succesPanel.SetActive(true);
            }
        }
       
    }

    void SlideStone()
    {
        if(currentScene =="Level1"){

             if ((slideTimer < slideDuration && currentNum != 10 )){
            slideTimer += Time.deltaTime;
            float t = Mathf.Clamp01(slideTimer / slideDuration);
            Stones.transform.position = Vector3.Lerp(startSlidePosition, targetSlidePosition, t);
            }
            else
            {
                isSliding = false;
            }
        }else{
                if ((slideTimer < slideDuration && currentNum != 20 )){
                slideTimer += Time.deltaTime;
                float t = Mathf.Clamp01(slideTimer / slideDuration);
                Stones.transform.position = Vector3.Lerp(startSlidePosition, targetSlidePosition, t);
            }
            else
            {
                isSliding = false;
            }
        }
      
    }

    void SlideToNextPosition()
    {
        startSlidePosition = Stones.transform.position;
        targetSlidePosition = startSlidePosition - new Vector3(0f, 150.0f, 0f);

        slideTimer = 0f;
        isSliding = true;
    }

    void AddStones()
    {
        Vector3 startPos = new Vector3(-((numColumns - 1) * tileSize) / 2, ((numRows - 1) * tileSize) + 150.0f, 0f);

        for (int row = 4; row > 0; row--)
        {
            if (row == 3)
            {
                tileSize += 50.0f;
                startPos = new Vector3(-((numColumns - 1) * tileSize) / 2, ((numRows - 1) * tileSize) + 150.0f, 0f);
            }
            else
            {
                startPos = new Vector3(-((numColumns - 1) * tileSize) / 2, ((numRows - 1) * tileSize) + 150.0f, 0f);
            }

            RowValues = new int[numRows];
            for (int i = 0; i < RowValues.Length; i++)
            {
                RowValues[i] = 0;
            }

            for (int col = 0; col < numColumns; col++)
            {
                int newRandomNum;
                do
                {
                    newRandomNum = Random.Range(PyStoneNum - 2, PyStoneNum + 2);
                } while ((newRandomNum == PyStoneNum) || (isNumberWritten(RowValues, newRandomNum)));
                RowValues[col] = newRandomNum;

                Vector3 position = startPos + new Vector3(col * tileSize, -row * tileSize, 0f);
                var obj = Instantiate(stonePrefab, position, Quaternion.identity);
                obj.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(obj.transform, newRandomNum));
                obj.transform.SetParent(objelerParent.transform, false);

                Text stoneText = obj.GetComponentInChildren<Text>();
                stoneText.text = newRandomNum.ToString();
            }
            PyStoneNum++;
        }
        
        SlideToNextPosition();

        
    }

    bool isNumberWritten(int[] sendedArray, int RandomNum)
    {
        for (int i = 0; i < sendedArray.Length; i++)
        {
            if (sendedArray[i] == RandomNum)
            {
                return true;
            }
        }
        return false;
    }

    public void ButtonClicked(Transform stonePos, int gelenSayi)
    {
        Debug.Log("Bu taşta yazan sayı: " + gelenSayi + "  pozisyonu: " + stonePos.position);
        if (gelenSayi == currentNum + 1)
        {
            currentNum++;
            print("current:");
            print(currentNum);
            movePlayer(stonePos);
        }
        else
        {
            // Hatalı seçim
             //playerAnimator.SetTrigger("Drop"); 
             
               animator.SetBool("Drop",true);
        }
    }

    void movePlayer(Transform stoneToGo)
    {
        
        player.transform.position = stoneToGo.position + new Vector3(10.0f, 50.0f, 0.0f);
        SlideToNextPosition();
    }

    public void LoadLevel2()
    {
      //  print("looding ner level ");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
