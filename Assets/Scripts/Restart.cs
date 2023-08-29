using UnityEngine;

public class Restart : MonoBehaviour
{
    public Vector3 resetPosition = new Vector3(0, 0, 0);
    public Vector3 resetRotation = new Vector3(0, 0, 0);

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = resetPosition;
            transform.eulerAngles = resetRotation;
        }
    }
}

