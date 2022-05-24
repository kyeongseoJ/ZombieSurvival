﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자 입력에 따라 플레이어 캐릭터를 움직이는 스크립트
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 앞뒤 움직임 속도
    public float rotateSpped = 180f; // 좌우 회전 속도

    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트

    [SerializeField] private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    void Start()
    {
        //사용할 컴포넌트들의 참조 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리갱신 주기에 맞춰 실행됨
    private void FixedUpdate()
    {
        // 물리갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        // 회전 실행
        Rotate();
        // 움직임 실행
        Move();
        // 입력값에 따라 애니메이터의 Move 파라미터 값 변경
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {
        // 상대적으로 이동할 거리 계산
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        // 리지드바디를 이용해 게임 오브젝트 위치를 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        // 상대적으로 회전할 수치 계산
        float turn = playerInput.rotate * rotateSpped * Time.deltaTime;
        // 리지드바디를 이용해 게임 오브젝트 회전 변경
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();
        if(item != null)
        {
            item.Use(gameObject);
        } 
    }


}
