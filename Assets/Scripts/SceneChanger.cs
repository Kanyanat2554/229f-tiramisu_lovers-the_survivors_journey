using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] public string nextSceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
