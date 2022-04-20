using UnityEngine;


// ��Ŭ�� create �� GunData �׸��� �߰��ϰڴٴ� �ڵ� �ۼ�
// fileName ó�� ���õ� �̸��� ���� 
[CreateAssetMenu(menuName = "Scriptable/GunData", fileName ="Gun Data")]
public class GunData : ScriptableObject
{
    // ����� Ŭ�� �Ҵ�
    public AudioClip shotClip; // �߻� �Ҹ�
    public AudioClip reloadClip; // ������ �Ҹ�

    
    public float damage = 25; // ���ݷ�

    /// <summary>
    /// ó���� �־��� ��ü ź��
    /// </summary>
    public int startAmmoRemain = 100;
    /// <summary>
    /// źâ�뷮
    /// </summary>
    public int magCapacity = 25;

    /// <summary>
    /// ź�� �߻� ������ ���� 0.12f
    /// </summary>
    public float timeBetFire = 0.12f;
    /// <summary>
    /// ������ �ҿ� �ð� 1.8f
    /// </summary>
    public float reloadTime = 1.8f; 


}
