using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneyinfo : MonoBehaviour
{

    public float manWon
    {
        get { return m_won * 0.0001f; }
        set
        {
            if (value <= 0) m_won = 0; // 들어온 금액이 0보다 작다면 패스
            else m_won = value * 10000f;
        }
    }

    public float cheonWon
    {
        get { return m_won * 0.001f; } // 읽어옴, 값을 가져옴
        set
        {
            if (value <= 0) m_won = 0;
            else m_won = value * 1000f;
        }
    }
    public float won
    {
        get { return m_won; }
        set
        {
            if (value <= 0) m_won = 0;
            else m_won = value;
        }
    }
    // 원 단위로 금액 기록
    private float m_won = 0;


}
