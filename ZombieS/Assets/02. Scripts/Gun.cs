﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 총을 구현
public class Gun : MonoBehaviour
{
    /// <summary>
    /// 총의 상태를 표현하는 데 사용할 타입을 선언
    /// </summary>
    public enum State
    {
        Ready , // 발사준비 됨
        Empty,// 탄창이 빔
        /// <summary>
        /// 재장전 중
        /// </summary>
        Reloading
    }

    public State state { get; private set; } // 현재 총의 상태

    /// <summary>
    /// 탄알이 발사될 위치
    /// </summary>
    public Transform fireTransform; 

    public ParticleSystem muzzleFlashEffect; // 총알 화염 효과
    public ParticleSystem shellEjectEffect; // 탄피 배출효과

    private LineRenderer bulletLineRenderer; // 탄알 궤적을 그리기 위한 렌더러

    private AudioSource gunAudioPlayer; // 총 소리 재생기

    /// <summary>
    /// 총의 현재 데이터
    /// </summary>
    public GunData gunData; 

    /// <summary>
    /// 사정거리 50f
    /// </summary>
    private float fireDistance = 50f; 
    /// <summary>
    /// 남은 전체 탄알
    /// </summary>
    public int ammoRemian = 100;
    /// <summary>
    /// 현재 탄창 안에 남아있는 탄알
    /// </summary>
    public int magAmmo; 

    /// <summary>
    /// 총을 마지막으로 발사한 시점, 연사속도를 조절해주기 위해 필요
    /// </summary>
    private float lastFireTime; 

    private void Awake()
    {
        // 사용할 컴포넌트 참조 가져오기 => 위에서 private로 선언한 변수의 초기화
        bulletLineRenderer = GetComponent<LineRenderer>();
        gunAudioPlayer = GetComponent<AudioSource>();

        //사용할 점을 두개로 변경
        bulletLineRenderer.positionCount = 2;
        //라인렌더러를 비활성화
        bulletLineRenderer.enabled = false;

    }

    // 컴포넌트의 활성화 <==> OmDisable() 2개 사용해서 오브젝트풀링 적용해서 사용했었다.
    private void OnEnable()
    {
        // 총 상태 초기화
        // 전체 예비 탄알 양을 초기화
        ammoRemian = gunData.startAmmoRemain;

        // 현재 탄창을 가득 채우기
        magAmmo = gunData.magCapacity;

        // 총의 현재 상태를 총을 쏠 준비가 된 상태로 변경
        state = State.Ready;
       // 동일하다. enum의 기능  state = 0;

        // 마지막으로 총을 쏜 시점을 초기화
        lastFireTime = 0;
    }

    /// <summary>
    /// 발사 시도 : 총알이 남아있는지 확인하는 중간과정, 총이 가지고 있는 기능이지만 사용자, 즉, 슈터가 작동 시킨다. 
    /// </summary>
    public void Fire() 
    { 
        // 현재 상태가 발사 가능 상태
        // && 마지막 총 발사 지점에서 gunData.timeBetFire 이상의 시간이 지남
        if(state == State.Ready && Time.time >= lastFireTime + gunData.timeBetFire)
        {
            // 마지막 총 발사 시점 갱신
            lastFireTime = Time.time;
            // 실제 발사 처리 실행
            Shot();
        }
    }

