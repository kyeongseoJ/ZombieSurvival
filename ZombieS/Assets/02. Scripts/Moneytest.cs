using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneytest : MonoBehaviour
{
    private void Start()
    {
        // ���ο� �ݾ� ���� ����
        Moneyinfo info = new Moneyinfo();
        info.won = 10000;
        Debug.Log(info.cheonWon); // 10
        Debug.Log(info.manWon);   // 1


        // manWon������Ƽ�� 4�� �� �־��ֱ�
        info.manWon = 4;
        Debug.Log(info.won);       // 40000
        Debug.Log(info.cheonWon);  // 40
        
    }
}
