using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{
    public Transform player;

    [SerializeField]float speed = 4f;
    [SerializeField] float rotationSpeed = 200f;

    Rigidbody _rigidBody;
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerStats>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (player.position - _rigidBody.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _rigidBody.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        _rigidBody.velocity = transform.forward * speed;
    }

}
