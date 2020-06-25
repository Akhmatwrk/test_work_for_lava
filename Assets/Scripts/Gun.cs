using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;

    public void Fire(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - gun.transform.position).normalized;
        GameObject projectileObj = Instantiate(projectile, gun.transform.position, Quaternion.LookRotation(direction));
        projectileObj.transform.parent = gun.transform;
    }
}
