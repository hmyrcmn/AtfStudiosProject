using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ses : MonoBehaviour
{
    public GameObject coinSes;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i!=0)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!coinSes.GetComponent<AudioSource>().isPlaying)
        {
            coinSes.SetActive(false);
        }
    }
}