    /// <summary>
    /// 실제 발사 처리
    /// </summary>
    private void Shot()
    {
        // 레이캐스트에 의한 충돌정보를 저장하는 컨테이너
        RaycastHit hit;

        // 탄알이 맞은 곳(==충돌할 위치)을 저장하는 변수
        Vector3 hitPosition = Vector3.zero;

        // 레이캐스트(시작지점, 방향, 충돌 정보 컨테이너, 사정거리)
        if(Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, fireDistance))
        {
            // 레이가 어떤 물체와 충돌한 경우

            // 충돌한 상대방으로부터 오브젝트 가져오기 시도
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            // 상대방으로부터 오브젝트를 가져오는데 성공했다면
            if(target != null)
            {
                // 상대방의 함수를 실행시켜 상대방에 대미지 주기
                target.OnDamage(gunData.damage, hit.point, hit.normal);
            }
            // 레이가 충돌한 위치 저장 : 못가져와도 라인렌더러를 그려줘야한다.
            hitPosition = hit.point;
        }
        else
        {
            // 레이가 다른 물체와 충돌하지 않았다면
            // 탄알이 최대 사정거리까지 날아갔을 때의 위치를 충돌 위치로 사용
            hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
        }

        // 발사 이펙트 재생 시작 hitPosition:충돌한 위치값
        StartCoroutine(ShotEffect(hitPosition));
 
        // 남은 탄알 수를 -1
        magAmmo--; // 감소연산자 -1 씩 감소
        if(magAmmo <= 0)
        {
            // 탄창에 남은 총알이 없다면. 총의 현재 상태를 Empty로 갱신
            state = State.Empty;
        }
    }

    // IEnumerator : 지연시간 코루틴 사용할거면 명시 필수 
    // 발사 이펙트와 소리를 재새앟고 탄알 궤적을 그림
    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        // 총구 화염 재생
        muzzleFlashEffect.Play();
        // 탄피 배출 효과 재생
        shellEjectEffect.Play();

        //총격 소리 재생
        gunAudioPlayer.PlayOneShot(gunData.shotClip);

        //선의 시작점은 총구의 위치
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        //선의 끝점은 입력으로 들어온 충돌 위치
        bulletLineRenderer.SetPosition(1, hitPosition);
        // 라인 렌더러를 활성화 하여 탄알 궤적을 그림
        bulletLineRenderer.enabled = true; //번

        // 0.03초 동안 잠시 처리를 대기 : 번쩍하는 동안만 보여쥐 위한 0.03초
        yield return new WaitForSeconds(0.03f);

        // 라인렌더러를 비활성화하여 탄알 궤적을 지움
        bulletLineRenderer.enabled = false; //쩍
    }

    /// <summary>
    /// 재장전 시도
    /// </summary>
    public bool Reload()
    {
        if(state == State.Reloading || ammoRemian <= 0 || magAmmo >= gunData.magCapacity)
        {
            // 이미 재장전 중이거나 남은 탄알이 없거나
            // 탄창에 탄알이 이미 가득한 경우 재장전 할 수 없음
            return false;
        }
        // 재장전 처리 시작
        StartCoroutine(ReloadRoutine());
        return true; // 재장전 됬다고 알림
    }
    
    /// <summary>
    /// 실제 재장전 처리를 진행
    /// </summary>
    private IEnumerator ReloadRoutine()
    {
        // 현재 상태를 재장전 상태로 전환
        state = State.Reloading;

        // 재장전 소리 재생
        gunAudioPlayer.PlayOneShot(gunData.reloadClip);

        // 재장전 소요시간만큼 쉬기
        yield return new WaitForSeconds(gunData.reloadTime);

        // 탄창에 채울 탄알 계산
        int ammoToFill = gunData.magCapacity - magAmmo;

        // 탄창에 채워야 할 탄알이 남은 탄알보다 많다면
        // 채워야할 탄알 수를 남은 탄알 수에 맞춰 줄임
        if(ammoRemian < ammoToFill)
        {
            ammoToFill = ammoRemian;
        }

        // 탄창을 채움
        magAmmo += ammoToFill;
        // 남은 탄알에서 탄창에 채운만큼 탄알을 뺌
        ammoRemian -= ammoToFill;

        //총의 현재상태를 발사 준비된 상태로 변경
        state = State.Ready;
    }
    
    // 만약 저격총을 만든다면? 확대경 필요 ==> 총의 상태를 표현하는 enum 추가,
}
