using TMPro;
using UnityEngine;

public class DisplayJumpBonus : MonoBehaviour
{
    public PlayerMovementAdvanced jumpScript; // Ссылка на другой скрипт
    private TextMeshProUGUI textMeshPro; // Ссылка на компонент TextMeshPro

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Отображение значения переменной TemporaryJumpBonus в текстовом поле
        textMeshPro.text = "Jump Bonus: " + jumpScript.TemporaryJumpBonus.ToString("F1");
    }
}
