using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterControllerBasic : NetworkBehaviour
{

    private string moveXButton;
    private string moveZButton;
    [SerializeField]
    private float velMov;
    [SerializeField]
    private float gravity;
    [SerializeField]
    Transform moveT;
    private CharacterController charCon;

    private void Awake()
    {
        charCon = GetComponent<CharacterController>();
    }
    void Start()
    {
        moveXButton = "Horizontal";
        moveZButton = "Vertical";
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
            if (Input.GetAxis(moveXButton) > 0)
                charCon.Move(moveT.right * Time.deltaTime * velMov);
            else if (Input.GetAxis(moveXButton) < 0)
                charCon.Move(-moveT.right * Time.deltaTime * velMov);

            if (Input.GetAxis(moveZButton) > 0)
                charCon.Move(moveT.forward * Time.deltaTime * velMov);
            else if (Input.GetAxis(moveZButton) < 0)
                charCon.Move(-moveT.forward * Time.deltaTime * velMov);
    }
    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }
}