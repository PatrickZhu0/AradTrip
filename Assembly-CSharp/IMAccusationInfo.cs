using System;
using YIMEngine;

// Token: 0x02004ABF RID: 19135
public class IMAccusationInfo
{
	// Token: 0x0601BC65 RID: 113765 RVA: 0x0088374F File Offset: 0x00881B4F
	public IMAccusationInfo(AccusationDealResult result, string userID, uint time)
	{
		this._accDelResult = result;
		this._userID = userID;
		this._accusationTime = time;
	}

	// Token: 0x17002590 RID: 9616
	// (get) Token: 0x0601BC66 RID: 113766 RVA: 0x0088376C File Offset: 0x00881B6C
	public AccusationDealResult AccusationDealResult
	{
		get
		{
			return this._accDelResult;
		}
	}

	// Token: 0x17002591 RID: 9617
	// (get) Token: 0x0601BC67 RID: 113767 RVA: 0x00883774 File Offset: 0x00881B74
	public string UserID
	{
		get
		{
			return this._userID;
		}
	}

	// Token: 0x17002592 RID: 9618
	// (get) Token: 0x0601BC68 RID: 113768 RVA: 0x0088377C File Offset: 0x00881B7C
	public uint AccusationTime
	{
		get
		{
			return this._accusationTime;
		}
	}

	// Token: 0x040135CC RID: 79308
	private AccusationDealResult _accDelResult;

	// Token: 0x040135CD RID: 79309
	private string _userID;

	// Token: 0x040135CE RID: 79310
	private uint _accusationTime;
}
