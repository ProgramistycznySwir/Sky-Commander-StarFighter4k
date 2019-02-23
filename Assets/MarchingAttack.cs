using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingAttack : MonoBehaviour
{
    public float damage;

    public void DealDamage(Stats stats)
    {
        stats.TakeDamage(damage);
    }
}
