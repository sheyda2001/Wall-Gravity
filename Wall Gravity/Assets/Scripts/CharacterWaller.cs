using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController.Examples;
public class CharacterWaller : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] float checkDistance = 2;

    //logic
    ExampleCharacterController _characterController;
    ExampleCharacterController characterController
    {
        get
        {
            return _characterController ? _characterController : _characterController = GetComponent<ExampleCharacterController>();
        }
    }

    private void Update()
    {
        ////change by click
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    RaycastHit hit;
        //    Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //    if (Physics.Raycast(ray, out hit, 20, wallLayer))
        //    {
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            float gravityScale = characterController.Gravity.magnitude;
        //            Vector3 newDirection = hit.normal;
        //            characterController.Gravity = -newDirection * gravityScale;
        //        }
        //    }
        //}

        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hit, checkDistance, wallLayer))
        {
            float gravityScale = characterController.Gravity.magnitude;
            Vector3 newDirection = hit.normal;
            characterController.Gravity = -newDirection * gravityScale;

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (-transform.up * checkDistance) + transform.position);
    }
}
