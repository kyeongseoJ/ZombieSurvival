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
            Debug.Log("씬에 두개이상의 게임매니저가 존재합니다.");
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
