using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int bookCount = 0; // จำนวนหนังสือที่เก็บ

    public void CollectBook()
    {
        bookCount++;
        Debug.Log("Books Collected: " + bookCount);

        // แจ้งให้ประตูตรวจสอบว่าเปิดได้หรือยัง
        Portal portal = FindAnyObjectByType<Portal>();
        if (portal != null)
        {
            portal.CheckIfCanOpen(bookCount);
        }
    }
}
