using TMPro;
using UnityEngine;

public class WASDScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string fullText = "Привет, мир!";
    public string currentText = "Начальный текст: ";
    private bool textCompleted = false;
    private float fadeSpeed = 0.5f;
    private bool startFading = false;
    private int charIndex = 0;
    private bool colorChanged = false;

    [ColorUsage(true, true)]
    public Color color;

    void Start()
    {
        textMeshPro.text = currentText;
        Invoke("StartTyping", 1.0f); 
    }

    void Update()
    {
        if (textCompleted && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            startFading = true;
        }

        if (startFading)
        {
            float alpha = textMeshPro.color.a;
            alpha -= fadeSpeed * Time.deltaTime;
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, Mathf.Clamp(alpha, 0, 1));
            if (alpha <= 0)
            {
                textMeshPro.gameObject.SetActive(false);
            }
        }
        if (!colorChanged && startFading)
        {
            textMeshPro.color = color;
            colorChanged = true;
        }
    }

    void StartTyping()
    {
        if (charIndex < fullText.Length)
        {
            currentText += fullText[charIndex];
            textMeshPro.text = currentText;
            charIndex++;
            Invoke("StartTyping", 0.5f);
        }
        else
        {
            textCompleted = true;
        }
    }
}
