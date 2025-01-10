using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	const int FIRST_LEVEL = 1;

	public void StartGame()
	{
		SceneManager.LoadScene(FIRST_LEVEL);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
