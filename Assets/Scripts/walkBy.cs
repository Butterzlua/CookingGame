using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkBy : MonoBehaviour
{
    public Vector3 userDirection = Vector3.right;
    public static int movespeed = 7;
    public bool walkingBy = true;
    private float timer;
    [SerializeField] private Material[] materials;
    [SerializeField] private SkinnedMeshRenderer mr;
    [SerializeField] private Material invisible;

    void Start()
    {
        ChangeMaterial();
        walkingBy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingBy)
        {
            transform.Translate(userDirection * movespeed * Time.deltaTime);
        }
    }

    public void ChangeMaterial()
    {
        mr.material = materials[Random.Range(0, materials.Length - 1)];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Wall")
        {
            mr.material = invisible;
        }
    }

}
