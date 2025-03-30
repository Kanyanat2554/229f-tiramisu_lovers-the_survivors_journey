using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float gravitationalConstant = 6.5f; // ��Ҥ�����ç�����ǧ
    public float attractionRadius = 20f; 
    public float dragFactor = 1f; // ���Ŵ�������Ǣͧ�ѵ�� (Drag)
    public float angularDragFactor = 1f; // ���Ŵ�����ع (Angular Drag)
    public float minSpeed = 1f; 
    public float liftForce = 10f; // �ç¡��鹨ҡ����

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb)
            {
                // �ӹǳ�ç�֧�ٴ�����ҧ�ٹ���ҧ������ع�Ѻ�����蹵�����ͧ��ǵѹ
                Vector3 directionToCenter = transform.position - playerRb.position;
                float distance = directionToCenter.magnitude;

                if (distance < attractionRadius)
                {
                    #region Newton's Law of Universal Gravitation
                    // �ӹǳ�ç�֧�ٴ (����ٵ� F = G * (m1 * m2) / r^2)
                    float forceMagnitude = gravitationalConstant * (playerRb.mass * 1f) / Mathf.Pow(distance, 2);
                    Vector3 gravitationalForce = directionToCenter.normalized * forceMagnitude;

                    // �֧���������价���ٹ���ҧ����
                    playerRb.AddForce(gravitationalForce, ForceMode.Acceleration);
                    #endregion

                    #region Air Resistance: Drag, Angular Drag
                    // ���ͤ���������������������
                    if (playerRb.linearVelocity.magnitude > minSpeed)
                    {
                        playerRb.linearVelocity = playerRb.linearVelocity * dragFactor * Time.deltaTime;
                    }

                    // �����ç¡��鹨ҡ����
                    playerRb.AddForce(Vector3.up * liftForce * Time.deltaTime, ForceMode.Acceleration);

                    // ��Ѻ��ҡ����ع (Angular Drag)
                    playerRb.angularDamping = angularDragFactor;
                    #endregion

                    #region Rotational Motion
                    // �ӹǳ�����ع�ͧ������
                    Vector3 toCenter = (transform.position - playerRb.position).normalized;
                    Vector3 rotationDir = Vector3.Cross(Vector3.up, toCenter).normalized;

                    // �� angularVelocity ����Ѻ�����ع
                    playerRb.angularVelocity = rotationDir * 10f;
                    #endregion
                }
            }
        }
    }
}
