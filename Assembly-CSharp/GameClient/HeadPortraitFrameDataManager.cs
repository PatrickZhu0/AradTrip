using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001278 RID: 4728
	public class HeadPortraitFrameDataManager : DataManager<HeadPortraitFrameDataManager>
	{
		// Token: 0x17001AEA RID: 6890
		// (get) Token: 0x0600B5DD RID: 46557 RVA: 0x0028FE37 File Offset: 0x0028E237
		// (set) Token: 0x0600B5DE RID: 46558 RVA: 0x0028FE3E File Offset: 0x0028E23E
		public static int WearHeadPortraitFrameID
		{
			get
			{
				return HeadPortraitFrameDataManager.wearHeadPortraitFrameID;
			}
			set
			{
				HeadPortraitFrameDataManager.wearHeadPortraitFrameID = value;
			}
		}

		// Token: 0x0600B5DF RID: 46559 RVA: 0x0028FE48 File Offset: 0x0028E248
		public List<HeadPortraitItemData> GetHeadPortraitItemList(HeadPortraitTabType tabType)
		{
			List<HeadPortraitItemData> result = null;
			if (this.mHeadPortraitItemDataDict.TryGetValue(tabType, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0600B5E0 RID: 46560 RVA: 0x0028FE6D File Offset: 0x0028E26D
		public sealed override void Clear()
		{
			if (this.mHeadPortraitItemDataDict != null)
			{
				this.mHeadPortraitItemDataDict.Clear();
			}
			HeadPortraitFrameDataManager.tabHasNew = new int[4];
			this.UnRegisterNetHandler();
			HeadPortraitFrameDataManager.wearHeadPortraitFrameID = 0;
		}

		// Token: 0x0600B5E1 RID: 46561 RVA: 0x0028FE9C File Offset: 0x0028E29C
		public sealed override void Initialize()
		{
			this.RegisterNetHandler();
			this.InitLocalData();
		}

		// Token: 0x0600B5E2 RID: 46562 RVA: 0x0028FEAC File Offset: 0x0028E2AC
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(509102U, new Action<MsgDATA>(this.OnSceneHeadFrameRes));
			NetProcess.AddMsgHandler(509104U, new Action<MsgDATA>(this.OnSceneHeadFrameUseRes));
			NetProcess.AddMsgHandler(509105U, new Action<MsgDATA>(this.OnSceneHeadFrameNotify));
		}

		// Token: 0x0600B5E3 RID: 46563 RVA: 0x0028FEFC File Offset: 0x0028E2FC
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(509102U, new Action<MsgDATA>(this.OnSceneHeadFrameRes));
			NetProcess.RemoveMsgHandler(509104U, new Action<MsgDATA>(this.OnSceneHeadFrameUseRes));
			NetProcess.RemoveMsgHandler(509105U, new Action<MsgDATA>(this.OnSceneHeadFrameNotify));
		}

		// Token: 0x0600B5E4 RID: 46564 RVA: 0x0028FF4C File Offset: 0x0028E34C
		private void InitLocalData()
		{
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<PictureFrameTable>())
			{
				PictureFrameTable pictureFrameTable = keyValuePair.Value as PictureFrameTable;
				if (pictureFrameTable != null)
				{
					if (!this.mHeadPortraitItemDataDict.ContainsKey((HeadPortraitTabType)pictureFrameTable.TabID))
					{
						this.mHeadPortraitItemDataDict.Add((HeadPortraitTabType)pictureFrameTable.TabID, new List<HeadPortraitItemData>());
					}
					if (!this.mHeadPortraitItemDataDict.ContainsKey(HeadPortraitTabType.HPTT_ALL))
					{
						this.mHeadPortraitItemDataDict.Add(HeadPortraitTabType.HPTT_ALL, new List<HeadPortraitItemData>());
					}
					HeadPortraitItemData item = new HeadPortraitItemData((HeadPortraitTabType)pictureFrameTable.TabID, pictureFrameTable);
					HeadPortraitItemData item2 = new HeadPortraitItemData(HeadPortraitTabType.HPTT_ALL, pictureFrameTable);
					this.mHeadPortraitItemDataDict[(HeadPortraitTabType)pictureFrameTable.TabID].Add(item);
					this.mHeadPortraitItemDataDict[HeadPortraitTabType.HPTT_ALL].Add(item2);
				}
			}
		}

		// Token: 0x0600B5E5 RID: 46565 RVA: 0x00290028 File Offset: 0x0028E428
		public void OnSendSceneHeadFrameReq()
		{
			SceneHeadFrameReq cmd = new SceneHeadFrameReq();
			MonoSingleton<NetManager>.instance.SendCommand<SceneHeadFrameReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B5E6 RID: 46566 RVA: 0x00290048 File Offset: 0x0028E448
		public void OnSendSceneHeadFrameUseReq(uint headFrameId)
		{
			SceneHeadFrameUseReq sceneHeadFrameUseReq = new SceneHeadFrameUseReq();
			sceneHeadFrameUseReq.headFrameId = headFrameId;
			MonoSingleton<NetManager>.instance.SendCommand<SceneHeadFrameUseReq>(ServerType.GATE_SERVER, sceneHeadFrameUseReq);
		}

		// Token: 0x0600B5E7 RID: 46567 RVA: 0x00290070 File Offset: 0x0028E470
		private void OnSceneHeadFrameRes(MsgDATA msg)
		{
			SceneHeadFrameRes sceneHeadFrameRes = new SceneHeadFrameRes();
			sceneHeadFrameRes.decode(msg.bytes);
			for (int i = 0; i < sceneHeadFrameRes.headFrameList.Length; i++)
			{
				HeadFrame headFrame = sceneHeadFrameRes.headFrameList[i];
				foreach (KeyValuePair<HeadPortraitTabType, List<HeadPortraitItemData>> keyValuePair in this.mHeadPortraitItemDataDict)
				{
					List<HeadPortraitItemData> value = keyValuePair.Value;
					for (int j = 0; j < value.Count; j++)
					{
						HeadPortraitItemData headPortraitItemData = value[j];
						if (headPortraitItemData != null)
						{
							if ((long)headPortraitItemData.itemID == (long)((ulong)headFrame.headFrameId))
							{
								headPortraitItemData.expireTime = (int)headFrame.expireTime;
								headPortraitItemData.isObtain = true;
								headPortraitItemData.isNew = false;
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600B5E8 RID: 46568 RVA: 0x00290150 File Offset: 0x0028E550
		private void OnSceneHeadFrameUseRes(MsgDATA msg)
		{
			SceneHeadFrameUseRes sceneHeadFrameUseRes = new SceneHeadFrameUseRes();
			sceneHeadFrameUseRes.decode(msg.bytes);
			if (sceneHeadFrameUseRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneHeadFrameUseRes.retCode, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UseHeadPortraitFrameSuccess, null, null, null, null);
			}
		}

		// Token: 0x0600B5E9 RID: 46569 RVA: 0x002901A4 File Offset: 0x0028E5A4
		private void OnSceneHeadFrameNotify(MsgDATA msg)
		{
			SceneHeadFrameNotify sceneHeadFrameNotify = new SceneHeadFrameNotify();
			sceneHeadFrameNotify.decode(msg.bytes);
			foreach (KeyValuePair<HeadPortraitTabType, List<HeadPortraitItemData>> keyValuePair in this.mHeadPortraitItemDataDict)
			{
				List<HeadPortraitItemData> value = keyValuePair.Value;
				for (int i = 0; i < value.Count; i++)
				{
					HeadPortraitItemData headPortraitItemData = value[i];
					if (headPortraitItemData != null)
					{
						if ((long)headPortraitItemData.itemID == (long)((ulong)sceneHeadFrameNotify.headFrame.headFrameId))
						{
							headPortraitItemData.isObtain = (sceneHeadFrameNotify.isGet == 1U);
							headPortraitItemData.expireTime = (int)sceneHeadFrameNotify.headFrame.expireTime;
							headPortraitItemData.isNew = (sceneHeadFrameNotify.isGet == 1U);
							if (headPortraitItemData.isNew)
							{
								if (headPortraitItemData.tabType >= HeadPortraitTabType.HPTT_ALL && headPortraitItemData.tabType < HeadPortraitTabType.HPTT_COUNT)
								{
									HeadPortraitFrameDataManager.tabHasNew[(int)headPortraitItemData.tabType]++;
								}
							}
							else if (headPortraitItemData.tabType >= HeadPortraitTabType.HPTT_ALL && headPortraitItemData.tabType < HeadPortraitTabType.HPTT_COUNT && HeadPortraitFrameDataManager.tabHasNew[(int)headPortraitItemData.tabType] > 0)
							{
								HeadPortraitFrameDataManager.tabHasNew[(int)headPortraitItemData.tabType]--;
							}
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HeadPortraitItemStateChanged, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HeadPortraitFrameNotify, null, null, null, null);
		}

		// Token: 0x0600B5EA RID: 46570 RVA: 0x0029031C File Offset: 0x0028E71C
		public void NotifyItemBeOld(HeadPortraitItemData item)
		{
			if (item != null && item.isNew)
			{
				item.isNew = false;
				if (item.tabType >= HeadPortraitTabType.HPTT_ALL && item.tabType < HeadPortraitTabType.HPTT_COUNT)
				{
					HeadPortraitFrameDataManager.tabHasNew[(int)item.tabType]--;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HeadPortraitItemStateChanged, null, null, null, null);
			}
		}

		// Token: 0x0600B5EB RID: 46571 RVA: 0x00290381 File Offset: 0x0028E781
		public static bool IsHeadPortraitItemHasNew(HeadPortraitTabType type)
		{
			return type >= HeadPortraitTabType.HPTT_ALL && type < HeadPortraitTabType.HPTT_COUNT && HeadPortraitFrameDataManager.tabHasNew[(int)type] > 0;
		}

		// Token: 0x0600B5EC RID: 46572 RVA: 0x002903A8 File Offset: 0x0028E7A8
		public static string GetHeadPortraitFramePath(int id)
		{
			PictureFrameTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PictureFrameTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return tableItem.IconPath;
		}

		// Token: 0x040066D0 RID: 26320
		public Dictionary<HeadPortraitTabType, List<HeadPortraitItemData>> mHeadPortraitItemDataDict = new Dictionary<HeadPortraitTabType, List<HeadPortraitItemData>>();

		// Token: 0x040066D1 RID: 26321
		private static int wearHeadPortraitFrameID = 0;

		// Token: 0x040066D2 RID: 26322
		public static int iDefaultHeadPortraitID = 130194001;

		// Token: 0x040066D3 RID: 26323
		protected static int[] tabHasNew = new int[4];
	}
}
