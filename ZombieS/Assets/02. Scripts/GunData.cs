using UnityEngine;


// 우클릭 create 시 GunData 항목을 추가하겠다는 코드 작성
// fileName 처음 제시될 이름을 지정 
[CreateAssetMenu(menuName = "Scriptable/GunData", fileName ="Gun Data")]
public class GunData : ScriptableObject
{
    // 오디오 클립 할당
    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리

    
    public float damage = 25; // 공격력

    /// <summary>
    /// 처음에 주어질 전체 탄알
    /// </summary>
    public int startAmmoRemain = 100;
    /// <summary>
    /// 탄창용량
    /// </summary>
    public int magCapacity = 25;

    /// <summary>
    /// 탄알 발사 사이의 간격 0.12f
    /// </summary>
    public float timeBetFire = 0.12f;
    /// <summary>
    /// 재장전 소요 시간 1.8f
    /// </summary>
    public float reloadTime = 1.8f; 


}
