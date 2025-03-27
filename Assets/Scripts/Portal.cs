using UnityEngine;

public class Portal : MonoBehaviour
{
    public int booksRequired = 1; 

    public void CheckIfCanOpen(int bookCount)
    {
        if (bookCount >= booksRequired)
        {
            gameObject.SetActive(false); 
            Debug.Log("Invisible Door Removed!");
        }
    }
}
