using UnityEngine;

public class PlayerController : MonoBehaviour
{

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
