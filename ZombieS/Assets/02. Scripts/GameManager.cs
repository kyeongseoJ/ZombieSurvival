using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameover = false;

    #region Sigleton
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("���� �ΰ��̻��� ���ӸŴ����� �����մϴ�.");
            Destroy(gameObject);
            
        }
    }
    #endregion

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
