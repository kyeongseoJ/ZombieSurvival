using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ݴ��ϴ� ��� ����� IDamageable�� ��ӹ޴´�.
/// </summary>
public interface IDamageable 
{
    /// <summary>
    /// ������ �ۼ��Ǿ��ϴ� �޼���
    /// </summary>
    /// <param name="damage"> ����� ũ�� </param>
    /// <param name="hitPoint"> ���ݴ��� ��ġ </param>
    /// <param name="hitnormal">���ݴ��� ǥ���� ����</param>
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitnormal);
    //IDamageable ==> �������̽� == �԰� 
}
