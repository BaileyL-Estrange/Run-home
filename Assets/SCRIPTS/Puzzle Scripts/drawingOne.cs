using UnityEngine;
using UnityEngine.UI;

public class drawingOne : MonoBehaviour
{
	private Renderer _renderer;
	public Image drawingImage;

	private void Start() 
	{
		_renderer = GetComponent<Renderer>();

	}
	private void OnMouseDown()
	{
		drawingImage.gameObject.SetActive(true);
		CursorManagement.SetUI(true);
	}

	public void hideDrawings() 
	{
		Debug.Log("Button clicked!");
		drawingImage.gameObject.SetActive(false);
		CursorManagement.SetUI(false);
	}

}
