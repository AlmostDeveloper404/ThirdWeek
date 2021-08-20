using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int health;
    public static int amountOfMoney;
    [SerializeField] int maxAmountOfMoney=15;
    [SerializeField] int startMoney;
    [SerializeField] int startHealth;

    GameManager _gameManager;
    UIManager _uiManager;

    private void Awake()
    {
        amountOfMoney = startMoney;
        health = startHealth;
    }
    private void Start()
    {
        _uiManager = UIManager.instance;
        _gameManager = GameManager.instance;

        FirstUIUpdate();
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        _uiManager.UpdateLives(health);
        if (health<=0)
        {
            Die();
        }
    }

    public void Collect()
    {
        amountOfMoney++;

        _uiManager.UpdateMoney(amountOfMoney,maxAmountOfMoney);
        if (amountOfMoney==maxAmountOfMoney)
        {
            _gameManager.Win();
        }
    }

    void Die()
    {
        _gameManager.GameOver();

        Destroy(gameObject);
    }

    void FirstUIUpdate()
    {
        _uiManager.UpdateMoney(amountOfMoney, maxAmountOfMoney);
        _uiManager.UpdateLives(health);
    }
}
