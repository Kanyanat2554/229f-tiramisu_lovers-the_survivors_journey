using TMPro;
using UnityEngine;

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
