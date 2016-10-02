using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Pixel GB")]
public class GBRender : MonoBehaviour {

	public int h = 166;
	public int w = 144;
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			enabled = false;
			return;
		}
	}
	void Update()
	{



	}
	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		source.filterMode = FilterMode.Point;
		RenderTexture buffer = RenderTexture.GetTemporary(w, h, -1);
		buffer.filterMode = FilterMode.Point;
		Graphics.Blit(source, buffer);
		Graphics.Blit(buffer, destination);
		RenderTexture.ReleaseTemporary(buffer);
	}
}
