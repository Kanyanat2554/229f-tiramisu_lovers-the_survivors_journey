using UnityEngine;

public class Mud : MonoBehaviour
{
    public float sinkSpeed = 5f; // ความเร็วที่ผู้เล่นจมลงไป
    public float slowMultiplier = 0.2f; // ค่าลดความเร็วของผู้เล่น
    private float originalSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                originalSpeed = player.speed;
                player.speed *= slowMultiplier; // ลดความเร็วของผู้เล่น
                StartCoroutine(SinkPlayer(player));
            }
        }
    }

    private System.Collections.IEnumerator SinkPlayer(PlayerMovement player)
    {
        while (player.transform.position.y > transform.position.y - 2f)
        {
            player.transform.position += Vector3.down * sinkSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.speed = originalSpeed; // คืนค่าความเร็วปกติ
            }
        }
    }   
}
