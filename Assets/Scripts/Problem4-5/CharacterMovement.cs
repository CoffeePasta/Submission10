using UnityEngine;

public enum inputType { byKey, byCursor }

public class CharacterMovement : Movement
{
    [SerializeField] private inputType movementInput;

    private void Update()
    {
        if(movementInput == inputType.byKey)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            isMove = direction != Vector2.zero ? true : false;
        }
        else if(movementInput == inputType.byCursor)
        {
            Vector3 inp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (inp - this.transform.position).normalized * 2f;

            isMove = Vector2.Distance(transform.position, inp) >= 1f ? true : false;
        }

        //Debug.Log(direction.x + " - " + direction.y);
    }
}
