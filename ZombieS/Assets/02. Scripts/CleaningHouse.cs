using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningHouse : MonoBehaviour
{
    private void Start()
    {
        // �޼���� �Է�
        //StartCoroutine(Cleaning());
        // �Ű������� ���������� ���� �� �ִ�.
        //StartCoroutine(Cleaning(100));
        // Ȥ�� ���ڿ��� �Է�
        StartCoroutine("Cleaning");
        // ���ڿ��� �Է��ϸ� stop�� �����ϴ�=> update�� ���� ����ؼ� �ۼ�

        // �� �ٸ� ���� ��� invoke
        Invoke("Test", 3f);
    }

    private void Update()
    {
        Debug.Log((int)Time.time);

        if(Time.time >= 12f)
        {
            StopCoroutine("Cleaning");
            Debug.Log("�ڷ�ƾ�� �����մϴ�.");
        }
    }

    public void Test()
    {
        Debug.Log("���̾� �ȳ�");
    }
    private IEnumerator Cleaning()
    {
        // A��û��
        Debug.Log("A���� û���մϴ�");
        // �ʴ����� ���� WaitForSeconds()
        yield return new WaitForSeconds(5f);
        // B��û��
        Debug.Log("B���� û���մϴ�");
        yield return new WaitForSeconds(10f);
        // C��û��
        Debug.Log("C���� û���մϴ�");
        // �� �����Ӹ� ������ null��ȯ 
        yield return null;
        Debug.Log("û�Ұ� �������ϴ�");

    }

}
