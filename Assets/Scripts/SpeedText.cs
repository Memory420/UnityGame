using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    public Transform object1;
    public Transform object2;

    public TextMeshProUGUI distanceText;
    private void Update()
    {
        float distance = Vector3.Distance(object1.position, object2.position);
        distanceText.text = "Distance: " + distance.ToString("F2");
    }
}