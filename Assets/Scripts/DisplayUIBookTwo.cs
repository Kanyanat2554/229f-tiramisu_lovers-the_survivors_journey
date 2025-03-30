using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayUIBookTwo : MonoBehaviour
{
    //Display UI Book
    [SerializeField] TextMeshProUGUI bookText;

    private void Update()
    {
        UpdateBookText();
    }

    private void UpdateBookText()
    {
        bookText.text = $"   {BookChapterTwo.collectedBooks} / 3";
    }
}
