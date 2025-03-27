using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private PlayerController player;
    public Rigidbody rb;

    [SerializeField] private int damageHit = 10;
    public int DamageHit
    {
        get { return damageHit; }
        set { damageHit = value; }
    }

    private Coroutine damageCoroutine; // ����������� Coroutine �����ѧ�ӧҹ

    private void Start()
    {
        DamageHit = 10;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindAnyObjectByType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ����Ҽ����蹪��Ѻ�ѵ�ع��
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log($"{other} entered trigger");
            if (damageCoroutine == null) // ����ѧ����� Coroutine �ӧҹ
            {
                damageCoroutine = StartCoroutine(DamageOverTime(player)); // ����� Coroutine ����Ŵ���ʹ�ء 2 �Թҷ�
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ��ش���Ŵ���ʹ����ͼ������͡�ҡ Collider
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log($"{other} exited trigger");
            if (damageCoroutine != null) // ����� Coroutine �ӧҹ����
            {
                StopCoroutine(damageCoroutine); // ��ش���Ŵ���ʹ
                damageCoroutine = null; // ���� Coroutine
            }
        }
    }

    private IEnumerator DamageOverTime(PlayerController player)
    {
        while (true) // �ӫ�Ө����Ҩж١��ش
        {
            player.TakeDamage(DamageHit); // Ŵ���ʹ 10 �ء� 2 �Թҷ�
            yield return new WaitForSeconds(5f); // �� 2 �Թҷ�
        }
    }
}
