﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Customer Spawning")]
    private float timer;
    public bool Paused = false;
    [SerializeField] private walkBy customer;
    [SerializeField] private Transform spawnPoint, endPoint;
    [SerializeField] private float minimumSpawnTime = 10f, maximumSpawntime = 25f;
    //private Vector3 playerPos;
    [SerializeField] private CodeyMove Chef, Waiter;
    [SerializeField] private CinemachineVirtualCamera cam;
    private bool IsChef, IsWaiter;
    //public static GameManager instance;
    [Header("ScrollZoom")]
    [SerializeField] private float cameraDistanceMax = 70f, cameraDistanceMin = 12f, scrollSpeed = 2f;
    [Header("2D Cooking")]
    public GameObject Cooking;
    public bool IsCooking;
    public Camera m_MainCamera, m_CameraTwo;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }

    //    //tried using but no change 
    //    DontDestroyOnLoad(gameObject);
    //    DontDestroyOnLoad(customer.gameObject);
    //    DontDestroyOnLoad(spawnPoint.gameObject);
    //    DontDestroyOnLoad(endPoint.gameObject);
    //    DontDestroyOnLoad(cam.gameObject);
    //    DontDestroyOnLoad(Chef.transform);
    //    DontDestroyOnLoad(Chef.gameObject);
    //}


    private void Start()
    {
        IsChef = true;
        IsWaiter = false;
        timer = Random.Range(minimumSpawnTime, maximumSpawntime);
        ToggleBetween2D3D();
        ToggleBetween2D3D();
        ToggleBetween2D3D();
        IsCooking = true;
    }

    //Code for zooming in and out using scroll wheel
    private void OnGUI()
    {
            cam.m_Lens.FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            cam.m_Lens.FieldOfView = Mathf.Clamp(cam.m_Lens.FieldOfView, cameraDistanceMin, cameraDistanceMax);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            CreateCustomer();
            timer = Random.Range(minimumSpawnTime, maximumSpawntime);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!IsCooking)
            {
                SwitchCharacter();
            }

        }
        if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            ToggleBetween2D3D();
        }
    }

    public void ToggleBetween2D3D()
    {
        // if (!Input.GetMouseButton(0))
        

            if (m_MainCamera.gameObject.activeSelf)
            {
                IsCooking = true;
                //Enable the second Camera
                //m_CameraTwo.enabled = true;
                m_CameraTwo.gameObject.SetActive(true);

                //The Main first Camera is disabled
                //m_MainCamera.enabled = false;
                m_MainCamera.gameObject.SetActive(false);

            }
            //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
            else if (!m_MainCamera.gameObject.activeSelf)
            {
                IsCooking = false;
                //Disable the second camera
                //m_CameraTwo.enabled = false;
                m_CameraTwo.gameObject.SetActive(false);

                //Enable the Main Camera
                //m_MainCamera.enabled = true;
                m_MainCamera.gameObject.SetActive(true);
            }
        
    }

    private void CreateCustomer()
    {
        if(customer != null)
        {
            //Instantiate(customer, spawnPoint.position, Quaternion.identity);
            customer.gameObject.transform.position = spawnPoint.position;
            customer.ChangeMaterial();
        }       
    }
    public void SwitchCharacter()
    {
        if (IsChef)
        {
            IsChef = false;
            IsWaiter = true;
            Waiter.enabled = true;
            Chef.enabled = false;
            cam.LookAt = Waiter.transform;
            cam.Follow = Waiter.transform;
        } 
        else if (IsWaiter)
        {
            IsChef = true;
            IsWaiter = false;
            Waiter.enabled = false;
            Chef.enabled = true;
            cam.LookAt = Chef.transform;
            cam.Follow = Chef.transform;
        }
    }
}