using TMPro;  // ������ ���, ���� ��� �� ���������
using UnityEngine;

public class ChangeTextAlpha : MonoBehaviour
{
    public Transform Text;
    public TextMeshPro textMeshPro;  // ������ �� ��������� TextMeshPro
    public Transform Player;
    private bool InFade = false;
    private bool Done = false;
    private Color32 currentColor;
    private byte maxAlpha = 0;
    public float start;
    public float end;
    float NormalizeAndScale(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        // ������������ ��������
        float normalized = (value - inputMin) / (inputMax - inputMin);

        // �������������� � �������� ��������
        float scaled = normalized * (outputMax - outputMin) + outputMin;
        scaled = outputMax - scaled + outputMin;

        return scaled;
    }

    private void Start()
    {
        // �������� ������� ����
        Color32 currentColor = textMeshPro.color;

        // �������� �����-����� (0 - ��������� ����������, 255 - ��������� ������������)
        currentColor.a = 0;  // ��������, ������� ����� ��������������

        // ��������� ����� ����
        textMeshPro.color = currentColor;
    }
    private void Update()
    {
        float distance = Vector3.Distance(Text.position, Player.position);
        float roundedDistance = Mathf.Round(distance * 100f) / 100f; // ���������� �� 2 ����� ����� �����
        if (distance < 7)
        {
            InFade = true;
        }
        if(InFade)
        {
            float inputValue = distance;  // ������� �� 3 �� 7
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
