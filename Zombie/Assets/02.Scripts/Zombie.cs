using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//좀비 AI 구현
public class Zombie : LivingEntity
{
    public LayerMask whatIsTarget; //추적 대상 레이어

    private LivingEntity targetEntity; // 추적 대상
    // private NavMeshAgent navMeshAgent//경로 계산 AI 에이전트

    public ParticleSystem hitEffect; //피격 시 재생할 파티클 효과
    public AudioClip deathSound; //오디오 소스 컨포넌트
    public AudioClip hitSound; // 피격 시 재생 할 소리
    
    private Animator zombieAnimator; // 애니메이터 컨포넌트
    private AudioSource zombieaudioPlayer; //오디오 소스 컴포넌트
    private Renderer zombieRenderer; // 랜더러 컴포넌트

    public float damage =20f; // 공격력
    public float timeBetAttack = 0.5f; // 공격 간격

    private float lastAttackTime; // 마지막 공격 시점

    //추적할 대상이 존재하는지 알려주는 프로퍼티
    private bool hasTarget{
        get{
            // 추적할 대상이 존재하고 대상이 사망하지 않았다면
            if(targetEntity != null && !targetEntity.dead){
                return true;
            }
            // 그렇지 않다면
            return false;
        }
    }

    private void Awake(){
        // 초기화
    }

    // 좀비 AI의 초기 스펙을 결정하는 셋업 메서드
    // public void Setup(ZombieData zombieData){

    // }

    private void Start() {
        // 게임 오브젝트 활성화와 동시에 AI 추적 루틴 시작
        zombieAnimator.SetBool("HasTarget", hasTarget);
    }

    
}
