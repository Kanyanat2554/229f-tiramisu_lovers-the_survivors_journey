using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCredits : MonoBehaviour
{
    [SerializeField] public string nextSceneName; 
    public float delay = 6f; 

    private void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay()); 
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay); 
        SceneManager.LoadScene(nextSceneName); 
    }
}
