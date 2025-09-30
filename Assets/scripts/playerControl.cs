using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Cinemachine;

public class playerControl : MonoBehaviour
{
    [Header("Player")]
    public Vector3 playerPosion;
    public float playerSpeed;
    public float playerJump;
    public float playerDash;
    public Rigidbody rb;
    private bool isGrounded;
    public float airStrafe;



    [Header("Virtual Camera")]
    public GameObject FrontVirtualCam;
    public GameObject BackVirtualCam;
    public GameObject LeftVirtualCam;
    public GameObject RightVirtualCam;
    public GameObject currentCam;



    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();


        if (Input.GetKey(KeyCode.W))
        {
            if (isGrounded == false)
            {
                playerPosion = transform.position;
                playerPosion.z += playerSpeed * airStrafe;
            }
            if (isGrounded == true)
            {
                playerPosion = transform.position;
                playerPosion.z += playerSpeed;
            }

            //transform.position = playerPosion;
            //rb.AddForce(playerPosion);
            rb.MovePosition(playerPosion);

        }
        if (Input.GetKey(KeyCode.S))
        {
            if (isGrounded == false)
            {
                playerPosion = transform.position;
                playerPosion.z -= playerSpeed * airStrafe;
            }
            if (isGrounded == true)
            {
                playerPosion = transform.position;
                playerPosion.z -= playerSpeed;
            }

            //transform.position = playerPosion;
            //rb.AddForce(playerPosion);
            rb.MovePosition(playerPosion);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (isGrounded == false)
            {
                playerPosion = transform.position;
                playerPosion.x -= playerSpeed * airStrafe;
            }
            if (isGrounded == true)
            {
                playerPosion = transform.position;
                playerPosion.x -= playerSpeed;
            }

            //transform.position = xplayerPosion;
            //rb.AddForce(playerPosion);
            rb.MovePosition(playerPosion);

        }
        if (Input.GetKey(KeyCode.D))
        {
            if (isGrounded == false)
            {
                playerPosion = transform.position;
                playerPosion.x += playerSpeed * airStrafe;
            }
            if (isGrounded == true)
            {
                playerPosion = transform.position;
                playerPosion.x += playerSpeed;
            }
            rb.MovePosition(playerPosion);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // playerPosion = transform.position;
            //playerPosion.y += playerJump
            if (isGrounded == true)
            {
                rb.AddForce(transform.up * playerJump, ForceMode.Impulse);
                Debug.Log("Jump");
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(transform.forward * playerDash);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentCam.SetActive(false);
            currentCam = FrontVirtualCam;
            currentCam.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentCam.SetActive(false);
            currentCam = BackVirtualCam;
            currentCam.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCam.SetActive(false);
            currentCam = LeftVirtualCam;
            currentCam.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCam.SetActive(false);
            currentCam = RightVirtualCam;
            currentCam.SetActive(true);
        }

    }
    private void isGroundedMovement() {
        if (isGrounded == false)
        {
            playerPosion = transform.position;
            playerPosion.x -= playerSpeed * airStrafe;
        }
        if (isGrounded == true)
        {
            playerPosion = transform.position;
            playerPosion.x -= playerSpeed;
        }
        
        rb.MovePosition(playerPosion);

    }
        void OnCollisionExit(Collision collision)
        {
            isGrounded = false;
        }

        void OnCollisionEnter(Collision collision)
        {
            isGrounded = true;
        }
}
