using UnityEngine;

public class Book : MonoBehaviour
{
    private static int collectedBooks = 0; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            collectedBooks++; 
            Debug.Log($"Books collected: {collectedBooks}");

            Destroy(gameObject); 

            if (collectedBooks >= 2) 
            {
                RemoveBarrier(); 
            }
        }
    }

    private void RemoveBarrier()
    {
        GameObject barrier = GameObject.FindGameObjectWithTag("Barrier"); 
        if (barrier != null)
        {
            Destroy(barrier); 
            Debug.Log("Barrier Removed!");
        }
    }
}
