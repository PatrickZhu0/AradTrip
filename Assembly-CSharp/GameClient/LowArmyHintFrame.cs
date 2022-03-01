using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001742 RID: 5954
	internal class LowArmyHintFrame : ClientFrame
	{
		// Token: 0x0600E9E2 RID: 59874 RVA: 0x003DF20D File Offset: 0x003DD60D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LowArmyHint/LowArmyHintFrame";
		}

		// Token: 0x0600E9E3 RID: 59875 RVA: 0x003DF214 File Offset: 0x003DD614
		protected override void _OnOpenFrame()
		{
			this.goPrefab.CustomActive(false);
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<LowArmyHintFrame>(this, false);
			});
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
					if (masterPriority == 2)
					{
						this.m_akLowArmyHintItems.Create(new object[]
						{
							this.goParent,
							this.goPrefab,
							new LowArmyHintItemData
							{
								itemData = item
							},
							false
						});
					}
				}
			}
		}

		// Token: 0x0600E9E4 RID: 59876 RVA: 0x003DF2F3 File Offset: 0x003DD6F3
		protected override void _OnCloseFrame()
		{
			this.m_akLowArmyHintItems.DestroyAllObjects();
		}

		// Token: 0x04008DD7 RID: 36311
		[UIObject("Records/Scroll View/Viewport/Content")]
		private GameObject goParent;

		// Token: 0x04008DD8 RID: 36312
		[UIObject("Records/Scroll View/Viewport/Content/Prefab")]
		private GameObject goPrefab;

		// Token: 0x04008DD9 RID: 36313
		private CachedObjectListManager<LowArmyHintItem> m_akLowArmyHintItems = new CachedObjectListManager<LowArmyHintItem>();
	}
}
