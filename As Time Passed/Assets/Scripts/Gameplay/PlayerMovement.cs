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
	bool doubleCrouch = false;

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

		//if (!Input.GetKeyDown(KeyCode.X) && !Input.GetKeyDown(KeyCode.L))
		//{
			if (Input.GetButtonDown("Crouch"))
			{
				crouch = true;
				JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerLand);
				GameObject.Find("KosuzuFocusedCollider").GetComponent<SpriteRenderer>().enabled = true;
				//if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.L))
				//{
				//	doubleCrouch = true;
				//}
			}
			else if (Input.GetButtonUp("Crouch"))
			{
				crouch = false;
				GameObject.Find("KosuzuFocusedCollider").GetComponent<SpriteRenderer>().enabled = false;
			}
		//}
	}

	void FixedUpdate ()
	{
		// Move our character
		//if (canMove)
		//{
			if (spells.flying)
			{
				if (crouch)
				{
					controller.Move(new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime, Input.GetAxisRaw("Vertical") * runSpeed * Time.fixedDeltaTime), crouch, jump, doubleCrouch);
				}
				else
                {
					if (canMove)
					{
						controller.Move(new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed * 3 * Time.fixedDeltaTime, Input.GetAxisRaw("Vertical") * runSpeed * 3 * Time.fixedDeltaTime), crouch, jump, doubleCrouch);
					}
					else
					{
						controller.Move(new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed * 1 * Time.fixedDeltaTime, Input.GetAxisRaw("Vertical") * runSpeed * 1 * Time.fixedDeltaTime), crouch, jump, doubleCrouch);
					}
				}
			GetComponent<Animator>().SetBool("Running?", false);
		}
		else
		{
			controller.Move(new Vector2(horizontalMove * Time.fixedDeltaTime, 0), crouch, jump, doubleCrouch);
			if (horizontalMove > 0.2f * runSpeed || horizontalMove < -0.2f * runSpeed)
			{
				GetComponent<Animator>().SetBool("Running?", true);
			}
			else
			{
				GetComponent<Animator>().SetBool("Running?", false);
			}
		}
		jump = false;
		//}
	}
}
