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

    void Start()
    {
		spells = transform.GetComponent<SpellcardController>();
    }

    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump") && !spells.flying)
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
            crouch = true;
			GameObject.Find("KosuzuFocusedCollider").GetComponent<SpriteRenderer>().enabled = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
			GameObject.Find("KosuzuFocusedCollider").GetComponent<SpriteRenderer>().enabled = false;
		}

	}

	void FixedUpdate ()
	{
		// Move our character
		if (spells.flying)
		{
			controller.Move(new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime, Input.GetAxisRaw("Vertical") * runSpeed * Time.fixedDeltaTime), crouch, jump);
		}
		else
        {
			controller.Move(new Vector2(horizontalMove * Time.fixedDeltaTime, 0), crouch, jump);
		}
		jump = false;
	}
}
