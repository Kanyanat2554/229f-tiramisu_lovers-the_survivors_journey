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

    private Coroutine damageCoroutine; // ตัวแปรเพื่อเก็บ Coroutine ที่กำลังทำงาน

    private void Start()
    {
        DamageHit = 10;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindAnyObjectByType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่าผู้เล่นชนกับวัตถุนี้
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log($"{other} entered trigger");
            if (damageCoroutine == null) // ถ้ายังไม่มี Coroutine ทำงาน
            {
                damageCoroutine = StartCoroutine(DamageOverTime(player)); // เริ่ม Coroutine ที่จะลดเลือดทุก 2 วินาที
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // หยุดการลดเลือดเมื่อผู้เล่นออกจาก Collider
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log($"{other} exited trigger");
            if (damageCoroutine != null) // ถ้ามี Coroutine ทำงานอยู่
            {
                StopCoroutine(damageCoroutine); // หยุดการลดเลือด
                damageCoroutine = null; // รีเซ็ต Coroutine
            }
        }
    }

    private IEnumerator DamageOverTime(PlayerController player)
    {
        while (true) // ทำซ้ำจนกว่าจะถูกหยุด
        {
            player.TakeDamage(DamageHit); // ลดเลือด 10 ทุกๆ 2 วินาที
            yield return new WaitForSeconds(5f); // รอ 2 วินาที
        }
    }
}
