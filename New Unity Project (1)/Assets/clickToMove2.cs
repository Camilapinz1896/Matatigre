using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickToMove2 : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Animator anim;


    public Vector3 targetPos;
    public LayerMask groundLayer;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            moveTowardsClick();
        }
    }

    private void moveTowardsClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            if(targetPos!=hit.point)
            {
                targetPos = hit.point;
            }

            navAgent.SetDestination(targetPos);
        }
    }

}
