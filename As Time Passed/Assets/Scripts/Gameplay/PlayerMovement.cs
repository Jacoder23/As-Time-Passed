using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	SpellcardController spells;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public bool canMove = true;

    void Start()
    {
		spells = transform.GetComponent<SpellcardController>();
    }

    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump") && !spells.flying)
		{
            if (!jump)
            {
				JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerLift);
			}
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
            crouch = true;
			JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerLand);
			GameObject.Find("KosuzuFocusedCollider").GetComponent<SpriteRenderer>().enabled = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
			GameObject.Find("KosuzuFocusedCollider").GetComponent<SpriteRenderer>().enabled = false;
		}

	}

	void FixedUpdate ()
	{
		// Move our character
		if (canMove)
		{
			if (spells.flying)
			{
				if (crouch)
				{
					controller.Move(new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime, Input.GetAxisRaw("Vertical") * runSpeed * Time.fixedDeltaTime), crouch, jump);
				}
				else
                {
					controller.Move(new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed * 2 * Time.fixedDeltaTime, Input.GetAxisRaw("Vertical") * runSpeed * 2 * Time.fixedDeltaTime), crouch, jump);
				}
			}
			else
			{
				controller.Move(new Vector2(horizontalMove * Time.fixedDeltaTime, 0), crouch, jump);
			}
			jump = false;
		}
	}
}
