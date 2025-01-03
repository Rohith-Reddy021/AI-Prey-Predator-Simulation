using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSensor : MonoBehaviour
{
    public bool comm = false;
    GameObject goat;
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
        if (other.gameObject.CompareTag("Goat"))
        {
            comm = true;
            gameObject.GetComponent<DeerManager>().AddFoodCollectable(other.gameObject);
            goat = other.gameObject;
            StartCoroutine(Hunt());
        }
    }

    void Update()
    {
        if (goat != null)
        {
            float radius = 350f;
            float distanceToGoat = Vector3.Distance(transform.position, goat.transform.position);
            if (distanceToGoat <= radius)
            {
                animator.Play("Run");
            }
        }
    }

    IEnumerator Hunt()
    {
        yield return new WaitForSeconds(0.5f);
        comm = false;
        goat = null;
    }
}
