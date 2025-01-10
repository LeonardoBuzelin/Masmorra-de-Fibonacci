using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFunctions : MonoBehaviour
{
	public void BackToMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
