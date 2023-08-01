// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class GameChooser : MonoBehaviour
// {
//     // Düğmelere tıklama olaylarını dinlemek için UnityEvent'ler

    
//     public Button.ButtonClickedEvent AddButton;
//     public Button.ButtonClickedEvent SubButton;
//     public Button.ButtonClickedEvent MulButton;
//     public Button.ButtonClickedEvent DivButton;

//     public GameObject panel;
//     // Start is called before the first frame update
//     void Start()
//     {

//         panel.SetActive(true); // Paneli aç

//         // Düğmelere tıklama olaylarını dinleyen fonksiyonları atayın
//         Button addButtonComponent = GameObject.Find("Add").GetComponent<Button>();
//         addButtonComponent.onClick.AddListener(OnAddButtonClick);

//         Button subButtonComponent = GameObject.Find("Sub").GetComponent<Button>();
//         subButtonComponent.onClick.AddListener(OnSubButtonClick);

//         Button mulButtonComponent = GameObject.Find("Mul").GetComponent<Button>();
//         mulButtonComponent.onClick.AddListener(OnMulButtonClick);

//         Button divButtonComponent = GameObject.Find("Div").GetComponent<Button>();
//         divButtonComponent.onClick.AddListener(OnDivButtonClick);
//     }

//     // Düğmeye tıklandığında çağrılacak işlevler
//     public void OnAddButtonClick()
//     {
//         Debug.Log("Add button clicked!");
//         Manager.choice = 1; 
//         panel.SetActive(false); 
//         AddButton.Invoke();
//     }

//     public void OnSubButtonClick()
//     {
//         Debug.Log("Sub button clicked!");
//          Manager.choice=2;
//          panel.SetActive(false);
//         SubButton.Invoke();
//     }

//     public void OnMulButtonClick()
//     {
//         Debug.Log("Mul button clicked!");
//          Manager.choice=3;
//          panel.SetActive(false);
//         MulButton.Invoke();
//     }

//     public void OnDivButtonClick()
//     {
//         Debug.Log("Div button clicked!");
//        Manager.choice=4;
//        panel.SetActive(false);
//         DivButton.Invoke();
//     }
// }
