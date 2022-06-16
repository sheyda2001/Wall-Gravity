using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Port : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI EventText;
    [SerializeField] private GameObject exitPort;
    [SerializeField] private Port ExitPortComp;
    [SerializeField] private GameObject Player;
    [SerializeField] private Player playerComp;
    [SerializeField] private Camera mainCamera;

    [SerializeField] private Vector2 newGravity;

    [SerializeField] private Vector3 rotation;
    private bool isCollided;

    private void Awake()
    {
        ExitPortComp = exitPort.GetComponent<Port>();
        playerComp = Player.GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollided)
        {
            Teleport();
            StartCoroutine(ChangeGravity());
        }
    }

    private void Teleport()
    {
        Player.transform.DOMove(exitPort.transform.GetChild(0).transform.position, 0);
        ExitPortComp.enabled = true;
    }

    private IEnumerator ChangeGravity()
    {
        yield return new WaitForSeconds(.1f);
        Physics.gravity = ExitPortComp.newGravity;
        if (newGravity.x == 0)
        {
            playerComp.gravityAxis = 0;
            playerComp.gravityDirection = newGravity.y > 0 ? 1 : -1;
        }
        else
        {
            playerComp.gravityAxis = 1;
            playerComp.gravityDirection = newGravity.x > 0 ? 1 : -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventText.enabled = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventText.enabled = false;
        }
    }
}
