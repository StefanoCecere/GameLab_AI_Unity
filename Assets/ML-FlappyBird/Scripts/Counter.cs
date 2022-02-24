// Counter.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public Bird bird;
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = Mathf.Floor(bird.counter / 2f).ToString();
    }
}
