using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rb;

    protected Vector2 direction;
    protected bool isMove;

    void Start()
    {
        SetMovement();
    }

    protected virtual void SetMovement()
    {
        isMove = true;
        direction = Random.insideUnitCircle.normalized;
    }

    private void FixedUpdate()
    {
        if (isMove) rb.velocity = direction * moveSpeed * Time.fixedDeltaTime;
        else rb.velocity = Vector2.zero;
    }
}
