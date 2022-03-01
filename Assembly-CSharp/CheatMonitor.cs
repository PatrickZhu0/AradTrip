using System;
using System.Collections;
using GameClient;
using Network;
using Protocol;
using UnityEngine;

// Token: 0x02000225 RID: 549
public class CheatMonitor : MonoSingleton<CheatMonitor>
{
	// Token: 0x06001244 RID: 4676 RVA: 0x000635A3 File Offset: 0x000619A3
	public override void Init()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06001245 RID: 4677 RVA: 0x000635B0 File Offset: 0x000619B0
	public void OnCheatingDetected()
	{
		if (!this.isReportCheated)
		{
			Debug.LogWarning("Report to server...");
			this.isReportCheated = true;
			SystemNotifyManager.SysNotifyMsgBoxOK("检测到内存非法修改！", null, string.Empty, false);
			this.ReportToServer();
			base.StartCoroutine(this.WaitForQuitGame());
		}
	}

	// Token: 0x06001246 RID: 4678 RVA: 0x00063600 File Offset: 0x00061A00
	private void ReportToServer()
	{
		WorldRelationReportCheat cmd = new WorldRelationReportCheat();
		MonoSingleton<NetManager>.instance.SendCommand<WorldRelationReportCheat>(ServerType.GATE_SERVER, cmd);
	}

	// Token: 0x06001247 RID: 4679 RVA: 0x00063620 File Offset: 0x00061A20
	private IEnumerator WaitForQuitGame()
	{
		yield return new WaitForSecondsRealtime(3f);
		this.ForceQuitGame();
		yield break;
	}

	// Token: 0x06001248 RID: 4680 RVA: 0x0006363B File Offset: 0x00061A3B
	private void ForceQuitGame()
	{
		Application.Quit();
	}

	// Token: 0x04000C33 RID: 3123
	private bool isReportCheated;
}
