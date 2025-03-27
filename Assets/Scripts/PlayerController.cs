using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int bookCount = 0; // �ӹǹ˹ѧ��ͷ����

    public void CollectBook()
    {
        bookCount++;
        Debug.Log("Books Collected: " + bookCount);

        // ������еٵ�Ǩ�ͺ����Դ�������ѧ
        Portal portal = FindAnyObjectByType<Portal>();
        if (portal != null)
        {
            portal.CheckIfCanOpen(bookCount);
        }
    }
}
