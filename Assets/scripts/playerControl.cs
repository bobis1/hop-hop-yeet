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
    public Rigidbody rb;
    private bool isGrounded;
    public float airStrafe;


    [Header("Virtual Camera")]
    public GameObject FrontVirtualCam;
    public GameObject BackVirtualCam;
    public bool isForward;


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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isForward == true)
            {
                FrontVirtualCam.SetActive(false);
                BackVirtualCam.SetActive(true);
                isForward = false;
            }
            else if (isForward == false)
            {
                FrontVirtualCam.SetActive(true);
                BackVirtualCam.SetActive(false);
                isForward = true;
            }
        }


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
