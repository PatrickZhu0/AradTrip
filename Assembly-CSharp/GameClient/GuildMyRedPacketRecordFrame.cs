using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001641 RID: 5697
	public class GuildMyRedPacketRecordFrame : ClientFrame
	{
		// Token: 0x0600E02E RID: 57390 RVA: 0x00394CEF File Offset: 0x003930EF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildMyRedPacketRecord";
		}

		// Token: 0x0600E02F RID: 57391 RVA: 0x00394CF6 File Offset: 0x003930F6
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this.dataList = new List<GuildMyRedPacketRecordFrame.GuildMyRedPackRecordData>();
			this.UpdateItemList();
			this.UpdateRecords();
		}

		// Token: 0x0600E030 RID: 57392 RVA: 0x00394D15 File Offset: 0x00393115
		protected override void _OnCloseFrame()
		{
			this.dataList = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600E031 RID: 57393 RVA: 0x00394D24 File Offset: 0x00393124
		protected override void _bindExUI()
		{
			this.itemList = this.mBind.GetCom<ComUIListScript>("itemList");
			this.recordItems = this.mBind.GetCom<ScrollRect>("recordItems");
			this.recordContent = this.mBind.GetCom<Text>("recordContent");
		}

		// Token: 0x0600E032 RID: 57394 RVA: 0x00394D73 File Offset: 0x00393173
		protected override void _unbindExUI()
		{
			this.itemList = null;
			this.recordItems = null;
			this.recordContent = null;
		}

		// Token: 0x0600E033 RID: 57395 RVA: 0x00394D8A File Offset: 0x0039318A
		private void BindUIEvent()
		{
		}

		// Token: 0x0600E034 RID: 57396 RVA: 0x00394D8C File Offset: 0x0039318C
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600E035 RID: 57397 RVA: 0x00394D8E File Offset: 0x0039318E
		private void UpdateListItem(ComUIListElementScript item)
		{
		}

		// Token: 0x0600E036 RID: 57398 RVA: 0x00394D90 File Offset: 0x00393190
		private void UpdateItemList()
		{
			if (this.itemList == null)
			{
				return;
			}
			if (this.dataList == null)
			{
				return;
			}
			this.itemList.Initialize();
			this.itemList.onBindItem = ((GameObject item) => null);
			this.itemList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				this.UpdateListItem(item);
			};
			this.itemList.OnItemUpdate = delegate(ComUIListElementScript item)
			{
				this.UpdateListItem(item);
			};
			this.itemList.UpdateElementAmount(this.dataList.Count);
		}

		// Token: 0x0600E037 RID: 57399 RVA: 0x00394E34 File Offset: 0x00393234
		private string GetMoneyName(int moneyID)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(moneyID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Name;
			}
			return string.Empty;
		}

		// Token: 0x0600E038 RID: 57400 RVA: 0x00394E6C File Offset: 0x0039326C
		private void UpdateRecords()
		{
			if (this.recordContent == null)
			{
				return;
			}
			string text = string.Empty;
			Dictionary<ulong, RedPacketRecord> redPacketRecords = DataManager<RedPackDataManager>.GetInstance().GetRedPacketRecords();
			if (redPacketRecords == null)
			{
				return;
			}
			List<RedPacketRecord> list = new List<RedPacketRecord>();
			if (list == null)
			{
				return;
			}
			foreach (KeyValuePair<ulong, RedPacketRecord> keyValuePair in redPacketRecords)
			{
				RedPacketRecord value = keyValuePair.Value;
				if (value != null)
				{
					list.Add(value);
				}
			}
			list.Sort((RedPacketRecord a, RedPacketRecord b) => b.time.CompareTo(a.time));
			for (int i = 0; i < list.Count; i++)
			{
				RedPacketRecord redPacketRecord = list[i];
				if (redPacketRecord != null)
				{
					DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)redPacketRecord.time);
					text += string.Format(TR.Value("guild_red_packet_record_time"), new object[]
					{
						dateTimeByTimeStamp.Year,
						dateTimeByTimeStamp.Month,
						dateTimeByTimeStamp.Day,
						dateTimeByTimeStamp.Hour,
						dateTimeByTimeStamp.Minute
					});
					text += "\n";
					if (redPacketRecord.isBest == 0)
					{
						text += TR.Value("guild_red_packet_record_info", redPacketRecord.redPackOwnerName, redPacketRecord.moneyNum, this.GetMoneyName((int)redPacketRecord.moneyId));
					}
					else
					{
						text += TR.Value("guild_red_packet_record_best", redPacketRecord.redPackOwnerName, redPacketRecord.moneyNum, this.GetMoneyName((int)redPacketRecord.moneyId));
					}
					text += "\n";
				}
			}
			this.recordContent.SafeSetText(text);
		}

		// Token: 0x04008549 RID: 34121
		private List<GuildMyRedPacketRecordFrame.GuildMyRedPackRecordData> dataList;

		// Token: 0x0400854A RID: 34122
		private ComUIListScript itemList;

		// Token: 0x0400854B RID: 34123
		private ScrollRect recordItems;

		// Token: 0x0400854C RID: 34124
		private Text recordContent;

		// Token: 0x02001642 RID: 5698
		public class GuildMyRedPackRecordData
		{
		}
	}
}
