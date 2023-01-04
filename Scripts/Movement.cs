using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] protected float JumpForce;
    [SerializeField] protected float MoveSpeed;

    private const float MaxDistanceRayGround = 1.25f;

    protected Rigidbody2D Rigidbody;

    private Coroutine _waitPlayStunJob;
    private bool _isStun = false;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isStun == false)
        {
            Jump();
            Move();
        }
    }

    public void PlayStun(float delay)
    {
        if (_waitPlayStunJob != null)
        {
            StopCoroutine(_waitPlayStunJob);
            _waitPlayStunJob = null;
        }

        _waitPlayStunJob = StartCoroutine(WaitPlayStun(delay));
    }

    protected bool IsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(Rigidbody.position, Vector2.down, MaxDistanceRayGround, _layer);
        return hit.collider != null;
    }

    protected abstract void Jump();
    protected abstract void Move();

    private IEnumerator WaitPlayStun(float delay)
    {
        _isStun = true;
        yield return new WaitForSeconds(delay);
        _isStun = false;
    }
}
