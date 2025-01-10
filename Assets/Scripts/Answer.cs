using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Answer : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
{
	public AnswerLetter letter;
	public bool correct;
	public Text text;

	QuizManager QManager;
	RectTransform rect;
	Color initialColor;
	bool selected;

	void Start()
	{
		initialColor = text.color;
		rect = GetComponent<RectTransform>();
		QManager = QuizManager.Instance;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		rect.localScale = new Vector2(1.1f, 1.1f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		rect.localScale = new Vector2(1f, 1f);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (selected)
		{
			QManager.ChoosedAnswer(AnswerLetter.NONE);
			Unselected();
			return;
		}
		
		text.color = Color.red;
		rect.localScale = new Vector2(1f, 1f);
		selected = true;
		QManager.ChoosedAnswer(letter);
	}

	public void Unselected()
	{
		rect.localScale = new Vector2(1f, 1f);
		text.color = initialColor;
		selected = false;
	}
}
