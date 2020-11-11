using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public Transform airplane;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("input working");

            foreach (Transform child in airplane) 
            {
                Debug.Log("foreach working");

                child.gameObject.SetActive(true);
            }
        }
    }
}
