using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewController : MonoBehaviour
{
    private float lookSensitivity = 100f;

    [SerializeField]
    private Transform playerHead;
    [SerializeField]
    private Transform playerBody;

    private float xAxisRotation = 0f;
    private float yAxisRotation = 0f;

    private float turnBuffer = 60f;
    private float rotateSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
        UpdateBodyFacingDirection();
    }

    public void UpdateCameraPosition()
    {
        float lookXPos = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime; //The position of the mouse on the x axis.
        float lookYPos = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime; //The position of the mouse on the y axis.

        xAxisRotation -= lookYPos;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f); //Restricts the head movement to straight up and straight down.
        yAxisRotation += lookXPos;

        playerHead.transform.localRotation = Quaternion.Euler(xAxisRotation, yAxisRotation, 0f);
    }

    public void UpdateBodyFacingDirection() //THIS doesnt work entirely right. 
    {
        if(Vector3.Angle(playerBody.forward, new Vector3(playerHead.transform.forward.x, 0, 0)) > turnBuffer) 
        {
            Debug.Log("Need to rotate!");
            float singleStep = rotateSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(playerBody.forward, new Vector3(playerHead.transform.forward.x, 0,0), singleStep, 0.0f);
            playerBody.transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
            
        }
        else
        {
            Debug.Log("Good");
        }
    }
}
