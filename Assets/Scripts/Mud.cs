using UnityEngine;

public class Mud : MonoBehaviour
{
    public float sinkSpeed = 5f; // �������Ƿ������蹨�ŧ�
    public float slowMultiplier = 0.2f; // ���Ŵ�������Ǣͧ������
    private float originalSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                originalSpeed = player.speed;
                player.speed *= slowMultiplier; // Ŵ�������Ǣͧ������
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
                player.speed = originalSpeed; // �׹��Ҥ������ǻ���
            }
        }
    }   
}
