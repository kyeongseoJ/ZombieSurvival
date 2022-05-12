using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �־��� GUN������Ʈ�� ��ų� ������
// �˸��� �ִϸ��̼��� ����ϰ� IK�� ����� ĳ���� ����� ���� ��ġ�ϵ��� ����
public class PlayerShooter : MonoBehaviour
{
    /// <summary>
    /// ����� ��
    /// </summary>
    public Gun gun;
    /// <summary>
    /// �� ��ġ�� ������
    /// </summary>
    public Transform gunPivot;
    /// <summary>
    /// ���� ���� ������, �޼��� ��ġ�� ����
    /// </summary>
    public Transform leftHandMount;
    /// <summary>
    /// ���� ������ ������, �������� ��ġ�� ����
    /// </summary>
    public Transform rightHandMount;

    /// <summary>
    /// �÷��̾��� �Է�
    /// </summary>
    private PlayerInput PlayerInput;
    /// <summary>
    /// �ִϸ����� ������Ʈ
    /// </summary>
    private Animator playerAnimator;

    // ����� ������Ʈ ��������
    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // ���Ͱ� Ȱ��ȭ �� �� �ѵ� ���� Ȱ��ȭ
        gun.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // ���Ͱ� ��Ȱ��ȭ �� �� �ѵ� ���� ��Ȱ��ȭ
        gun.gameObject.SetActive(false);
    }

    private void Update()
    {
        // �Է��� �����ϰ� ���� �߻��ϰų� ������
        if (PlayerInput.fire)
        {
            // �߻��Է� ���� �� �� �߻�
            gun.Fire();
        }
        else if (PlayerInput.reload)
        {
            if (gun.Reload())
            {
                // ������ ���� �ÿ��� ������ �ִϸ��̼� ���
                playerAnimator.SetTrigger("Reload");
            }
        }
    }

    /// <summary>
    /// ź�� UI ����
    /// </summary>
    private void UpdateUI()
    {
        // UI �Ŵ����� ź�� �ؽ�Ʈ�� źâ�� ź�˰� ���� ��ü ź�� ǥ��
        if(gun != null && UIManager.instance != null)
        {
            UIManager.instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemian);
        }
    }

    // �ִϸ������� IK ���� : ���� ��ü�� �Բ� ���� + ĳ������ ����� �����̿� ��ġ��Ű��
    private void OnAnimatorIK(int layerIndex)
    {
        // ���� ������ gunPivot�� 3D ���� ������ �Ȳ�ġ�� �̵�
        gunPivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        // IK�� ����Ͽ� �޼��� ��ġ�� ȸ���� ���� ���� �����̿� ����
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandMount.rotation);

        // IK�� ����Ͽ� �������� ��ġ�� ȸ���� ���� ������ �����̿� ����
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);

    }
}
