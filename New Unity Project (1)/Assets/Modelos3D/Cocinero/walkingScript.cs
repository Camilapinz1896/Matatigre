using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingScript: MonoBehaviour
{
    Vector3 target;
    float speed = 1.1f;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

       /* setNewTarget(new Vector3(
            transform.position.x + 10,
            transform.position.y,
            transform.position.z + 10));*/
    }

    // Update is called once per frame
    void Update()
    {
        bool clickCaminar = Input.GetMouseButtonDown(0);
        bool walking = animator.GetBool("walking");

        if (walking == false && clickCaminar)
        {

            animator.SetBool("walking", true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo) == true)
                {
                    setNewTarget(new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z));
                    Vector3 direction = target - transform.position;
                    transform.Translate(direction * speed * Time.deltaTime, Space.World);
                   
                    Debug.Log("Target if:");
                    Debug.Log(target);
                    Debug.Log("direction:");
                    Debug.Log(direction);

                  /*  if (transform.position == target)
                    {
                        walking = false;
                    }
                  */
                }
            


            Debug.Log(transform.position);


        }

        if (walking==true )
        {
            animator.SetBool("walking", false);
        }


    }

    void setNewTarget(Vector3 pNewTarget)
    {
        target = pNewTarget;
        transform.LookAt(target);
        Debug.Log("Target function:");
        Debug.Log(target);
    }
}
