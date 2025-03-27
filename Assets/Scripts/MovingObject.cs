using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(-16.5f, -13.07f, 13.4f);
    public float moveSpeed = 10f;
    private bool shouldMove = false;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                shouldMove = false;
            }

        }
    }

    public void MoveToTarget()
    {
        shouldMove = true;
    }
}
