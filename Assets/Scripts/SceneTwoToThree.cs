using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTwoToThree : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Chapter3");
        }
    }
}
