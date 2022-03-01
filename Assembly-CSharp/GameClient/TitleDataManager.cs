using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001342 RID: 4930
	public class TitleDataManager : DataManager<TitleDataManager>
	{
		// Token: 0x0600BF65 RID: 48997 RVA: 0x002D09DA File Offset: 0x002CEDDA
		public override void Initialize()
		{
			this.allTitle.Clear();
			this._RegisterNetHandler();
		}

		// Token: 0x0600BF66 RID: 48998 RVA: 0x002D09ED File Offset: 0x002CEDED
		public override void Clear()
		{
			this.allTitle.Clear();
			this._UnRegisterNetHandler();
			DataManager<PlayerBaseData>.GetInstance().TitleGuid = 0UL;
			DataManager<PlayerBaseData>.GetInstance().WearedTitleInfo = null;
		}

		// Token: 0x0600BF67 RID: 48999 RVA: 0x002D0A17 File Offset: 0x002CEE17
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600BF68 RID: 49000 RVA: 0x002D0A1C File Offset: 0x002CEE1C
		private void _RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(609201U, new Action<MsgDATA>(this._OnWorldGetPlayerTitleSyncList));
			NetProcess.AddMsgHandler(609206U, new Action<MsgDATA>(this._OnWorldNewTitleSyncUpdate));
			NetProcess.AddMsgHandler(609203U, new Action<MsgDATA>(this._OnWorldNewTitleTakeUpRes));
			NetProcess.AddMsgHandler(609205U, new Action<MsgDATA>(this._OnWorldNewTitleTakeOffRes));
			NetProcess.AddMsgHandler(609207U, new Action<MsgDATA>(this._OnWorldNewTitleUpdateData));
		}

		// Token: 0x0600BF69 RID: 49001 RVA: 0x002D0A98 File Offset: 0x002CEE98
		private void _UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(609201U, new Action<MsgDATA>(this._OnWorldGetPlayerTitleSyncList));
			NetProcess.RemoveMsgHandler(609206U, new Action<MsgDATA>(this._OnWorldNewTitleSyncUpdate));
			NetProcess.RemoveMsgHandler(609203U, new Action<MsgDATA>(this._OnWorldNewTitleTakeUpRes));
			NetProcess.RemoveMsgHandler(609205U, new Action<MsgDATA>(this._OnWorldNewTitleTakeOffRes));
			NetProcess.RemoveMsgHandler(609207U, new Action<MsgDATA>(this._OnWorldNewTitleUpdateData));
		}

		// Token: 0x0600BF6A RID: 49002 RVA: 0x002D0B14 File Offset: 0x002CEF14
		public List<PlayerTitleInfo> getTitleListForSubType(int type)
		{
			List<PlayerTitleInfo> list = new List<PlayerTitleInfo>();
			if (type == 0)
			{
				return this.allTitle;
			}
			for (int i = 0; i < this.allTitle.Count; i++)
			{
				NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>((int)this.allTitle[i].titleId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SubType == (NewTitleTable.eSubType)type)
				{
					list.Add(this.allTitle[i]);
				}
			}
			return list;
		}

		// Token: 0x0600BF6B RID: 49003 RVA: 0x002D0B9C File Offset: 0x002CEF9C
		public void SendNewTitleTakeUpReq(ulong guid, uint titleId)
		{
			WorldNewTitleTakeUpReq worldNewTitleTakeUpReq = new WorldNewTitleTakeUpReq();
			worldNewTitleTakeUpReq.titleGuid = guid;
			worldNewTitleTakeUpReq.titleId = titleId;
			NetManager.Instance().SendCommand<WorldNewTitleTakeUpReq>(ServerType.GATE_SERVER, worldNewTitleTakeUpReq);
		}

		// Token: 0x0600BF6C RID: 49004 RVA: 0x002D0BCC File Offset: 0x002CEFCC
		public void SendNewTitleTakeOffReq(ulong guid, uint titleId)
		{
			WorldNewTitleTakeOffReq worldNewTitleTakeOffReq = new WorldNewTitleTakeOffReq();
			worldNewTitleTakeOffReq.titleGuid = guid;
			worldNewTitleTakeOffReq.titleId = titleId;
			NetManager.Instance().SendCommand<WorldNewTitleTakeOffReq>(ServerType.GATE_SERVER, worldNewTitleTakeOffReq);
		}

		// Token: 0x0600BF6D RID: 49005 RVA: 0x002D0BFC File Offset: 0x002CEFFC
		public bool IsHaveTitle()
		{
			PlayerWearedTitleInfo wearedTitleInfo = DataManager<PlayerBaseData>.GetInstance().WearedTitleInfo;
			return wearedTitleInfo != null && wearedTitleInfo.titleId != 0U;
		}

		// Token: 0x0600BF6E RID: 49006 RVA: 0x002D0C2C File Offset: 0x002CF02C
		private void _OnWorldGetPlayerTitleSyncList(MsgDATA msgData)
		{
			WorldGetPlayerTitleSyncList worldGetPlayerTitleSyncList = new WorldGetPlayerTitleSyncList();
			if (worldGetPlayerTitleSyncList == null)
			{
				return;
			}
			worldGetPlayerTitleSyncList.decode(msgData.bytes);
			this.allTitle.Clear();
			for (int i = 0; i < worldGetPlayerTitleSyncList.titles.Length; i++)
			{
				this.allTitle.Add(worldGetPlayerTitleSyncList.titles[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TitleDataUpdate, null, null, null, null);
		}

		// Token: 0x0600BF6F RID: 49007 RVA: 0x002D0C9C File Offset: 0x002CF09C
		private void _OnWorldNewTitleSyncUpdate(MsgDATA msgData)
		{
			WorldNewTitleSyncUpdate worldNewTitleSyncUpdate = new WorldNewTitleSyncUpdate();
			worldNewTitleSyncUpdate.decode(msgData.bytes);
			for (int i = 0; i < worldNewTitleSyncUpdate.adds.Length; i++)
			{
				bool flag = false;
				for (int j = 0; j < this.allTitle.Count; j++)
				{
					if (this.allTitle[j].guid == worldNewTitleSyncUpdate.adds[i].guid)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.allTitle.Add(worldNewTitleSyncUpdate.adds[i]);
				}
			}
			for (int k = 0; k < worldNewTitleSyncUpdate.dels.Length; k++)
			{
				for (int l = 0; l < this.allTitle.Count; l++)
				{
					if (this.allTitle[l].guid == worldNewTitleSyncUpdate.dels[k])
					{
						this.allTitle.RemoveAt(l);
						break;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TitleDataUpdate, null, null, null, null);
		}

		// Token: 0x0600BF70 RID: 49008 RVA: 0x002D0DB8 File Offset: 0x002CF1B8
		private void _OnWorldNewTitleTakeUpRes(MsgDATA msgData)
		{
			WorldNewTitleTakeUpRes worldNewTitleTakeUpRes = new WorldNewTitleTakeUpRes();
			if (worldNewTitleTakeUpRes == null)
			{
				return;
			}
			worldNewTitleTakeUpRes.decode(msgData.bytes);
			if (worldNewTitleTakeUpRes.res != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldNewTitleTakeUpRes.res, string.Empty);
				return;
			}
		}

		// Token: 0x0600BF71 RID: 49009 RVA: 0x002D0DFC File Offset: 0x002CF1FC
		private void _OnWorldNewTitleTakeOffRes(MsgDATA msgData)
		{
			WorldNewTitleTakeOffRes worldNewTitleTakeOffRes = new WorldNewTitleTakeOffRes();
			if (worldNewTitleTakeOffRes == null)
			{
				return;
			}
			worldNewTitleTakeOffRes.decode(msgData.bytes);
			if (worldNewTitleTakeOffRes.res != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldNewTitleTakeOffRes.res, string.Empty);
				return;
			}
		}

		// Token: 0x0600BF72 RID: 49010 RVA: 0x002D0E40 File Offset: 0x002CF240
		private void _OnWorldNewTitleUpdateData(MsgDATA msgData)
		{
			WorldNewTitleUpdateData worldNewTitleUpdateData = new WorldNewTitleUpdateData();
			if (worldNewTitleUpdateData == null)
			{
				return;
			}
			worldNewTitleUpdateData.decode(msgData.bytes);
			for (int i = 0; i < worldNewTitleUpdateData.updates.Length; i++)
			{
				for (int j = 0; j < this.allTitle.Count; j++)
				{
					if (worldNewTitleUpdateData.updates[i].guid == this.allTitle[j].guid)
					{
						this.allTitle[j] = worldNewTitleUpdateData.updates[i];
						break;
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TitleDataUpdate, null, null, null, null);
			}
		}

		// Token: 0x04006BF6 RID: 27638
		private List<PlayerTitleInfo> allTitle = new List<PlayerTitleInfo>();

		// Token: 0x02001343 RID: 4931
		public enum eTitleStyle
		{
			// Token: 0x04006BF8 RID: 27640
			Txt = 1,
			// Token: 0x04006BF9 RID: 27641
			Img,
			// Token: 0x04006BFA RID: 27642
			Group
		}
	}
}
