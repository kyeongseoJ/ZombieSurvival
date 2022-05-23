using UnityEngine;


// ��Ŭ�� create �� GunData �׸��� �߰��ϰڴٴ� �ڵ� �ۼ�
// fileName ó�� ���õ� �̸��� ���� 
[CreateAssetMenu(menuName = "Scriptable/GunData", fileName ="Gun Data")]
public class GunData : ScriptableObject
{
    // ����� Ŭ�� �Ҵ�
    /// <summary>
    /// �߻� �Ҹ�
    /// </summary>
    public AudioClip shotClip;
    /// <summary>
    /// ������ �Ҹ�
    /// </summary>
    public AudioClip reloadClip;

    /// <summary>
    /// ���� ���ݷ� 25
    /// </summary>
    public float damage = 25; 

    /// <summary>
    /// ó���� �־��� ��ü ź�� 100
    /// </summary>
    public int startAmmoRemain = 100;
    /// <summary>
    /// źâ �뷮 25
    /// </summary>
    public int magCapacity = 25;

    /// <summary>
    /// ź�� �߻� ������ ���� 0.12f ����ӵ� ����
    /// </summary>
    public float timeBetFire = 0.12f;
    /// <summary>
    /// ������ �ҿ� �ð� 1.8f
    /// </summary>
    public float reloadTime = 1.8f; 


}
