using TMPro;  // Добавь это, если ещё не добавлено
using UnityEngine;

public class ChangeTextAlpha : MonoBehaviour
{
    public Transform Text;
    public TextMeshPro textMeshPro;  // Ссылка на компонент TextMeshPro
    public Transform Player;
    private bool InFade = false;
    private bool Done = false;
    private Color32 currentColor;
    private byte maxAlpha = 0;
    public float start;
    public float end;
    float NormalizeAndScale(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        // Нормализация значения
        float normalized = (value - inputMin) / (inputMax - inputMin);

        // Преобразование в желаемый диапазон
        float scaled = normalized * (outputMax - outputMin) + outputMin;
        scaled = outputMax - scaled + outputMin;

        return scaled;
    }

    private void Start()
    {
        // Получаем текущий цвет
        Color32 currentColor = textMeshPro.color;

        // Изменяем альфа-канал (0 - полностью прозрачный, 255 - полностью непрозрачный)
        currentColor.a = 0;  // Например, сделаем текст полупрозрачным

        // Применяем новый цвет
        textMeshPro.color = currentColor;
    }
    private void Update()
    {
        float distance = Vector3.Distance(Text.position, Player.position);
        float roundedDistance = Mathf.Round(distance * 100f) / 100f; // Округление до 2 чисел после знака
        if (distance < 7)
        {
            InFade = true;
        }
        if(InFade)
        {
            float inputValue = distance;  // Входное от 3 до 7
            float scaledValue = NormalizeAndScale(inputValue, start, end, 0f, 255f);

            currentColor.a = (byte)Mathf.Clamp(scaledValue, 0, 255);

            maxAlpha = (byte)Mathf.Max(maxAlpha, scaledValue);
            textMeshPro.color = currentColor;
        }
        if (currentColor.a == 255)
        {
            Done = true;
        }
        if (Done)
        {
            this.enabled = false;
        }
        // Debug.Log("Alpha: " + currentColor.a + ", Distance: " + roundedDistance + ", InFade? " + InFade + ", Done? " + Done);
    }
}
