using System.Collections;
using UnityEngine;

public class TriggerCanvasWhenPlayerEnd : MonoBehaviour
{
	public Animator animator;
	public string trigger;

	CanvasVideoPlayer player;


	IEnumerator Start()
	{
		player = GetComponent<CanvasVideoPlayer>();
		yield return new WaitForSeconds(1f);

		yield return new WaitUntil(() => !player.isPlaying);
		animator.SetTrigger(trigger);
	}
}
