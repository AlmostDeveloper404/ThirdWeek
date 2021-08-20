using UnityEngine;

public class PlaneCollision : MonoBehaviour
{

    PlayerStats _playerStats;
    

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            int bombDamage = 1;
            _playerStats.TakeDamage(bombDamage);
            Destroy(other.gameObject);
        }
        else if (other.GetComponent<Rocket>())
        {
            int rocketDamage = 1;
            _playerStats.TakeDamage(rocketDamage);
            Destroy(other.gameObject);
        }
        else
        {
            _playerStats.Collect();
            Destroy(other.gameObject);
        }
    }
}
