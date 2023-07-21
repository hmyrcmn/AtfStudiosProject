using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(25*Time.deltaTime,0.0f,0.0f);
    }
   private void OnTriggerEnter(Collider other ){
        if(other.tag=="Player"){
            print("coin");
            FindObjectOfType<ses>().gameObject.transform.GetChild(1).gameObject.SetActive(true);

            PlayerManager.numberOfCoins+=1;
            print(PlayerManager.numberOfCoins);
            
            Destroy(gameObject);

        }
    }
}
