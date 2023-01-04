using UnityEngine;

public class SecondPlayerMovement : Movement
{
    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGround())
            Rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    }

    protected override void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            Rigidbody.AddForce(Vector2.left * MoveSpeed, ForceMode2D.Impulse);

        if (Input.GetKey(KeyCode.RightArrow))
            Rigidbody.AddForce(Vector2.right * MoveSpeed, ForceMode2D.Impulse);
    }
}
