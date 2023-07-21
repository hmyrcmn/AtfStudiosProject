using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
  public float hiz = 5f; 

    private void Update()
    {
        
        transform.Translate(Vector3.down * hiz * Time.deltaTime);
        print(  transform.position.y);
       
       if(transform.position.y<-5.0f){
        Destroy(gameObject);
       
       }
    }
}
