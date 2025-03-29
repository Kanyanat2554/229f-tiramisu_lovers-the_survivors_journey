using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public int damage = 3;
    public float damageInterval = 0.2f; 
    private Dictionary<GameObject, float> lastDamageTime = new Dictionary<GameObject, float>();

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                float lastTime;
                if (!lastDamageTime.TryGetValue(collision.gameObject, out lastTime))
                {
                    lastTime = 0;
                }

                if (Time.time - lastTime >= damageInterval)
                {
                    player.TakeDamage(damage);
                    lastDamageTime[collision.gameObject] = Time.time;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // ลบข้อมูลเมื่อผู้เล่นออกจากการชน เพื่อให้โจมตีใหม่ทันทีเมื่อลงไปชนอีกครั้ง
        if (collision.gameObject.CompareTag("Player"))
        {
            lastDamageTime.Remove(collision.gameObject);
        }
    }
}
