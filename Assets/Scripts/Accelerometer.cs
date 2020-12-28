using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 dir = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
        rb.AddForce(dir * speed * Time.deltaTime);
    }
}
