using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletType", order = 1)]
public class BulletType : ScriptableObject
{
    public float force;
    public float speed;
}
