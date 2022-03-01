using System;
using UnityEngine;

// Token: 0x020048C8 RID: 18632
public class MedaiPlayerSampleGUI : MonoBehaviour
{
	// Token: 0x0601ACD7 RID: 109783 RVA: 0x0083E693 File Offset: 0x0083CA93
	private void Start()
	{
		MediaPlayerCtrl mediaPlayerCtrl = this.scrMedia;
		mediaPlayerCtrl.OnEnd = (MediaPlayerCtrl.VideoEnd)Delegate.Combine(mediaPlayerCtrl.OnEnd, new MediaPlayerCtrl.VideoEnd(this.OnEnd));
	}

	// Token: 0x0601ACD8 RID: 109784 RVA: 0x0083E6BC File Offset: 0x0083CABC
	private void Update()
	{
	}

	// Token: 0x0601ACD9 RID: 109785 RVA: 0x0083E6C0 File Offset: 0x0083CAC0
	private void OnGUI()
	{
		if (GUI.Button(new Rect(50f, 50f, 100f, 100f), "Load"))
		{
			this.scrMedia.Load("EasyMovieTexture.mp4");
			this.m_bFinish = false;
		}
		if (GUI.Button(new Rect(50f, 200f, 100f, 100f), "Play"))
		{
			this.scrMedia.Play();
			this.m_bFinish = false;
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
		if (GUI.Button(new Rect(50f, 800f, 100f, 100f), " " + this.m_bFinish))
		{
		}
		if (GUI.Button(new Rect(200f, 50f, 100f, 100f), "SeekTo"))
		{
			this.scrMedia.SeekTo(10000);
		}
		if (this.scrMedia.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
		{
			if (GUI.Button(new Rect(200f, 200f, 100f, 100f), this.scrMedia.GetSeekPosition().ToString()))
			{
				this.scrMedia.SetSpeed(2f);
			}
			if (GUI.Button(new Rect(200f, 350f, 100f, 100f), this.scrMedia.GetDuration().ToString()))
			{
				this.scrMedia.SetSpeed(1f);
			}
			if (GUI.Button(new Rect(200f, 450f, 100f, 100f), this.scrMedia.GetVideoWidth().ToString()))
			{
			}
			if (GUI.Button(new Rect(200f, 550f, 100f, 100f), this.scrMedia.GetVideoHeight().ToString()))
			{
			}
		}
		if (GUI.Button(new Rect(200f, 650f, 100f, 100f), this.scrMedia.GetCurrentSeekPercent().ToString()))
		{
		}
	}

	// Token: 0x0601ACDA RID: 109786 RVA: 0x0083E9AD File Offset: 0x0083CDAD
	private void OnEnd()
	{
		this.m_bFinish = true;
	}

	// Token: 0x04012A70 RID: 76400
	public MediaPlayerCtrl scrMedia;

	// Token: 0x04012A71 RID: 76401
	public bool m_bFinish;
}
