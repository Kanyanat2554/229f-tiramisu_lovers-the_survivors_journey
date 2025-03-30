using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayUIBook : MonoBehaviour
{
    //Display UI Book
    [SerializeField] TextMeshProUGUI bookText;

    private void Update()
    {
        UpdateBookText();
    }

    private void UpdateBookText()
    {
        bookText.text = $"   {Book.collectedBooks} / 2";
    }
}
