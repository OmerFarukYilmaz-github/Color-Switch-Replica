using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	[SerializeField] float jumpForce = 10f;

	[SerializeField] Rigidbody2D rb2D;
	[SerializeField] SpriteRenderer spriteRenderer;

	[SerializeField] string currentColor;


	[SerializeField] Color colorCyan;
	[SerializeField] Color colorYellow;
	[SerializeField] Color colorMagenta;
	[SerializeField] Color colorPink;

	void Start ()
	{
		SetRandomColor();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb2D.velocity = Vector2.up * jumpForce;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "ColorChanger")
		{
			SetRandomColor();
			Destroy(other.gameObject);
			return;
		}

		if (other.tag != currentColor)
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				spriteRenderer.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				spriteRenderer.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				spriteRenderer.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				spriteRenderer.color = colorPink;
				break;
		}
	}
}
