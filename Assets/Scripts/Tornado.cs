using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float gravitationalConstant = 6.5f; // ค่าคงที่แรงโน้มถ่วง
    public float attractionRadius = 20f; 
    public float dragFactor = 1f; // ค่าลดความเร็วของวัตถุ (Drag)
    public float angularDragFactor = 1f; // ค่าลดการหมุน (Angular Drag)
    public float minSpeed = 1f; 
    public float liftForce = 10f; // แรงยกขึ้นจากพายุ

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb)
            {
                // คำนวณแรงดึงดูดระหว่างศูนย์กลางพายุหมุนกับผู้เล่นตามกฎของนิวตัน
                Vector3 directionToCenter = transform.position - playerRb.position;
                float distance = directionToCenter.magnitude;

                if (distance < attractionRadius)
                {
                    #region Newton's Law of Universal Gravitation
                    // คำนวณแรงดึงดูด (ตามสูตร F = G * (m1 * m2) / r^2)
                    float forceMagnitude = gravitationalConstant * (playerRb.mass * 1f) / Mathf.Pow(distance, 2);
                    Vector3 gravitationalForce = directionToCenter.normalized * forceMagnitude;

                    // ดึงผู้เล่นเข้าไปที่ศูนย์กลางพายุ
                    playerRb.AddForce(gravitationalForce, ForceMode.Acceleration);
                    #endregion

                    #region Air Resistance: Drag, Angular Drag
                    // ชะลอความเร็วเมื่อเข้าใกล้พายุ
                    if (playerRb.linearVelocity.magnitude > minSpeed)
                    {
                        playerRb.linearVelocity = playerRb.linearVelocity * dragFactor * Time.deltaTime;
                    }

                    // เพิ่มแรงยกขึ้นจากพายุ
                    playerRb.AddForce(Vector3.up * liftForce * Time.deltaTime, ForceMode.Acceleration);

                    // ปรับค่าการหมุน (Angular Drag)
                    playerRb.angularDamping = angularDragFactor;
                    #endregion

                    #region Rotational Motion
                    // คำนวณการหมุนของผู้เล่น
                    Vector3 toCenter = (transform.position - playerRb.position).normalized;
                    Vector3 rotationDir = Vector3.Cross(Vector3.up, toCenter).normalized;

                    // ใช้ angularVelocity สำหรับการหมุน
                    playerRb.angularVelocity = rotationDir * 10f;
                    #endregion
                }
            }
        }
    }
}
