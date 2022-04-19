using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공격당하는 모든 대상은 IDamageable을 상속받는다.
/// </summary>
public interface IDamageable 
{
    /// <summary>
    /// 무조건 작성되야하는 메서드
    /// </summary>
    /// <param name="damage"> 대미지 크기 </param>
    /// <param name="hitPoint"> 공격당한 위치 </param>
    /// <param name="hitnormal">공격당한 표면의 방향</param>
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitnormal);
    //IDamageable ==> 인터페이스 == 규격 
}
