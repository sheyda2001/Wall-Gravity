using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GearHolder : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gearHolderEventText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gearHolderEventText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gearHolderEventText.enabled = false;
        }
    }

}
