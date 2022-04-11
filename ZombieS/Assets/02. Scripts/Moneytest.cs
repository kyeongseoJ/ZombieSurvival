using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneytest : MonoBehaviour
{
    private void Start()
    {
        // 새로운 금액 정보 생성
        Moneyinfo info = new Moneyinfo();
        info.won = 10000;
        Debug.Log(info.cheonWon); // 10
        Debug.Log(info.manWon);   // 1


        // manWon프로퍼티에 4의 값 넣어주기
        info.manWon = 4;
        Debug.Log(info.won);       // 40000
        Debug.Log(info.cheonWon);  // 40
        
    }
}
