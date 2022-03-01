using System;
using UnityEngine;

// Token: 0x020048C9 RID: 18633
public class MedaiPlayerSampleSphereGUI : MonoBehaviour
{
	// Token: 0x0601ACDC RID: 109788 RVA: 0x0083E9BE File Offset: 0x0083CDBE
	private void Start()
	{
	}

	// Token: 0x0601ACDD RID: 109789 RVA: 0x0083E9C0 File Offset: 0x0083CDC0
	private void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + touch.deltaPosition.x, base.transform.localEulerAngles.z);
		}
	}

	// Token: 0x0601ACDE RID: 109790 RVA: 0x0083EA50 File Offset: 0x0083CE50
	private void OnGUI()
	{
		if (GUI.Button(new Rect(50f, 50f, 100f, 100f), "Load"))
		{
			this.scrMedia.Load("EasyMovieTexture.mp4");
		}
		if (GUI.Button(new Rect(50f, 200f, 100f, 100f), "Play"))
		{
			this.scrMedia.Play();
		}
		if (GUI.Button(new Rect(50f, 350f, 100f, 100f), "stop"))
		{
			this.scrMedia.Stop();
		}
		if (GUI.Button(new Rect(50f, 500f, 100f, 100f), "pause"))
		{
			this.scrMedia.Pause();
		}
		if (GUI.Button(new Rect(50f, 650f, 100f, 100f), "Unload"))
		{
			this.scrMedia.UnLoad();
		}
	}

	// Token: 0x04012A72 RID: 76402
	public MediaPlayerCtrl scrMedia;
}
