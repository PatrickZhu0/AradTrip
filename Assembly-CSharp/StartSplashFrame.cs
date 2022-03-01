using System;
using System.Collections;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02004648 RID: 17992
public class StartSplashFrame : ClientFrame
{
	// Token: 0x170020CF RID: 8399
	// (get) Token: 0x060194E5 RID: 103653 RVA: 0x00801B9D File Offset: 0x007FFF9D
	public bool IsSplashDone
	{
		get
		{
			return this.isSplashDone;
		}
	}

	// Token: 0x060194E6 RID: 103654 RVA: 0x00801BA5 File Offset: 0x007FFFA5
	public override string GetPrefabPath()
	{
		return "Base/UI/Prefabs/SplashFrame";
	}

	// Token: 0x060194E7 RID: 103655 RVA: 0x00801BAC File Offset: 0x007FFFAC
	protected override void _OnOpenFrame()
	{
		this.isSplashDone = false;
		this.splashPaths = SDKInterface.instance.GetSplashResourcePath();
		base.StartCoroutine(this.WaitToLoadSplash(this.durationTime));
	}

	// Token: 0x060194E8 RID: 103656 RVA: 0x00801BD8 File Offset: 0x007FFFD8
	protected override void _OnCloseFrame()
	{
		this.isSplashDone = true;
	}

	// Token: 0x060194E9 RID: 103657 RVA: 0x00801BE4 File Offset: 0x007FFFE4
	private IEnumerator WaitToLoadSplash(float duration)
	{
		if (this.splashPaths == null)
		{
			Logger.LogError("[StartSplashFrame] - WaitToLoadSplash splashPaths is null");
			base.Close(false);
			yield break;
		}
		this.splashCount = this.splashPaths.Length;
		int index = 0;
		while (this.splashCount > index)
		{
			this.SetSplashSprite(this.splashPaths[index]);
			yield return Yielders.GetWaitForSecondsRealtime(duration);
			index++;
		}
		base.Close(false);
		yield break;
	}

	// Token: 0x060194EA RID: 103658 RVA: 0x00801C06 File Offset: 0x00800006
	private void SetSplashSprite(string resPath)
	{
		if (this.splash)
		{
			this.splash.sprite = Resources.Load<Sprite>(resPath);
		}
	}

	// Token: 0x060194EB RID: 103659 RVA: 0x00801C29 File Offset: 0x00800029
	private void SetSplashActive(bool isShow)
	{
		if (this.splash)
		{
			this.splash.CustomActive(isShow);
		}
	}

	// Token: 0x040122A4 RID: 74404
	[UIControl("splash", null, 0)]
	private Image splash;

	// Token: 0x040122A5 RID: 74405
	protected bool isSplashDone;

	// Token: 0x040122A6 RID: 74406
	private float durationTime = 2f;

	// Token: 0x040122A7 RID: 74407
	private string[] splashPaths;

	// Token: 0x040122A8 RID: 74408
	private int splashCount;
}
