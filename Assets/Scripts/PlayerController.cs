using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Collect Book
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

    //HP System
    private int currentHp;
    public int CurrentHp { get; protected set; }

    private int maxHp;
    public int MaxHp { get; protected set; }

    public Animator anim;
    public Rigidbody rb;

    public virtual void Init(int newCurrentHealth)
    {
        CurrentHp = newCurrentHealth;
        maxHp = CurrentHp;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        Debug.Log($"({this} has {CurrentHp} left)");
    }
    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;

        IsDead();

        Debug.Log($"({this} has {CurrentHp} left");
    }

    public bool IsDead()
    {
        if (CurrentHp <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }

    private void Start()
    {
        Init(100);
        Debug.Log($"({this} has {this.CurrentHp} HP left)");
    }
}
