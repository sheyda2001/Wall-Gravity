using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private bool hasGravity;

    private void Update()
    {

    }

    private void changeGravity()
    {
        hasGravity = !hasGravity;
    }
}
