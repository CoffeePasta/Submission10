using UnityEngine;

public class Bounceable : Movement
{
    private void FixedUpdate(){} //override

    protected override void SetMovement()
    {
        base.SetMovement();
        rb.AddForce(direction * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(collision.GetContact(0).normal);
    }
}
