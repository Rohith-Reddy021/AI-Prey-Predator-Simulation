using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSensor : MonoBehaviour
{
    public bool comm = false;
    GameObject bear;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
        gameObject.GetComponent<DeerManager>().AddWaterCollectable(other.gameObject);
        }
        if (other.gameObject.CompareTag("Food"))
        {
        gameObject.GetComponent<DeerManager>().AddFoodCollectable(other.gameObject);
        }
        if(other.gameObject.CompareTag("Player")){
            comm = true;
            bear=other.gameObject;
            StartCoroutine(Hunt());
        }
    }

    void Update()
    {
        if (bear != null)
        {
            float radius = 150f;
            float distanceToGoat = Vector3.Distance(transform.position, bear.transform.position);
            if (distanceToGoat <= radius)
            {
                animator.Play("Run");
            }
        }
    }

    IEnumerator Hunt()
    {
        yield return new WaitForSeconds(2f);
        comm = false;
    }
}
