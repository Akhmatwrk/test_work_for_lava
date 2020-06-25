using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    EnemyController controller = null;

    private void Start()
    {
        controller = gameObject.GetComponentInParent<EnemyController>() as EnemyController;
        if (controller == null)
        {
            Debug.LogError("Not found EnemyController");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            if (!controller.IsDead())
            {
                controller.SetDead();
            }

            Vector3 bulletDirection = (bullet.transform.rotation * Vector3.forward);

            Debug.DrawRay(transform.position, bulletDirection, Color.red);

            GetComponent<Rigidbody>().AddForce(bullet.GetBulletForce() * bulletDirection);
        }        
    }
}
