using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000FA2 RID: 4002
public class UIDebugConsole : MonoBehaviour
{
	// Token: 0x06009A81 RID: 39553 RVA: 0x001DDCC4 File Offset: 0x001DC0C4
	public void SetCurretLogMode(int mode)
	{
		mode &= 7;
		if ((this.currentLogLevel & mode) > 0)
		{
			this.currentLogLevel -= mode;
		}
		else
		{
			this.currentLogLevel |= mode;
		}
		this.GenerateLog();
	}

	// Token: 0x06009A82 RID: 39554 RVA: 0x001DDD00 File Offset: 0x001DC100
	private void GenerateLog()
	{
		this.errorMsg = string.Empty;
		if ((this.currentLogLevel & 1) > 0)
		{
			for (int i = 0; i < this.infoMsgList.Count; i++)
			{
				this.errorMsg += this.infoMsgList[i];
			}
		}
		if ((this.currentLogLevel & 2) > 0)
		{
			for (int j = 0; j < this.warningMsgList.Count; j++)
			{
				this.errorMsg += this.warningMsgList[j];
			}
		}
		if ((this.currentLogLevel & 4) > 0)
		{
			for (int k = 0; k < this.errorMsgList.Count; k++)
			{
				this.errorMsg += this.errorMsgList[k];
			}
		}
		if (this.currentLogLevel > 0)
		{
			base.gameObject.SetActive(true);
			this.text.text = this.errorMsg;
			this.CalculateLineAndRow();
			this.UpdateHeight();
		}
	}

	// Token: 0x06009A83 RID: 39555 RVA: 0x001DDE24 File Offset: 0x001DC224
	public void SetText(string text, UIDebugConsole.LogType type = UIDebugConsole.LogType.Log)
	{
		if (type != UIDebugConsole.LogType.Log)
		{
			if (type != UIDebugConsole.LogType.Warning)
			{
				if (type == UIDebugConsole.LogType.Error)
				{
					this.currentLogLevel |= 4;
					text = string.Format("<color={0}>{1}:\n{2}</color>\n******************************\n", this.ERROR_COLOR, this.iMsgNum++, text);
					this.errorMsgList.Add(text);
				}
			}
			else
			{
				text = string.Format("<color={0}>{1}:\n{2}</color>\n******************************\n", this.WARNING_COLOR, this.iMsgNum++, text);
				this.warningMsgList.Add(text);
			}
		}
		else
		{
			text = string.Format("<color={0}>{1}:\n{2}</color>\n******************************\n", this.INFO_COLOR, this.iMsgNum++, text);
			this.infoMsgList.Add(text);
		}
		this.GenerateLog();
	}

	// Token: 0x06009A84 RID: 39556 RVA: 0x001DDF0C File Offset: 0x001DC30C
	public void SetEnable(bool iEnable)
	{
		base.gameObject.SetActive(iEnable);
	}

	// Token: 0x06009A85 RID: 39557 RVA: 0x001DDF1C File Offset: 0x001DC31C
	private void CalculateLineAndRow()
	{
		this.iLine = 0;
		foreach (string text in this.errorMsg.Split(new char[]
		{
			'\n'
		}))
		{
			this.iLine++;
			if (this.iRow < text.Length)
			{
				this.iRow = text.Length;
			}
		}
	}

	// Token: 0x06009A86 RID: 39558 RVA: 0x001DDF8C File Offset: 0x001DC38C
	private void UpdateHeight()
	{
		Vector2 offsetMax = this.rectText.offsetMax;
		offsetMax.y = (float)(20 * this.iLine);
		this.rectText.offsetMax = offsetMax;
	}

	// Token: 0x06009A87 RID: 39559 RVA: 0x001DDFC2 File Offset: 0x001DC3C2
	public void ClearText()
	{
		this.errorMsg = string.Empty;
		this.text.text = string.Empty;
		this.errorMsgList.Clear();
		this.warningMsgList.Clear();
		this.infoMsgList.Clear();
	}

	// Token: 0x04005009 RID: 20489
	public Text text;

	// Token: 0x0400500A RID: 20490
	public RectTransform rectText;

	// Token: 0x0400500B RID: 20491
	private string errorMsg = string.Empty;

	// Token: 0x0400500C RID: 20492
	private int iMsgNum;

	// Token: 0x0400500D RID: 20493
	private string ERROR_COLOR = "#ff0000ff";

	// Token: 0x0400500E RID: 20494
	private string WARNING_COLOR = "#ff0000ff";

	// Token: 0x0400500F RID: 20495
	private string INFO_COLOR = "#000000ff";

	// Token: 0x04005010 RID: 20496
	private int currentLogLevel;

	// Token: 0x04005011 RID: 20497
	private List<string> errorMsgList = new List<string>();

	// Token: 0x04005012 RID: 20498
	private List<string> warningMsgList = new List<string>();

	// Token: 0x04005013 RID: 20499
	private List<string> infoMsgList = new List<string>();

	// Token: 0x04005014 RID: 20500
	private int iLine;

	// Token: 0x04005015 RID: 20501
	private int iRow;

	// Token: 0x02000FA3 RID: 4003
	public enum LogType
	{
		// Token: 0x04005017 RID: 20503
		Log,
		// Token: 0x04005018 RID: 20504
		Warning,
		// Token: 0x04005019 RID: 20505
		Error
	}
}
