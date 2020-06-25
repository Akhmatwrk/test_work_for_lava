using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletType bullet;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bullet.speed);
    }

    public float GetBulletForce()
    {
        return bullet.force;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
