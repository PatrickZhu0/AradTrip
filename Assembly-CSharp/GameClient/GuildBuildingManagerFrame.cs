using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015FF RID: 5631
	public class GuildBuildingManagerFrame : ClientFrame
	{
		// Token: 0x0600DCA5 RID: 56485 RVA: 0x0037C3C0 File Offset: 0x0037A7C0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBuildingManager";
		}

		// Token: 0x0600DCA6 RID: 56486 RVA: 0x0037C3C7 File Offset: 0x0037A7C7
		protected override void _OnOpenFrame()
		{
			this.itemDataList = null;
			this.InitTitleAndHelp();
			this.InitItems();
			this.UpdateItems();
			this.BindUIEvent();
		}

		// Token: 0x0600DCA7 RID: 56487 RVA: 0x0037C3E8 File Offset: 0x0037A7E8
		protected override void _OnCloseFrame()
		{
			this.itemDataList = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600DCA8 RID: 56488 RVA: 0x0037C3F8 File Offset: 0x0037A7F8
		protected override void _bindExUI()
		{
			this.itemList = this.mBind.GetCom<ComUIListScript>("itemList");
			this.Close = this.mBind.GetCom<Button>("Close");
			this.Close.SafeSetOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<GuildBuildingManagerFrame>(this, false);
			});
		}

		// Token: 0x0600DCA9 RID: 56489 RVA: 0x0037C448 File Offset: 0x0037A848
		protected override void _unbindExUI()
		{
			this.itemList = null;
			this.Close = null;
		}

		// Token: 0x0600DCAA RID: 56490 RVA: 0x0037C458 File Offset: 0x0037A858
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildUpgradeBuildingSuccess, new ClientEventSystem.UIEventHandler(this._OnUpgradeBuildingSuccess));
		}

		// Token: 0x0600DCAB RID: 56491 RVA: 0x0037C475 File Offset: 0x0037A875
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildUpgradeBuildingSuccess, new ClientEventSystem.UIEventHandler(this._OnUpgradeBuildingSuccess));
		}

		// Token: 0x0600DCAC RID: 56492 RVA: 0x0037C494 File Offset: 0x0037A894
		private void InitItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.itemList.Initialize();
			this.itemList.onBindItem = delegate(GameObject go)
			{
				GuildBuildingItem result = null;
				if (go)
				{
					result = go.GetComponent<GuildBuildingItem>();
				}
				return result;
			};
			this.itemList.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && this.itemDataList != null && index < this.itemDataList.Count)
				{
					GuildBuildingItem guildBuildingItem = var1.gameObjectBindScript as GuildBuildingItem;
					if (guildBuildingItem != null)
					{
						guildBuildingItem.SetUp(this.itemDataList[index]);
					}
				}
			};
		}

		// Token: 0x0600DCAD RID: 56493 RVA: 0x0037C4FD File Offset: 0x0037A8FD
		private void InitTitleAndHelp()
		{
		}

		// Token: 0x0600DCAE RID: 56494 RVA: 0x0037C500 File Offset: 0x0037A900
		private void CalItemDataList()
		{
			this.itemDataList = null;
			GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
			if (myGuild != null && myGuild.dictBuildings != null)
			{
				this.itemDataList = new List<GuildBuildingData>();
				Dictionary<GuildBuildingType, GuildBuildingData> dictBuildings = myGuild.dictBuildings;
				if (dictBuildings != null)
				{
					foreach (KeyValuePair<GuildBuildingType, GuildBuildingData> keyValuePair in dictBuildings)
					{
						GuildBuildingData value = keyValuePair.Value;
						if (value != null)
						{
							GuildBuildInfoTable guildBuildInfoTable = DataManager<GuildDataManager>.GetInstance().GetGuildBuildInfoTable(value.eType);
							if (guildBuildInfoTable != null)
							{
								if (guildBuildInfoTable.isOpen)
								{
									this.itemDataList.Add(value);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600DCAF RID: 56495 RVA: 0x0037C5B2 File Offset: 0x0037A9B2
		private void UpdateItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.CalItemDataList();
			if (this.itemDataList != null)
			{
				this.itemList.SetElementAmount(this.itemDataList.Count);
			}
		}

		// Token: 0x0600DCB0 RID: 56496 RVA: 0x0037C5ED File Offset: 0x0037A9ED
		private void _OnUpgradeBuildingSuccess(UIEvent a_event)
		{
			this.UpdateItems();
		}

		// Token: 0x04008237 RID: 33335
		private List<GuildBuildingData> itemDataList;

		// Token: 0x04008238 RID: 33336
		private ComUIListScript itemList;

		// Token: 0x04008239 RID: 33337
		private new Button Close;
	}
}
