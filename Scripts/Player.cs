using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;

    private const int MaxHealth = 100;
    private const int MinHealth = 0;

    private Movement _movement;

    public string Name => _name;
    public int Health => _health;
    public int Coin { get; private set; } = 0;
    public bool IsAlive => _health > 0;

    public event UnityAction OnDie;
    public event UnityAction<int> OnHealthChanged;
    public event UnityAction<int> OnCoinPicked;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        OnHealthChanged?.Invoke(_health);
        OnCoinPicked?.Invoke(Coin);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < MinHealth)
            _health = MinHealth;

        OnHealthChanged?.Invoke(_health);

        if (IsAlive == false)
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }

    public void AddHealth(int health)
    {
        if (_health == MaxHealth)
            return;

        _health += health;

        if (_health > MaxHealth)
            _health -= _health - MaxHealth;

        OnHealthChanged?.Invoke(_health);
    }

    public void AddCoin(int coin)
    {
        Coin += coin;
        OnCoinPicked?.Invoke(Coin);
    }

    public void Stun(float delay)
    {
        _movement.PlayStun(delay);
    }
}
