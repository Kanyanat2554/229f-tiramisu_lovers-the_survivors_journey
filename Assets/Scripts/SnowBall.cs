using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public int damage = 10; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            PlayerController CurrentHp = collision.gameObject.GetComponent<PlayerController>();
            if (CurrentHp != null)
            {
                CurrentHp.TakeDamage(damage);
            }
        }
    }
}
