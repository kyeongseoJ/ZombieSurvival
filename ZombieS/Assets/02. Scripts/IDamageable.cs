using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 공격당하는 모든 대상
public interface IDamageable 
{
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitnormal);
}
