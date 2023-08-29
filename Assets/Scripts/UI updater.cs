using TMPro;
using UnityEngine;

public class DisplayJumpBonus : MonoBehaviour
{
    public PlayerMovementAdvanced jumpScript; // ������ �� ������ ������
    private TextMeshProUGUI textMeshPro; // ������ �� ��������� TextMeshPro

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // ����������� �������� ���������� TemporaryJumpBonus � ��������� ����
        textMeshPro.text = "Jump Bonus: " + jumpScript.TemporaryJumpBonus.ToString("F1");
    }
}
