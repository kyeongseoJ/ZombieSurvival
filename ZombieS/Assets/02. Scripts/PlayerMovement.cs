using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� �Է¿� ���� �÷��̾� ĳ���͸� �����̴� ��ũ��Ʈ
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �յ� ������ �ӵ�
    public float rotateSpped = 180f; // �¿� ȸ�� �ӵ�

    private PlayerInput playerInput; // �÷��̾� �Է��� �˷��ִ� ������Ʈ

    [SerializeField] private Rigidbody playerRigidbody; // �÷��̾� ĳ������ ������ٵ�
    private Animator playerAnimator; // �÷��̾� ĳ������ �ִϸ�����

    // �ð�Ȯ��(test)
    float time2 = 0f;
    void Start()
    {

        //����� ������Ʈ���� ���� ��������
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate�� �������� �ֱ⿡ ���� �����
    private void FixedUpdate()
    {
        // �������� �ֱ⸶�� ������, ȸ��, �ִϸ��̼� ó�� ����
        // ȸ�� ����
        Rotate();
        // ������ ����
        Move();
        // �Է°��� ���� �ִϸ������� Move �Ķ���� �� ����
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    // �Է°��� ���� ĳ���͸� �յڷ� ������
    private void Move()
    {
        // ��������� �̵��� �Ÿ� ���
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        // ������ٵ� �̿��� ���� ������Ʈ ��ġ�� ����
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // �Է°��� ���� ĳ���͸� �¿�� ȸ��
    private void Rotate()
    {
        // ��������� ȸ���� ��ġ ���
        float turn = playerInput.rotate * rotateSpped * Time.deltaTime;
        // ������ٵ� �̿��� ���� ������Ʈ ȸ�� ����
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }

    private void Update()
    {
        // �ð�Ȯ���ϴ� �ڵ� (test)
        Debug.Log("Time : " + (int)Time.time);
        time2 += Time.deltaTime;
        Debug.Log("deltaTime : " + (int)time2);
        Debug.Log("FixedUpdate : " + (float)Time.fixedDeltaTime);
    }
}
