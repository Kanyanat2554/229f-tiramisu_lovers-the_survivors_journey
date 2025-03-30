using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNewGame()
    {
        // รีเซ็ตค่า HP ก่อนเริ่มเกมใหม่
        PlayerPrefs.DeleteKey("PlayerHp"); // ลบค่า PlayerHp ที่เซฟไว้
        PlayerPrefs.SetInt("PlayerHp", 100); // รีเซ็ต PlayerHp เป็น 100
        PlayerPrefs.Save(); // บันทึกค่า

        // โหลดซีนเกมหลัก (แทนที่ด้วยชื่อซีนของคุณ)
        SceneManager.LoadScene("Chapter1");
    }
}
