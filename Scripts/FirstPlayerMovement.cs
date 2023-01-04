using UnityEngine;

public class FirstPlayerMovement : Movement
{
    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGround())
            Rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    }

    protected override void Move()
    {
        if (Input.GetKey(KeyCode.A))
            Rigidbody.AddForce(Vector2.left * MoveSpeed, ForceMode2D.Impulse);

        if (Input.GetKey(KeyCode.D))
            Rigidbody.AddForce(Vector2.right * MoveSpeed, ForceMode2D.Impulse);
    }
}
