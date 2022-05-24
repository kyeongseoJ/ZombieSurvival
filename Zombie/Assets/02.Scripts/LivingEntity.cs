using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 생명체로 동작할 게임 오브젝트들을 위한 뼈대 제공
// 체력, 대미지 받아들이기, 사망 기능, 사망 이벤트를 제공
public class LivingEntity : MonoBehaviour
{
    /// <summary>
    /// 시작체력
    ///</summary>
    public float startingHealth = 100f;
    /// <summary>
    /// 현재체력
    ///</summary>
    public float health;
    /// <summary>
    /// 사망 상태
    ///</summary>
    public bool dead;
    /// <summary>
    /// 사망 시 발동할 이벤트 
    ///</summary>
    //public event Action onDeath;


    /// <summary>
    ///
    ///</summary>

    /// <summary>
    ///
    ///</summary>

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
