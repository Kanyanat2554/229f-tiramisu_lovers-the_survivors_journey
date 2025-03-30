using TMPro;
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
    public HealthBar healthBar;
    private GameObject healthBarUI;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("PlayerHp"))
        {
            PlayerPrefs.SetInt("PlayerHp", 100);
        }

        // โหลดค่า HP ที่บันทึกไว้
        CurrentHp = PlayerPrefs.GetInt("PlayerHp");
        
        MaxHp = 100;
        

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(MaxHp);
            healthBar.SetHealth(CurrentHp);
        }

        Debug.Log($"({this} has {CurrentHp} HP left)");
    }
    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        PlayerPrefs.SetInt("PlayerHp", CurrentHp);
        PlayerPrefs.Save();

        if (healthBar != null)
        {
            healthBar.SetHealth(CurrentHp);
        }

        if (IsDead())
        {
            HideHealthBar();
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
        SceneManager.LoadScene("Lose");
        Book.collectedBooks = 0;
        CurrentHp = 0;
    }

    private void FindHealthBar()
    {
        GameObject canvas = GameObject.Find("UI_Canvas"); 
        if (canvas != null)
        {
            healthBar = canvas.GetComponentInChildren<HealthBar>();
            healthBarUI = canvas; // เก็บค่า UI_Canvas ไว้

            if (healthBar != null)
            {
                healthBar.SetMaxHealth(MaxHp);
                healthBar.SetHealth(CurrentHp);
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindHealthBar(); // ค้นหา Health Bar ใหม่เมื่อโหลดฉากใหม่
    }

    private void HideHealthBar()
    {
        if (healthBarUI != null)
        {
            healthBarUI.SetActive(false); // ซ่อน Health Bar UI
        }
    }
}
