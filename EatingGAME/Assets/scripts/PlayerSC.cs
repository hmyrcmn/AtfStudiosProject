using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSC : MonoBehaviour
{
    public float velocity = 5f;


    private void Update()
    {
        float movingX = Input.GetAxis("Horizontal");
        float updateLoc = transform.position.x + movingX * velocity * Time.deltaTime;
        updateLoc = Mathf.Clamp(updateLoc, -8f, 8f);
        transform.position = new Vector3(updateLoc, transform.position.y, transform.position.z);
    }

    
}
