using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CanvasVideoPlayer : MonoBehaviour
{
	public bool isPlaying;
	public int depth = 24;

	RenderTexture texture;
	VideoPlayer player;
	
	RawImage image;
	Vector2 screenSize;


	public void SetPlayerVolume()
	{
		PlayerPrefs.GetFloat("Volume", 1f);
	}

	void UpdateRenderTexture()
	{
		Debug.Log("Textura Atualizada");
		texture = new RenderTexture(Screen.width, Screen.height, 24);
		screenSize = new Vector2(Screen.width, Screen.height);
		player.targetTexture = texture;
		image.texture = texture;
	}

	void Awake()
	{
		player = GetComponent<VideoPlayer>();
		image = GetComponent<RawImage>();

		UpdateRenderTexture();
		SetPlayerVolume();

		player.Play();
	}

	void Update()
	{
		if (screenSize.x != Screen.width && screenSize.y != Screen.height)
			UpdateRenderTexture();

		isPlaying = player.isPlaying;
	}
}
