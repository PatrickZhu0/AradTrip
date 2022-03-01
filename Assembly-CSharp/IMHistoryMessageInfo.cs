using System;
using System.Collections.Generic;
using YIMEngine;

// Token: 0x02004ABD RID: 19133
public class IMHistoryMessageInfo
{
	// Token: 0x0601BC5D RID: 113757 RVA: 0x008836E5 File Offset: 0x00881AE5
	public IMHistoryMessageInfo(string targetID, int remain, List<HistoryMsg> hisMsgList)
	{
		this._targetID = targetID;
		this._remain = remain;
		this._historyMsgList = hisMsgList;
	}

	// Token: 0x1700258A RID: 9610
	// (get) Token: 0x0601BC5E RID: 113758 RVA: 0x00883702 File Offset: 0x00881B02
	public string TargetID
	{
		get
		{
			return this._targetID;
		}
	}

	// Token: 0x1700258B RID: 9611
	// (get) Token: 0x0601BC5F RID: 113759 RVA: 0x0088370A File Offset: 0x00881B0A
	public int Remain
	{
		get
		{
			return this._remain;
		}
	}

	// Token: 0x1700258C RID: 9612
	// (get) Token: 0x0601BC60 RID: 113760 RVA: 0x00883712 File Offset: 0x00881B12
	public List<HistoryMsg> HistoryMesList
	{
		get
		{
			return this._historyMsgList;
		}
	}

	// Token: 0x040135C6 RID: 79302
	private string _targetID;

	// Token: 0x040135C7 RID: 79303
	private int _remain;

	// Token: 0x040135C8 RID: 79304
	private List<HistoryMsg> _historyMsgList;
}
