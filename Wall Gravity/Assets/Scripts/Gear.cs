using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "player")
        {

        }   
    }
}
