using System;
using UnityEngine;

// ����ü�� ������ ���� ������Ʈ���� ���� ���� ����
// ü��, ����� �޾Ƶ��̱�, ��� ���, ��� �̺�Ʈ�� ����
public class LivingEntity : MonoBehaviour, IDamageable
{
    /// <summary>
    /// ���� ü��
    /// </summary>
    public float startingHealth = 100f;
    /// <summary>
    /// ���� ü��
    /// </summary>
    public float health { get; protected set;}
    /// <summary>
    /// ��� ����
    /// </summary>
    public bool dead { get; protected set;}
    /// <summary>
    /// ��� �� �ߵ��� �̺�Ʈ
    /// </summary>
    public event Action onDeath;

    // ����ü�� Ȱ��ȭ �� �� ���¸� ����
    protected virtual void OnEnable()
    {
        // ������� ���� ���·� ����
        dead = false;
        // ü���� ���� ü������ �ʱ�ȭ
        health = startingHealth;
    }

    // ����� �Դ� ���
    public void OnDamage(float damage, Vector3 hitPoint, Vector3 hitnormal)
    {
        // ����� ��ŭ ü�� ����
        health -= damage;

        // ü���� 0���� && ���� ���� �ʾҴٸ� ��� ó�� ����
        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    // ü���� ȸ���ϴ� ���
    public virtual void RestoreHealth(float newHealth)
    {
        if (dead)
        {
            // �̹� ����� ��� ü���� ȸ���� �� ����
            return;
        }

        // ü�� �߰�
        health += newHealth;
    }

    // ��� ó��
    public virtual void Die()
    {
        // onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
        if (onDeath != null)
        {
            onDeath();
        }

        // ��� ���¸� ������ ����
        dead = true;
    }
}
