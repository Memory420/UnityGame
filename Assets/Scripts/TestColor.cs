using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestColor : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public Color color;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            textMeshPro.color = color;
        }
    }
}
