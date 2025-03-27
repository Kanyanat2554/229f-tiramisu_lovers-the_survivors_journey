using UnityEngine;

public class Switch : MonoBehaviour
{
    public MovingObject targetBridge;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            targetBridge.MoveToTarget();
        }
    }
}
