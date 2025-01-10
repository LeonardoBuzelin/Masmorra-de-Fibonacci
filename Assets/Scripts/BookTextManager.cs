using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BookTextManager : MonoBehaviour
{
	public CanvasVideoPlayer player;
	public GameObject bookHolder;

	[Space(5f)]
	public Button[] turnButtons;
	public GameObject[] pages;
	public bool skipToBook;

	int currentPage;
	int next;

	IEnumerator Start()
	{
		next = SceneManager.GetActiveScene().buildIndex + 1;

		if (!skipToBook)
		{
			yield return new WaitForSeconds(1f);
			yield return new WaitUntil(() => !player.isPlaying);
		}

		bookHolder.SetActive(true);
	}

	public void PreviousPage()
	{
		currentPage--;
		TurnPage();
	}

	public void NextPage()
	{
		currentPage++;
		TurnPage();
	}

	void TurnPage()
	{
		if (currentPage >= pages.Length)
		{
			if (skipToBook)
				SceneManager.LoadScene(0);
			else
				SceneManager.LoadScene(next);
		}

		for (int i = 0; i < pages.Length; i++)
		{
			bool active = ((i == currentPage) ? true : false);
			pages[i].SetActive(active);
		}

		UpdateButtons();
	}

	void UpdateButtons()
	{
		turnButtons[0].interactable = currentPage > 0;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene(0);
	}
}
