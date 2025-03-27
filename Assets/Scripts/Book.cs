using UnityEngine;

public class Book : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.CollectBook();
            Destroy(gameObject); 
        }
    }
}
