using UnityEngine;


// �÷��̾� ĳ���͸� �����ϱ� ���� ����� �Է� ����
// ������ �Է°��� �ٸ� ������Ʈ�� ����� �� �ֵ��� ����
public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical"; // �յ� �������� ���� ȸ����
    public string rotateAxisName = "Horizontal"; // �¿������ ���� ȸ����
    public string fireButtonName = "Fire1"; // �߻縦 ���� �Է� ��ư �̸�
    public string reloadButtonName = "Reload"; // �������� ���� �Է� ��ư �̸�


    // �ڵ����� ������Ƽ : �� �Ҵ��� ���ο����� ����
    public float move { get; private set; } // ������ ������ �Է°�
    public float rotate { get; private set; } // ������ ȸ�� �Է°�
    public bool fire { get; private set; } // ������ �߻� �Է°�
    public bool reload { get; private set; } // ������ ������ �Է°�

    // �������� ����� �Է��� ����
    void Update()
    {
        // ���ӿ��� ���¿����� ����� �Է��� �������� ����
        if(GameManager.instance != null && GameManager.instance.isGameover)
        {
            move = 0;
            rotate = 0;
            fire = false;
            reload = false;
            return;
        }

        //GetAxis : �Է��� ������ 0 , ���� ������ 1(��/��), -1(��,��)
        // move �� ���� �Է� ����
        move = Input.GetAxis(moveAxisName);
        // rotate �� ���� �Է� ����
        rotate = Input.GetAxis(rotateAxisName);
        // fire �� ���� �Է� ����
        // GetButton: ������ ���ۺ��� ���� �� ������
        fire = Input.GetButton(fireButtonName);
        // reload �� ���� �Է� ���� => ������Ʈ ��ǲ�Ŵ������� r Ű ��� 
        // GetButtonDown/Up : ���� ���� �� �ѹ���
        reload = Input.GetButtonDown(reloadButtonName);

        
    }
}
