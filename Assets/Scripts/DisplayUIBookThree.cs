using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayUIBookThree : MonoBehaviour
{
    //Display UI Book
    [SerializeField] TextMeshProUGUI bookText;

    private void Update()
    {
        UpdateBookText();
    }

    private void UpdateBookText()
    {
        bookText.text = $"   {BookChapterThree.collectedBooks} / 4";
    }
}
