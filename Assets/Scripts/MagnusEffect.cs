using UnityEngine;

public class MagnusEffect : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Vector3 velocity, spin;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ApplyMagnusEffect();
    }
    void ApplyMagnusEffect()
    {
        rb.linearVelocity = velocity;
        rb.angularVelocity = spin;

        Vector3 magnusForce = Vector3.Cross(rb.linearVelocity, rb.angularVelocity);

        rb.AddForce(magnusForce);
    }
}
