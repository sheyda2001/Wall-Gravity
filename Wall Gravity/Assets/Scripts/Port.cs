using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Port : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EventText;
    [SerializeField] private GameObject exitPort;
    [SerializeField] private Port exitPortComp;
    [SerializeField] private GameObject Player;
    [SerializeField] private Player playerComp;
    [SerializeField] private Camera mainCamera;

    private float GravityValue = 9.81f;
    [SerializeField] private int GravityDirection;
    [SerializeField] private int GravityAxis;

    public bool isPortable = true;

    [SerializeField] private Vector3 rotation;
    private bool isCollided;

    private void Awake()
    {
        exitPortComp = exitPort.GetComponent<Port>();   
        playerComp = Player.GetComponent<Player>();
    }

    private void Update()
    {
        if (isCollided && Input.GetKeyDown(KeyCode.E))
            print("test");
        if (Input.GetKeyDown(KeyCode.E) && isCollided && isPortable)
        {
            Teleport();
            StartCoroutine(ChangeGravity());
        }
    }

    private void Teleport()
    {
        Player.transform.DOMove(exitPort.transform.GetChild(0).transform.position, 0);
        exitPortComp.enabled = true;
    }

    private IEnumerator ChangeGravity()
    {
        yield return new WaitForSeconds(.1f);

        Physics.gravity *= -1;
        playerComp.gravityValue *= -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventText.enabled = true;
            isCollided = true;
            exitPortComp.isPortable = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventText.enabled = false;
            isCollided = false;
            StartCoroutine(EnablePortability());
        }
    }

    public IEnumerator EnablePortability()
    {
        yield return new WaitForSeconds(.3f);
        print("executed");
        exitPortComp.isPortable = true;
    }

}
