using UnityEngine;


// 플레이어 캐릭터를 조작하기 위한 사용자 입력 감지
// 감지된 입력값을 다른 컴포넌트가 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical"; // 앞뒤 움직임을 위한 회전축
    public string rotateAxisName = "Horizontal"; // 좌우반전을 위한 회전축
    public string fireButtonName = "Fire1"; // 발사를 위한 입력 버튼 이름
    public string reloadButtonName = "Reload"; // 재장전을 위한 입력 버튼 이름


    // 자동구현 프로퍼티 : 값 할당은 내부에서만 가능
    public float move { get; private set; } // 감지된 움직임 입력값
    public float rotate { get; private set; } // 감지된 회전 입력값
    public bool fire { get; private set; } // 감지된 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값

    // 매프레임 사용자 입력을 감지
    void Update()
    {
        // 게임오버 상태에서는 사용자 입력을 감지하지 않음
        if(GameManager.instance != null && GameManager.instance.isGameover)
        {
            move = 0;
            rotate = 0;
            fire = false;
            reload = false;
            return;
        }

        //GetAxis : 입력이 없으면 0 , 뭔가 누르면 1(상/우), -1(하,좌)
        // move 에 관한 입력 감지
        move = Input.GetAxis(moveAxisName);
        // rotate 에 관한 입력 감지
        rotate = Input.GetAxis(rotateAxisName);
        // fire 에 관한 입력 감지
        // GetButton: 누르기 시작부터 손을 뗄 때까지
        fire = Input.GetButton(fireButtonName);
        // reload 에 관한 입력 감지 => 프로젝트 인풋매니저가서 r 키 등록 
        // GetButtonDown/Up : 누른 순간 딱 한번만
        reload = Input.GetButtonDown(reloadButtonName);

        
    }
}
