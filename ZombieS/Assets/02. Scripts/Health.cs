using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ü��ȸ����Ű�� ������
public class Health : MonoBehaviour, IItem
{
    // ȸ���� 
    public float health = 50;

    public void Use(GameObject target)
    {
        // target�� ü���� ȸ���ϴ� ó��
        Debug.Log("ü���� ȸ���ߴ� : " + health);
    }


}
