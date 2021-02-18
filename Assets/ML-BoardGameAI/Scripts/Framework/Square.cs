using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Visualisation and interface for one board square
/// </summary>
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class Square : MonoBehaviour
{
    [SerializeField]
    private Color clearColor;

    [SerializeField]
    private Color[] playerColors = new Color[2];

    [HideInInspector]
    [SerializeField]
    private Image image;

    [HideInInspector]
    [SerializeField]
    private Button button;

    protected void Reset()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public Square Init(UnityAction onClickListener)
    {
        button.onClick.AddListener(onClickListener);
        return this;
    }
        
    public void Clear()
        => image.color = clearColor;

    /// <summary>
    /// Places a token of the player (-1 / 1) on the square
    /// </summary>
    /// <param name="player"></param>
    public void Place(int player)
        => image.color = playerColors[player == - 1 ? 0 : 1];
}