using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningHouse : MonoBehaviour
{
    private void Start()
    {
        // 메서드로 입력
        //StartCoroutine(Cleaning());
        // 매개변수를 직접적으로 넣을 수 있다.
        //StartCoroutine(Cleaning(100));
        // 혹은 문자열로 입력
        StartCoroutine("Cleaning");
        // 문자열로 입력하면 stop도 가능하다=> update에 조건 사용해서 작성

        // 또 다른 지연 방법 invoke
        Invoke("Test", 3f);
    }

    private void Update()
    {
        Debug.Log((int)Time.time);

        if(Time.time >= 12f)
        {
            StopCoroutine("Cleaning");
            Debug.Log("코루틴을 종료합니다.");
        }
    }

    public void Test()
    {
        Debug.Log("소이야 안녕");
    }
    private IEnumerator Cleaning()
    {
        // A방청소
        Debug.Log("A방을 청소합니다");
        // 초단위로 쉴때 WaitForSeconds()
        yield return new WaitForSeconds(5f);
        // B방청소
        Debug.Log("B방을 청소합니다");
        yield return new WaitForSeconds(10f);
        // C방청소
        Debug.Log("C방을 청소합니다");
        // 한 프레임만 쉴때는 null반환 
        yield return null;
        Debug.Log("청소가 끝났습니다");

    }

}
