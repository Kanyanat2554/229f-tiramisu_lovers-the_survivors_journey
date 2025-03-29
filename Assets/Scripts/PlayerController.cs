using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //HP System
    private int currentHp;
    public int CurrentHp { get; protected set; }

    private int maxHp;
    public int MaxHp { get; protected set; }

    public Animator anim;
    public Rigidbody rb;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("PlayerHp"))
        {
            PlayerPrefs.SetInt("PlayerHp", 100);
        }

        // โหลดค่า HP ที่บันทึกไว้
        CurrentHp = PlayerPrefs.GetInt("PlayerHp");
        MaxHp = CurrentHp;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        Debug.Log($"({this} has {CurrentHp} HP left)");
    }
    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        PlayerPrefs.SetInt("PlayerHp", CurrentHp);
        PlayerPrefs.Save();

        if (IsDead())
        {
            Die();
        }

        Debug.Log($"({this} has {CurrentHp} left");
    }

    public bool IsDead()
    {
        return CurrentHp <= 0;
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        PlayerPrefs.DeleteKey("PlayerHp"); 
        SceneManager.LoadScene("GameOver"); 
    }
}
