using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 총을 구현
public class Gun : MonoBehaviour
{
    // 총의 상태를 표현하는 데 사용할 타입을 선언
    public enum State
    {
        Ready , // 발사준비 됨
        Empty,// 탄창이 빔
        Reloading// 재장전 중
    }

    public State state { get; private set; } // 현재 총의 상태

    public Transform fireTransform; // 탄알이 발사될 위치

    public ParticleSystem muzzleFlashEffect; // 총알 화염 효과
    public ParticleSystem shellEjectEffect; // 탄피 배출효과

    private LineRenderer bulletLineRenderer; // 탄알 궤적을 그리기 위한 렌더러

    private AudioSource gunAudioPlayer; // 총 소리 재생기

    public GunData gunData; // 총의 현재 데이터

    private float fireDirection = 50f; // 사정거리

    public int ammoRemian = 100; // 남은 전체 탄알
    public int magAmmo; // 현재 남아있는 탄알

    private float lastFireTime; // 총을 마지막으로 발사한 시점

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

    private void OnEnable()
    {
        // 총 상태 초기화
        // 전체 예비 탄알 양을 초기화
        ammoRemian = gunData.startAmmoRemain;

        // 현재 탄창을 가득 채우기
        magAmmo = gunData.magCapacity;

        // 총의 현재 상태를 총을 쏠 준비가 된 상태로 변경
        state = State.Ready;

        // 마지막으로 총을 쏜 시점을 초기화
        lastFireTime = 0;
    }

    // 발사 시도 : 총알이 남아있는지 확인하는 중간과정
    private void Fire()
    {
        // 현재 상태가 발사 가능 상태 && 마지막 총 발사 지점에서 gunData.timeBetFire 이상의 시간이 지남
        // 마지막 총 발사 시점 갱신
        // 실제 발사 처리 실행
    }

    // 실제 발사 처리
    private void Shot()
    {
        // 레이캐스트에 의한 충돌정보를 저장하는 컨테이너
        // 탄알이 맞은 곳을 저장하는 변수
        // 레이캐스트(시작지점, 방향, 충돌 정보 컨테이너, 사정거리)
        
        // 레이가 어떤 물체와 충돌한 경우
        // 충돌한 상대방으로부터 오브젝트 가져오기 시도
        // 상대방으로부터 오브젝트를 가져오는데 성공했다면
        // 상대방의 함수를 실행시켜 상대방에 대미지 주기
        // 레이가 충돌한 위치 저장
    }

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

        // 0.03초 동안 잠시 처리를 대기
        yield return new WaitForSeconds(0.03f);

        // 라인렌더러를 비활성화하여 탄알 궤적을 지움
        bulletLineRenderer.enabled = false; //쩍
    }

    // 재장전 시도
    private bool Reload()
    {
        return false;
    }

    // 실제 재장전 처리르 ㄹ진행
    private IEnumerable ReloadRoutine()
    {
        // 현재 상태를 재장전 상태로 전환
        state = State.Reloading;

        // 재장전 소요시간만큼 쉬기
        yield return new WaitForSeconds(gunData.reloadTime);

        //총의 현재상태를 발사준비된 상태로 변경
        state = State.Ready;
    }
    
}
