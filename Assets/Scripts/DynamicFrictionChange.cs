using UnityEngine;

public class DynamicFrictionChange : MonoBehaviour
{
    public GameObject playerObj;
    private Collider playerObjCollider;

    private bool touchingFloor = false;
    private bool touchingWall = false;

    void Start()
    {
        if (playerObj != null)
        {
            playerObjCollider = playerObj.GetComponent<Collider>();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        touchingFloor = false;
        touchingWall = false;

        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 normal = contact.normal;

            if (normal.y > 0.9f)
            {
                touchingFloor = true;
            }
            else if (Mathf.Approximately(normal.y, 0f))
            {
                touchingWall = true;
            }
        }

        if (touchingFloor && !touchingWall)
        {
            SetDynamicFriction(0.6f);
        }
        else
        {
            SetDynamicFriction(0f);
        }
    }

    void SetDynamicFriction(float value)
    {
        if (playerObjCollider != null && playerObjCollider.material != null)
        {
            playerObjCollider.material.dynamicFriction = value;
        }
    }
}
