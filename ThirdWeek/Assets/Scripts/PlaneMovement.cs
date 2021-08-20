using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    Vector3 moveDirection;
    Vector3 planeRotation;
    Vector3 spawnerBoxSize;

    [SerializeField]float planeSpeed = 10f;
    [SerializeField]float rotationSpeed = 20f;

    Rigidbody _rigidbody;
    GameManager _gameManager;


    private void Awake()
    {
        spawnerBoxSize = Spawner.size;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection = transform.right;
        } 
        planeRotation = new Vector3(0f,0f,vertical);


        ClampMovement();
        
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(moveDirection* planeSpeed, ForceMode.VelocityChange);
        _rigidbody.AddTorque(planeRotation*rotationSpeed);
    }

    void ClampMovement()
    {
        if (transform.position.x > spawnerBoxSize.x / 2 || transform.position.x < -spawnerBoxSize.x / 2 ||
            transform.position.y > spawnerBoxSize.y / 2 || transform.position.y < -spawnerBoxSize.y / 2)
        {
            _gameManager.GameOver();
        }
    }
}
