using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
	public static QuizManager Instance;

	public CanvasVideoPlayer normalPlayer;
	public CanvasVideoPlayer gameOverPlayer;

	[Space(5f)]
	public Animator animator;
	public GameObject quizHolder;

	[Space(5f)]
	public AnswerLetter currentAnswer;
	public Answer[] answers;
	public Button feather;

	int nextLevel;


	void Awake()
	{
		Instance = this;
	}

	public void ConfirmAnswer()
	{
		int num = (int)currentAnswer;

		if (answers[num].correct)
			SceneManager.LoadScene(nextLevel);
		else
			StartCoroutine("GameOverScene");
	}

	IEnumerator GameOverScene()
	{
		gameOverPlayer.gameObject.SetActive(true);
		quizHolder.SetActive(false);

		yield return new WaitForSeconds(1f);
		yield return new WaitUntil(() => !gameOverPlayer.isPlaying);
		
		animator.SetTrigger("Died");
	}

	public void ChoosedAnswer(AnswerLetter answer)
	{
		feather.interactable = answer != AnswerLetter.NONE;
		currentAnswer = answer;
		Answer[] array = answers;
		foreach (Answer answer2 in array)
		{
			if (answer2.letter != currentAnswer)
			{
				answer2.Unselected();
			}
		}
	}

	IEnumerator Start()
	{
		nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
		yield return new WaitForSeconds(1f);
		yield return new WaitUntil(() => !normalPlayer.isPlaying);
		quizHolder.SetActive(true);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
		}
	}
}
