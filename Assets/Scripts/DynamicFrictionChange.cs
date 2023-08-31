using UnityEngine;

public class DynamicFrictionChange : MonoBehaviour
{
    public PhysicMaterial frictionLow;
    public PhysicMaterial frictionHigh;
    public PhysicMaterial frictionNormal;

    private Collider playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Slippery")
        {
            playerCollider.material = frictionLow;
            Debug.Log("Slippery");
        }
        else if (collision.gameObject.tag == "Sticky")
        {
            playerCollider.material = frictionHigh;
            Debug.Log("Sticky");
        }
        else
        {
            playerCollider.material = frictionNormal;
        }
    }
}