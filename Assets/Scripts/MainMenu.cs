using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNewGame()
    {
        // ���絤�� HP ��͹�����������
        PlayerPrefs.DeleteKey("PlayerHp"); // ź��� PlayerHp ���૿���
        PlayerPrefs.SetInt("PlayerHp", 100); // ���� PlayerHp �� 100
        PlayerPrefs.Save(); // �ѹ�֡���

        // ��Ŵ�չ����ѡ (᷹�����ª��ͫչ�ͧ�س)
        SceneManager.LoadScene("Chapter1");
    }
}
