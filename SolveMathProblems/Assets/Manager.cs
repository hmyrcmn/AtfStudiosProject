using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    // qsc blok
    public TextMeshProUGUI Num1;
    public TextMeshProUGUI operand;
    public TextMeshProUGUI Num2;
    public TextMeshProUGUI qs;

    // buttons 
    public TextMeshProUGUI A;
    public TextMeshProUGUI B;
    public TextMeshProUGUI C;
    public TextMeshProUGUI D;

    private int tempNum1, tempNum2;
    private   int choice;
    private char tempOp;
    private int Answer;
    private char[] Operators = { '+', '-', '/', '*' };
    private TextMeshProUGUI[] buttonArray;


    // MENU
    
    // public Button.ButtonClickedEvent AddButton;
    // public Button.ButtonClickedEvent SubButton;
    // public Button.ButtonClickedEvent MulButton;
    // public Button.ButtonClickedEvent DivButton;

    public Button AddButton;
    public Button SubButton;
    public Button  MulButton;
    public Button  DivButton;

    //MATH 
     public GameObject panel;
     // MENU
     public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        // AddButton.onClick.AddListener(delegate {choice =1; });
        // SubButton.onClick.AddListener(delegate { choice =2; });
        // MulButton.onClick.AddListener(delegate { choice =3; });
        // DivButton.onClick.AddListener(delegate { choice =4;});

         AddButton.onClick.AddListener(AddButtonClicked);
        SubButton.onClick.AddListener(SubButtonClicked);
        MulButton.onClick.AddListener(MulButtonClicked);
        DivButton.onClick.AddListener(DivButtonClicked);




        //Menu.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(obj.transform, newRandomNum));
        buttonArray = new TextMeshProUGUI[] { A, B, C, D };
         ChooseGame();

        // Menu.SetActive(true);
        // panel.SetActive(false);
        //GenerateQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            panel.SetActive(false);
        }
    }

      private void GenerateQuestion(char op)
    {
        tempNum1 = GenerateRandomNumber(10);
        Num1.text = tempNum1.ToString();

        tempNum2 = GenerateRandomNumber(10);
        Num2.text = tempNum2.ToString();

        operand.text = op.ToString();

        Answer = CalculateAnswer(tempNum1, tempNum2, op);

        int trueButtonIndex = GenerateRandomNumber(4);
        SetButtonTexts(trueButtonIndex, Answer);
    }

    private void GenerateQuestion2()
    {
        tempNum1 = GenerateRandomNumber(10);
        Num1.text = tempNum1.ToString();

        tempNum2 = GenerateRandomNumber(10);
        Num2.text = tempNum2.ToString();

        tempOp = GenerateOperations(tempNum1, tempNum2);
        operand.text = tempOp.ToString();

        Answer = CalculateAnswer(tempNum1, tempNum2, tempOp);

        int trueButtonIndex = GenerateRandomNumber(4);
        SetButtonTexts(trueButtonIndex, Answer);
    }
    
    // call when true buttoon selected 
    public void buttonFunction(TextMeshProUGUI button)
    {
        print("cliked button ");
        int selectedAnswer = int.Parse(button.text);
        if (selectedAnswer == Answer)
        {
            button.color = Color.green;
        }
        else
        {
            
            button.color = Color.red;

            for (int i = 0; i < buttonArray.Length; i++)
            {
                int buttonText = int.Parse(buttonArray[i].text);
                if (buttonText == Answer)
                {
                    buttonArray[i].color = Color.green;
                    break;
                }
            }
        }

        StartCoroutine(ResetButtons());
    }

    private IEnumerator ResetButtons()
    {
        yield return new WaitForSeconds(1f); // 1 saniye bekle.
        foreach (TextMeshProUGUI button in buttonArray)
        {
            button.color = Color.white; // Tüm butonları beyaz yap.
        }

        //GenerateQuestion(); // Yeni bir soru oluştur.

        ChooseGame();
    }

    private int GenerateRandomNumber(int limit)
    {
        int randomNumber = Random.Range(0, limit);
        return randomNumber;
    }

    private char GenerateOperations(int num1, int num2)
    {
        char[] operators = Operators;

        int randomIndex = GenerateRandomNumber(operators.Length);
        char selectedOperator = operators[randomIndex];
        return selectedOperator;
    }

    // return ansver of created question 
    private int CalculateAnswer(int num1, int num2, char op)
    {
        int answer = 0;
       
        switch (op)
        {
            case '+':
                answer = num1 + num2;
                break;
            case '-':
                answer = num1 - num2;
                break;
            case '/':
                // for dıved by zero exeption 
                  if (num2 != 0)
                answer = num1 / num2;
                else
                {
                    Debug.Log("Division by zero is not allowed!");
                    break;
                   
                }   
                answer = num1 / num2;
                break;
            case '*':
                answer = num1 * num2;
                break;
            default:
                Debug.Log("Invalid operator!");
                break;
        }

        return answer;
    }

    private int GenerateWrongAnswer(int correctAnswer)
    {
        int wrongAnswer = correctAnswer;

        // Doğru cevaptan farklı olacak şekilde rastgele bir sayı üretme
        while (wrongAnswer == correctAnswer)
        {
            wrongAnswer = GenerateRandomNumber(correctAnswer+5);
        }

        return wrongAnswer;
    }

    

    private void SetButtonTexts(int trueButtonIndex, int answer)
{
    int[] answers = new int[4];

    // Doğru cevabı doğrudan bir düğüme ata
    answers[trueButtonIndex] = answer;

    // Diğer düğümler için yanlış cevapları oluştur
    for (int i = 0; i < 4; i++)
    {
        if (i != trueButtonIndex)
        {
            answers[i] = GenerateWrongAnswer(answer);
        }
    }

    A.text = answers[0].ToString();
    B.text = answers[1].ToString();
    C.text = answers[2].ToString();
    D.text = answers[3].ToString();
}

       // Buton tıklama işlemleri
    private void AddButtonClicked()
    {
        print("gfdssssss");
        choice = 1;
        MenuManager();
    }

    private void SubButtonClicked()
    {
        choice = 2;
        MenuManager();
    }

    

    private void DivButtonClicked()
    {
        choice = 3;
        MenuManager();
    }
    private void MulButtonClicked()
    {
        choice = 4;
        MenuManager();
    }

    public void MenuManager()
    {
        ChooseGame();
        Menu.SetActive(false); // Menüyü kapatarak gizle
        panel.SetActive(true); // Oyun panelini açarak göster
       
    }

    

    public void ChooseGame()
    {
        switch (choice)
        {
            case 1:
                GenerateQuestion('+');
                break;
            case 2:
                GenerateQuestion('-');
                break;
            case 3:
                GenerateQuestion('/');
                break;
            case 4:
                GenerateQuestion('*');
                break;
            case 5:
                GenerateQuestion2();
                break;
            default:
                Debug.Log("Invalid choice.");
                break;
        }
      
    }

    
    

}
