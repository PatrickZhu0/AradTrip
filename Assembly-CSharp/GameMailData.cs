using System;
using System.Collections.Generic;
using Protocol;

// Token: 0x0200462B RID: 17963
public class GameMailData
{
	// Token: 0x0601940D RID: 103437 RVA: 0x007FED20 File Offset: 0x007FD120
	public void ClearData()
	{
		this.mailList.Clear();
		this.mailDics.Clear();
		this.OneKeyDeleteNum = 0;
		this.OneKeyReceiveNum = 0;
		this.UnreadNum = 0;
		this.rewardMailList.Clear();
		this.rewardMailDics.Clear();
		this.OneKeyDeleteRewardNum = 0;
		this.OneKeyReceiveRewardNum = 0;
		this.UnreadRewardNum = 0;
	}

	// Token: 0x0601940E RID: 103438 RVA: 0x007FED84 File Offset: 0x007FD184
	public MailTitleInfo FindMailTitleInfo(List<MailTitleInfo> mailList, ulong id)
	{
		return mailList.Find((MailTitleInfo x) => x.id == id);
	}

	// Token: 0x0601940F RID: 103439 RVA: 0x007FEDB0 File Offset: 0x007FD1B0
	public GameMailData.MailData FindMailData(DictionaryView<ulong, GameMailData.MailData> mailDics, ulong id)
	{
		GameMailData.MailData result;
		if (mailDics.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06019410 RID: 103440 RVA: 0x007FEDD0 File Offset: 0x007FD1D0
	public void DeleteMailTitleInfo(ulong id)
	{
		for (int i = 0; i < this.mailList.Count; i++)
		{
			if (this.mailList[i].id == id)
			{
				this.mailList.RemoveAt(i);
				break;
			}
		}
	}

	// Token: 0x06019411 RID: 103441 RVA: 0x007FEE24 File Offset: 0x007FD224
	public void DeleteRewardMailTitleInfo(ulong id)
	{
		for (int i = 0; i < this.rewardMailList.Count; i++)
		{
			if (this.rewardMailList[i].id == id)
			{
				this.rewardMailList.RemoveAt(i);
				break;
			}
		}
	}

	// Token: 0x06019412 RID: 103442 RVA: 0x007FEE75 File Offset: 0x007FD275
	public void DeleteMailData(ulong id)
	{
		if (this.mailDics.ContainsKey(id))
		{
			this.mailDics.Remove(id);
		}
	}

	// Token: 0x06019413 RID: 103443 RVA: 0x007FEE95 File Offset: 0x007FD295
	public void DeleteRewardMailData(ulong id)
	{
		if (this.rewardMailDics.ContainsKey(id))
		{
			this.rewardMailDics.Remove(id);
		}
	}

	// Token: 0x06019414 RID: 103444 RVA: 0x007FEEB8 File Offset: 0x007FD2B8
	public void SortMailList()
	{
		List<MailTitleInfo> list = new List<MailTitleInfo>();
		List<MailTitleInfo> list2 = new List<MailTitleInfo>();
		for (int i = 0; i < this.mailList.Count; i++)
		{
			if (this.mailList[i].status == 0)
			{
				list.Add(this.mailList[i]);
			}
			else
			{
				list2.Add(this.mailList[i]);
			}
		}
		this.UnreadNum = list.Count;
		this.mailList = list;
		for (int j = 0; j < list2.Count; j++)
		{
			this.mailList.Add(list2[j]);
		}
	}

	// Token: 0x06019415 RID: 103445 RVA: 0x007FEF68 File Offset: 0x007FD368
	public void SortRewardMailList()
	{
		List<MailTitleInfo> list = new List<MailTitleInfo>();
		List<MailTitleInfo> list2 = new List<MailTitleInfo>();
		for (int i = 0; i < this.rewardMailList.Count; i++)
		{
			if (this.rewardMailList[i].status == 0)
			{
				list.Add(this.rewardMailList[i]);
			}
			else
			{
				list2.Add(this.rewardMailList[i]);
			}
		}
		this.UnreadRewardNum = list.Count;
		this.rewardMailList = list;
		for (int j = 0; j < list2.Count; j++)
		{
			this.rewardMailList.Add(list2[j]);
		}
	}

	// Token: 0x06019416 RID: 103446 RVA: 0x007FF018 File Offset: 0x007FD418
	public void UpdateOneKeyNum()
	{
		this.OneKeyDeleteNum = 0;
		this.OneKeyReceiveNum = 0;
		for (int i = 0; i < this.mailList.Count; i++)
		{
			if (this.mailList[i].hasItem == 0)
			{
				this.OneKeyDeleteNum++;
			}
			else
			{
				this.OneKeyReceiveNum++;
			}
		}
	}

	// Token: 0x06019417 RID: 103447 RVA: 0x007FF088 File Offset: 0x007FD488
	public void UpdateOneKeyRewardNum()
	{
		this.OneKeyDeleteRewardNum = 0;
		this.OneKeyReceiveRewardNum = 0;
		for (int i = 0; i < this.rewardMailList.Count; i++)
		{
			if (this.rewardMailList[i].hasItem == 0)
			{
				this.OneKeyDeleteRewardNum++;
			}
			else
			{
				this.OneKeyReceiveRewardNum++;
			}
		}
	}

	// Token: 0x06019418 RID: 103448 RVA: 0x007FF0F8 File Offset: 0x007FD4F8
	public List<ulong> GetDeleteMailList(List<MailTitleInfo> mailList)
	{
		List<ulong> list = new List<ulong>();
		for (int i = 0; i < mailList.Count; i++)
		{
			if (mailList[i].hasItem == 0)
			{
				list.Add(mailList[i].id);
			}
		}
		return list;
	}

	// Token: 0x040121D5 RID: 74197
	public List<MailTitleInfo> mailList = new List<MailTitleInfo>();

	// Token: 0x040121D6 RID: 74198
	public List<MailTitleInfo> rewardMailList = new List<MailTitleInfo>();

	// Token: 0x040121D7 RID: 74199
	public DictionaryView<ulong, GameMailData.MailData> mailDics = new DictionaryView<ulong, GameMailData.MailData>();

	// Token: 0x040121D8 RID: 74200
	public DictionaryView<ulong, GameMailData.MailData> rewardMailDics = new DictionaryView<ulong, GameMailData.MailData>();

	// Token: 0x040121D9 RID: 74201
	public int OneKeyDeleteNum;

	// Token: 0x040121DA RID: 74202
	public int OneKeyReceiveNum;

	// Token: 0x040121DB RID: 74203
	public int UnreadNum;

	// Token: 0x040121DC RID: 74204
	public int OneKeyDeleteRewardNum;

	// Token: 0x040121DD RID: 74205
	public int OneKeyReceiveRewardNum;

	// Token: 0x040121DE RID: 74206
	public int UnreadRewardNum;

	// Token: 0x0200462C RID: 17964
	public class MailData
	{
		// Token: 0x040121DF RID: 74207
		public MailTitleInfo info;

		// Token: 0x040121E0 RID: 74208
		public string content;

		// Token: 0x040121E1 RID: 74209
		public List<ItemReward> items = new List<ItemReward>();

		// Token: 0x040121E2 RID: 74210
		public List<Item> detailItems = new List<Item>();
	}
}
