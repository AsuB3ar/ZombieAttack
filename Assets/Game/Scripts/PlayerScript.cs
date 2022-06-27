using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameManager gameManager;

    public float moveSpeed;
    private int kill;
    public int Kill
    {
        get => kill;
        set
        {
            kill = value;
            if(kill > 0 && kill % 5 == 0)
            {
                Level += 1;
            }
        }
    }
    public int Level = 1;

    private Rigidbody myRigidbody;


    private Vector3 moveInput;
    private Vector3 moveVolocity;

    private Camera mainCamera;

    public GunScript theGun;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        moveVolocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if(Input.GetMouseButtonDown(0))
            theGun.isFiring = true;

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;

        
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVolocity;
    }
}
