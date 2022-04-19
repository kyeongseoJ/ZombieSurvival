using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ����
public class Gun : MonoBehaviour
{
    /// <summary>
    /// ���� ���¸� ǥ���ϴ� �� ����� Ÿ���� ����
    /// </summary>
    public enum State
    {
        Ready , // �߻��غ� ��
        Empty,// źâ�� ��
        Reloading// ������ ��
    }

    public State state { get; private set; } // ���� ���� ����

    public Transform fireTransform; // ź���� �߻�� ��ġ

    public ParticleSystem muzzleFlashEffect; // �Ѿ� ȭ�� ȿ��
    public ParticleSystem shellEjectEffect; // ź�� ����ȿ��

    private LineRenderer bulletLineRenderer; // ź�� ������ �׸��� ���� ������

    private AudioSource gunAudioPlayer; // �� �Ҹ� �����

    public GunData gunData; // ���� ���� ������

    /// <summary>
    /// �����Ÿ�
    /// </summary>
    private float fireDistance = 50f; 
    /// <summary>
    /// ���� ��ü ź��
    /// </summary>
    public int ammoRemian = 100;
    /// <summary>
    /// ���� �����ִ� ź��
    /// </summary>
    public int magAmmo; 

    /// <summary>
    /// ���� ���������� �߻��� ����
    /// </summary>
    private float lastFireTime; 

    private void Awake()
    {
        // ����� ������Ʈ ���� �������� => ������ private�� ������ ������ �ʱ�ȭ
        bulletLineRenderer = GetComponent<LineRenderer>();
        gunAudioPlayer = GetComponent<AudioSource>();

        //����� ���� �ΰ��� ����
        bulletLineRenderer.positionCount = 2;
        //���η������� ��Ȱ��ȭ
        bulletLineRenderer.enabled = false;

    }

    private void OnEnable()
    {
        // �� ���� �ʱ�ȭ
        // ��ü ���� ź�� ���� �ʱ�ȭ
        ammoRemian = gunData.startAmmoRemain;

        // ���� źâ�� ���� ä���
        magAmmo = gunData.magCapacity;

        // ���� ���� ���¸� ���� �� �غ� �� ���·� ����
        state = State.Ready;

        // ���������� ���� �� ������ �ʱ�ȭ
        lastFireTime = 0;
    }

    // �߻� �õ� : �Ѿ��� �����ִ��� Ȯ���ϴ� �߰�����
    private void Fire()
    {
        // ���� ���°� �߻� ���� ����
        // && ������ �� �߻� �������� gunData.timeBetFire �̻��� �ð��� ����
        if(state == State.Ready && Time.time >= lastFireTime + gunData.timeBetFire)
        {
            // ������ �� �߻� ���� ����
            lastFireTime = Time.time;
            // ���� �߻� ó�� ����
            Shot();
        }
    }

    // ���� �߻� ó��
    private void Shot()
    {
        // ����ĳ��Ʈ�� ���� �浹������ �����ϴ� �����̳�
        RaycastHit hit;
        // ź���� ���� ��(==�浹�� ��ġ)�� �����ϴ� ����
        Vector3 hitPosition = Vector3.zero;

        // ����ĳ��Ʈ(��������, ����, �浹 ���� �����̳�, �����Ÿ�)
        if(Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, fireDistance))
        {
            // ���̰� � ��ü�� �浹�� ���

            // �浹�� �������κ��� ������Ʈ �������� �õ�
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            // �������κ��� ������Ʈ�� �������µ� �����ߴٸ�
            if(target != null)
            {
                // ������ �Լ��� ������� ���濡 ����� �ֱ�
                target.OnDamage(gunData.damage, hit.point, hit.normal);
            }
            // ���̰� �浹�� ��ġ ����
            hitPosition = hit.point;
        }
        else
        {
            // ���̰� �ٸ� ��ü�� �浹���� �ʾҵ���
            // ź���� �ִ� �����Ÿ����� ���ư��� ���� ��ġ�� �浹 ��ġ�� ���
            hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
        }

        // �߻� ����Ʈ ��� ����
        StartCoroutine(ShotEffect(hitPosition));
 
        // ���� ź�� ���� -1
        magAmmo--;
        if(magAmmo <= 0)
        {

            state = State.Empty;
        }
    }

    // �߻� ����Ʈ�� �Ҹ��� ����۰� ź�� ������ �׸�
    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        // �ѱ� ȭ�� ���
        muzzleFlashEffect.Play();
        // ź�� ���� ȿ�� ���
        shellEjectEffect.Play();

        //�Ѱ� �Ҹ� ���
        gunAudioPlayer.PlayOneShot(gunData.shotClip);

        //���� �������� �ѱ��� ��ġ
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        //���� ������ �Է����� ���� �浹 ��ġ
        bulletLineRenderer.SetPosition(1, hitPosition);
        // ���� �������� Ȱ��ȭ �Ͽ� ź�� ������ �׸�
        bulletLineRenderer.enabled = true; //��

        // 0.03�� ���� ��� ó���� ���
        yield return new WaitForSeconds(0.03f);

        // ���η������� ��Ȱ��ȭ�Ͽ� ź�� ������ ����
        bulletLineRenderer.enabled = false; //½
    }

    // ������ �õ�
    private bool Reload()
    {
        return false;
    }

    // ���� ������ ó���� ������
    private IEnumerable ReloadRoutine()
    {
        // ���� ���¸� ������ ���·� ��ȯ
        state = State.Reloading;

        // ������ �ҿ�ð���ŭ ����
        yield return new WaitForSeconds(gunData.reloadTime);

        //���� ������¸� �߻��غ�� ���·� ����
        state = State.Ready;
    }
    
}
