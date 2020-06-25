﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Collider mainCollider;
    private Collider[] allColliders;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    private bool isDead = false;

    private void Awake()
    {
        mainCollider = GetComponent<Collider>();
        allColliders = GetComponentsInChildren<Collider>(true);

        ChangeRagdoll(false);

        defaultPosition = transform.position;
        defaultRotation = transform.rotation;
    }


    private void ChangeRagdoll(bool isRagdoll)
    {
        foreach (var part in allColliders)
        {
            if (part == mainCollider)
            {
                part.enabled = !isRagdoll;
            }
            else
            {
                part.isTrigger = !isRagdoll;

                if (part.attachedRigidbody)
                {
                    part.attachedRigidbody.velocity = Vector3.zero;
                }
            }          
        }

        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Reset()
    {
        transform.position = defaultPosition;
        transform.rotation = defaultRotation;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        ChangeRagdoll(false);
        isDead = false;
    }


    public void SetDead()
    {
        if (!isDead)
        {
            ChangeRagdoll(true);
            GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>().StartSlowMo();
            isDead = true;
        }
    }
}
