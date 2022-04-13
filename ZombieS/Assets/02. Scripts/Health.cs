using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 체력회복시키는 아이템
public class Health : MonoBehaviour, IItem
{
    // 회복량 
    public float health = 50;

    public void Use(GameObject target)
    {
        // target의 체력을 회복하는 처리
        Debug.Log("체력을 회복했다 : " + health);
    }


}
