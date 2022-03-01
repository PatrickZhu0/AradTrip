using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001612 RID: 5650
	public class GuildDungeonBossDiffSetFrame : ClientFrame
	{
		// Token: 0x0600DD6E RID: 56686 RVA: 0x00382149 File Offset: 0x00380549
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonBossDiffSet";
		}

		// Token: 0x0600DD6F RID: 56687 RVA: 0x00382150 File Offset: 0x00380550
		protected override void _OnOpenFrame()
		{
			this.itemDataList = null;
			this.InitTitleAndHelp();
			this.InitItems();
			this.UpdateItems();
			this.BindUIEvent();
		}

		// Token: 0x0600DD70 RID: 56688 RVA: 0x00382171 File Offset: 0x00380571
		protected override void _OnCloseFrame()
		{
			this.itemDataList = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600DD71 RID: 56689 RVA: 0x00382180 File Offset: 0x00380580
		protected override void _bindExUI()
		{
			this.itemList = this.mBind.GetCom<ComUIListScript>("itemList");
			this.Close = this.mBind.GetCom<Button>("Close");
			this.Close.SafeAddOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<GuildDungeonBossDiffSetFrame>(this, false);
			});
		}

		// Token: 0x0600DD72 RID: 56690 RVA: 0x003821D0 File Offset: 0x003805D0
		protected override void _unbindExUI()
		{
			this.itemList = null;
			this.Close = null;
		}

		// Token: 0x0600DD73 RID: 56691 RVA: 0x003821E0 File Offset: 0x003805E0
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonSetBossDiff, new ClientEventSystem.UIEventHandler(this._OnUpdateItems));
		}

		// Token: 0x0600DD74 RID: 56692 RVA: 0x003821FD File Offset: 0x003805FD
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonSetBossDiff, new ClientEventSystem.UIEventHandler(this._OnUpdateItems));
		}

		// Token: 0x0600DD75 RID: 56693 RVA: 0x0038221C File Offset: 0x0038061C
		private void InitItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.itemList.Initialize();
			this.itemList.onBindItem = delegate(GameObject go)
			{
				GuildDungeonBossDiffSetItem result = null;
				if (go)
				{
					result = go.GetComponent<GuildDungeonBossDiffSetItem>();
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
					GuildDungeonBossDiffSetItem guildDungeonBossDiffSetItem = var1.gameObjectBindScript as GuildDungeonBossDiffSetItem;
					if (guildDungeonBossDiffSetItem != null)
					{
						guildDungeonBossDiffSetItem.SetUp(this.itemDataList[index], this);
					}
				}
			};
		}

		// Token: 0x0600DD76 RID: 56694 RVA: 0x00382285 File Offset: 0x00380685
		private void InitTitleAndHelp()
		{
		}

		// Token: 0x0600DD77 RID: 56695 RVA: 0x00382288 File Offset: 0x00380688
		private void CalItemDataList()
		{
			this.itemDataList = new List<int>();
			if (this.itemDataList == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonTypeTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonTypeTable guildDungeonTypeTable = keyValuePair.Value as GuildDungeonTypeTable;
					if (guildDungeonTypeTable != null)
					{
						this.itemDataList.Add(guildDungeonTypeTable.dungeonType);
					}
				}
			}
		}

		// Token: 0x0600DD78 RID: 56696 RVA: 0x00382308 File Offset: 0x00380708
		private void UpdateItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.CalItemDataList();
			if (this.itemDataList != null)
			{
				this.itemList.SetElementAmount(0);
				this.itemList.SetElementAmount(this.itemDataList.Count);
			}
		}

		// Token: 0x0600DD79 RID: 56697 RVA: 0x0038235A File Offset: 0x0038075A
		private void _OnUpdateItems(UIEvent uiEvent)
		{
			this.UpdateItems();
		}

		// Token: 0x04008305 RID: 33541
		private List<int> itemDataList;

		// Token: 0x04008306 RID: 33542
		private ComUIListScript itemList;

		// Token: 0x04008307 RID: 33543
		private new Button Close;
	}
}
