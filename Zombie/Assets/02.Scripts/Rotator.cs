using UnityEngine;

// 실시간 단순 회전 스크립트 : 아이템에 적용
public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;

    private void Update() {
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }
}
