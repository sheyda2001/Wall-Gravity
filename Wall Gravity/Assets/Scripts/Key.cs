using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "player")
        {

        }
    }
}
