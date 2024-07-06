using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CodeyMove : MonoBehaviour
{
    public float Speed = 5f;
    public Animator anim;
    public bool running = false;
    public bool canMove = true;
    public Vector3 move;
    public float _rotationSpeed = 50f;
    private Rigidbody rb;
    private float speed;
    private NavMeshAgent Agent;

    //[Header("Animation")]
    //[SerializeField] private Animation idle, walk;
    void Start()
    {
        anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        speed = anim.speed;
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
    void Update()
    {
        if(Agent.speed <= 17)
        {
            Agent.speed = 18;
        }
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Camera cam = GameManager.instance.m_MainCamera;
                if (!cam.gameObject.activeSelf) return;
                if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    Agent.destination = hit.point;
                }
            }
            speed = Agent.velocity.magnitude;
           //anim.SetBool("isWalking", speed != 0);
           //anim.SetBool("isIdle", speed == 0);

            //float vertical = Input.GetAxis("Vertical");
            //float horizontal = Input.GetAxis("Horizontal");
            //Vector3 rotation = new Vector3(0, horizontal * _rotationSpeed * Time.deltaTime, 0);
            //move = transform.forward * Speed * Time.deltaTime * vertical;
            //transform.Rotate(rotation);
            //rb.velocity += move;
            //speed = rb.velocity.magnitude;
            //anim.SetBool("isWalking", move != Vector3.zero);

        }

        //    if(Input.GetKeyDown(KeyCode.Space))
        //   {
        //        canMove = !canMove;
        //        rb.velocity = Vector3.zero;
        //        speed = 0;
        //        Debug.Log(speed);
        //    }
        if (speed < 0.1)
        {
            //anim.Play(idle.name);
            anim.SetBool("isidle", true);
            anim.SetBool("isWalking", false);
        }
        else
        {
            //anim.Play(walk.name);
            anim.SetBool("isidle", false);
            anim.SetBool("isWalking", true);
        }
    }
}