using System;
using UnityEngine;

// Token: 0x020048D3 RID: 18643
public class MediaPlayerEvent : MonoBehaviour
{
	// Token: 0x0601AD3A RID: 109882 RVA: 0x00840900 File Offset: 0x0083ED00
	private void Start()
	{
		MediaPlayerCtrl srcVideo = this.m_srcVideo;
		srcVideo.OnReady = (MediaPlayerCtrl.VideoReady)Delegate.Combine(srcVideo.OnReady, new MediaPlayerCtrl.VideoReady(this.OnReady));
		MediaPlayerCtrl srcVideo2 = this.m_srcVideo;
		srcVideo2.OnVideoFirstFrameReady = (MediaPlayerCtrl.VideoFirstFrameReady)Delegate.Combine(srcVideo2.OnVideoFirstFrameReady, new MediaPlayerCtrl.VideoFirstFrameReady(this.OnFirstFrameReady));
		MediaPlayerCtrl srcVideo3 = this.m_srcVideo;
		srcVideo3.OnVideoError = (MediaPlayerCtrl.VideoError)Delegate.Combine(srcVideo3.OnVideoError, new MediaPlayerCtrl.VideoError(this.OnError));
		MediaPlayerCtrl srcVideo4 = this.m_srcVideo;
		srcVideo4.OnEnd = (MediaPlayerCtrl.VideoEnd)Delegate.Combine(srcVideo4.OnEnd, new MediaPlayerCtrl.VideoEnd(this.OnEnd));
		MediaPlayerCtrl srcVideo5 = this.m_srcVideo;
		srcVideo5.OnResize = (MediaPlayerCtrl.VideoResize)Delegate.Combine(srcVideo5.OnResize, new MediaPlayerCtrl.VideoResize(this.OnResize));
	}

	// Token: 0x0601AD3B RID: 109883 RVA: 0x008409D0 File Offset: 0x0083EDD0
	private void Update()
	{
	}

	// Token: 0x0601AD3C RID: 109884 RVA: 0x008409D2 File Offset: 0x0083EDD2
	private void OnReady()
	{
		Debug.Log("OnReady");
	}

	// Token: 0x0601AD3D RID: 109885 RVA: 0x008409DE File Offset: 0x0083EDDE
	private void OnFirstFrameReady()
	{
		Debug.Log("OnFirstFrameReady");
	}

	// Token: 0x0601AD3E RID: 109886 RVA: 0x008409EA File Offset: 0x0083EDEA
	private void OnEnd()
	{
		Debug.Log("OnEnd");
	}

	// Token: 0x0601AD3F RID: 109887 RVA: 0x008409F6 File Offset: 0x0083EDF6
	private void OnResize()
	{
		Debug.Log("OnResize");
	}

	// Token: 0x0601AD40 RID: 109888 RVA: 0x00840A02 File Offset: 0x0083EE02
	private void OnError(MediaPlayerCtrl.MEDIAPLAYER_ERROR errorCode, MediaPlayerCtrl.MEDIAPLAYER_ERROR errorCodeExtra)
	{
		Debug.Log("OnError");
	}

	// Token: 0x04012AAD RID: 76461
	public MediaPlayerCtrl m_srcVideo;
}
