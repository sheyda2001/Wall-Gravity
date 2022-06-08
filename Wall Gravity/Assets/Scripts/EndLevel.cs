using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject endPanel;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            endPanel.SetActive(true);
            GameManager.singelton.NextLevel();
        }
    }
}
