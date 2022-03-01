using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001AF6 RID: 6902
	internal class DevelopGuidanceEntranceFrame : ClientFrame
	{
		// Token: 0x06010F08 RID: 69384 RVA: 0x004D683B File Offset: 0x004D4C3B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/DevelopGuidanceFrame/DevelopGuidanceEntranceFrame";
		}

		// Token: 0x06010F09 RID: 69385 RVA: 0x004D6844 File Offset: 0x004D4C44
		private void _InitEntranceItems()
		{
			GameObject gameObject = Utility.FindChild(this.frame, "Content");
			GameObject gameObject2 = Utility.FindChild(this.frame, "Content/GuidanceItem");
			gameObject2.CustomActive(false);
			this.m_akGuidanceEntranceItems.RecycleAllObject();
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			GuidanceLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuidanceLevelTable>(level, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			for (int i = 0; i < tableItem.RelationIds.Count; i++)
			{
				GuidanceEntranceTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GuidanceEntranceTable>(tableItem.RelationIds[i], string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					FunctionUnLock tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(tableItem2.FunctionId, string.Empty, string.Empty);
					if (tableItem3 != null && tableItem3.FinishLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						this.m_akGuidanceEntranceItems.Create(new object[]
						{
							gameObject,
							gameObject2,
							new EntranceData
							{
								entranceItem = tableItem2
							},
							false
						});
					}
				}
			}
		}

		// Token: 0x06010F0A RID: 69386 RVA: 0x004D6973 File Offset: 0x004D4D73
		protected override void _OnOpenFrame()
		{
			this._InitEntranceItems();
		}

		// Token: 0x06010F0B RID: 69387 RVA: 0x004D697B File Offset: 0x004D4D7B
		protected override void _OnCloseFrame()
		{
			this.m_akGuidanceEntranceItems.DestroyAllObjects();
		}

		// Token: 0x06010F0C RID: 69388 RVA: 0x004D6988 File Offset: 0x004D4D88
		[UIEventHandle("Title/Close")]
		private void OnClickCloseFrame()
		{
			this.frameMgr.CloseFrame<DevelopGuidanceEntranceFrame>(this, false);
		}

		// Token: 0x06010F0D RID: 69389 RVA: 0x004D6997 File Offset: 0x004D4D97
		[UIEventHandle("BtnLink")]
		private void OnClickLink()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<DevelopGuidanceMainFrame>(FrameLayer.Middle, null, string.Empty);
			this.frameMgr.CloseFrame<DevelopGuidanceEntranceFrame>(this, false);
		}

		// Token: 0x0400AE22 RID: 44578
		private CachedObjectListManager<GuidanceEntrance> m_akGuidanceEntranceItems = new CachedObjectListManager<GuidanceEntrance>();
	}
}
