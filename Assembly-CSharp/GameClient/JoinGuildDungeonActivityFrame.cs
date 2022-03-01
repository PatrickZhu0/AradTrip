using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001666 RID: 5734
	public class JoinGuildDungeonActivityFrame : ClientFrame
	{
		// Token: 0x0600E18D RID: 57741 RVA: 0x0039E014 File Offset: 0x0039C414
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/JoinGuildDungeonActivity";
		}

		// Token: 0x0600E18E RID: 57742 RVA: 0x0039E01C File Offset: 0x0039C41C
		protected override void _OnOpenFrame()
		{
			if (this.m_btnJoin != null)
			{
				this.m_btnJoin.onClick.RemoveAllListeners();
				this.m_btnJoin.onClick.AddListener(delegate()
				{
					DataManager<GuildDataManager>.GetInstance().SwitchToGuildScene();
					this.frameMgr.CloseFrame<JoinGuildDungeonActivityFrame>(this, false);
				});
			}
			if (this.m_btnClose != null)
			{
				this.m_btnClose.onClick.RemoveAllListeners();
				this.m_btnClose.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<JoinGuildDungeonActivityFrame>(this, false);
				});
			}
			this.UpdateAwardItems();
		}

		// Token: 0x0600E18F RID: 57743 RVA: 0x0039E0A9 File Offset: 0x0039C4A9
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600E190 RID: 57744 RVA: 0x0039E0AB File Offset: 0x0039C4AB
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0600E191 RID: 57745 RVA: 0x0039E0AE File Offset: 0x0039C4AE
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600E192 RID: 57746 RVA: 0x0039E0B0 File Offset: 0x0039C4B0
		private void UpdateAwardItems()
		{
			int id = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ActivityDungeonTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("TableManager.instance.GetTable<ActivityDungeonTable>() error!!!", new object[0]);
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ActivityDungeonTable activityDungeonTable = keyValuePair.Value as ActivityDungeonTable;
				if (activityDungeonTable != null)
				{
					if (activityDungeonTable.DungeonID == 56)
					{
						id = activityDungeonTable.ID;
						break;
					}
				}
			}
			ActivityDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActivityDungeonTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.DropItems.Length; i++)
				{
					if (i >= 4)
					{
						break;
					}
					int tableId = tableItem.DropItems[i];
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
					if (itemData != null)
					{
						ComItem com = this.mBind.GetCom<ComItem>(string.Format("Item{0}", i));
						if (!(com == null))
						{
							com.Setup(itemData, delegate(GameObject var1, ItemData var2)
							{
								DataManager<ItemTipManager>.GetInstance().CloseAll();
								DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
							});
						}
					}
				}
			}
		}

		// Token: 0x04008649 RID: 34377
		[UIControl("Join", null, 0)]
		private Button m_btnJoin;

		// Token: 0x0400864A RID: 34378
		[UIControl("Close", null, 0)]
		private Button m_btnClose;

		// Token: 0x0400864B RID: 34379
		private const int ITEM_NUM = 4;
	}
}
