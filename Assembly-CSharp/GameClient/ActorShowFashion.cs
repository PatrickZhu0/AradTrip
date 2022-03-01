using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013EF RID: 5103
	internal class ActorShowFashion : ClientFrame
	{
		// Token: 0x0600C5C7 RID: 50631 RVA: 0x002FAAEA File Offset: 0x002F8EEA
		public override string GetPrefabPath()
		{
			this.m_kData = (this.userData as ActorShowEquipData);
			if (!string.IsNullOrEmpty(this.m_kData.prefabPath))
			{
				return this.m_kData.prefabPath;
			}
			return "UIFlatten/Prefabs/ActorShow/ActorShowFashion";
		}

		// Token: 0x0600C5C8 RID: 50632 RVA: 0x002FAB24 File Offset: 0x002F8F24
		protected override void _OnOpenFrame()
		{
			this.m_akCachedEquiptItemObjects.Clear();
			this.m_kData = (this.userData as ActorShowEquipData);
			this._InitSlots();
			this._InitFashions();
			ActorShowFashion.FashionItemObject.onItemClicked = (ComItem.OnItemClicked)Delegate.Combine(ActorShowFashion.FashionItemObject.onItemClicked, new ComItem.OnItemClicked(this._OnFashionClicked));
		}

		// Token: 0x0600C5C9 RID: 50633 RVA: 0x002FAB7C File Offset: 0x002F8F7C
		private ItemData _GetCompareItem(ItemData item)
		{
			ItemData result = null;
			if (item != null && item.WillCanEquip())
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
				if (itemsByPackageType != null)
				{
					for (int i = 0; i < itemsByPackageType.Count; i++)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
						if (item2 != null && item2.GUID != item.GUID && item2.IsWearSoltEqual(item))
						{
							result = item2;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600C5CA RID: 50634 RVA: 0x002FAC04 File Offset: 0x002F9004
		private void _OnFashionClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				if (!this.m_kData.bCompare)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				}
				else
				{
					ItemData itemData = this._GetCompareItem(item);
					if (itemData != null)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTipWithCompareItem(item, itemData, null, true);
					}
					else
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
					}
				}
			}
		}

		// Token: 0x0600C5CB RID: 50635 RVA: 0x002FAC6D File Offset: 0x002F906D
		protected override void _OnCloseFrame()
		{
			this.m_kData = null;
			this.m_akCachedEquiptItemObjects.Clear();
			ActorShowFashion.FashionItemObject.onItemClicked = (ComItem.OnItemClicked)Delegate.Remove(ActorShowFashion.FashionItemObject.onItemClicked, new ComItem.OnItemClicked(this._OnFashionClicked));
		}

		// Token: 0x0600C5CC RID: 50636 RVA: 0x002FACA4 File Offset: 0x002F90A4
		private void _InitSlots()
		{
			this.m_goLeft = Utility.FindChild(this.frame, "Fashions/Left");
			this.m_goRight = Utility.FindChild(this.frame, "Fashions/Right");
			List<ComItem> list = new List<ComItem>();
			int num = 8;
			for (int i = 0; i < num; i++)
			{
				ComItem item = base.CreateComItem((i >= num / 2) ? this.m_goLeft : this.m_goRight);
				list.Add(item);
			}
			for (int j = 1; j < 9; j++)
			{
				MapIndex enumAttribute = Utility.GetEnumAttribute<EFashionWearSlotType, MapIndex>((EFashionWearSlotType)j);
				if (enumAttribute.Index >= 0 && enumAttribute.Index < list.Count)
				{
					ComItem comItem = list[enumAttribute.Index];
					GameObject gameObject = comItem.transform.parent.gameObject;
					GameObject gameObject2 = comItem.transform.gameObject;
					EFashionWearSlotType efashionWearSlotType = (EFashionWearSlotType)j;
					CachedObjectDicManager<EFashionWearSlotType, ActorShowFashion.FashionItemObject> akCachedEquiptItemObjects = this.m_akCachedEquiptItemObjects;
					EFashionWearSlotType key = efashionWearSlotType;
					object[] array = new object[5];
					array[0] = gameObject;
					array[1] = gameObject2;
					array[2] = efashionWearSlotType;
					array[3] = this;
					akCachedEquiptItemObjects.Create(key, array);
				}
			}
		}

		// Token: 0x0600C5CD RID: 50637 RVA: 0x002FADC0 File Offset: 0x002F91C0
		private void _InitFashions()
		{
			if (this.m_kData.m_akFashions != null)
			{
				for (int i = 0; i < this.m_kData.m_akFashions.Count; i++)
				{
					ItemData itemData = this.m_kData.m_akFashions[i];
					if (itemData != null && this.m_akCachedEquiptItemObjects.HasObject(itemData.FashionWearSlotType))
					{
						this.m_akCachedEquiptItemObjects.RefreshObject(itemData.FashionWearSlotType, new object[]
						{
							itemData
						});
					}
				}
			}
		}

		// Token: 0x0400711E RID: 28958
		private ActorShowEquipData m_kData;

		// Token: 0x0400711F RID: 28959
		private GameObject m_goLeft;

		// Token: 0x04007120 RID: 28960
		private GameObject m_goRight;

		// Token: 0x04007121 RID: 28961
		private CachedObjectDicManager<EFashionWearSlotType, ActorShowFashion.FashionItemObject> m_akCachedEquiptItemObjects = new CachedObjectDicManager<EFashionWearSlotType, ActorShowFashion.FashionItemObject>();

		// Token: 0x020013F0 RID: 5104
		public class FashionItemObject : CachedObject
		{
			// Token: 0x0600C5CF RID: 50639 RVA: 0x002FAE50 File Offset: 0x002F9250
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goLocal = (param[1] as GameObject);
				this.eEFashionWearSlotType = (EFashionWearSlotType)param[2];
				this.THIS = (param[3] as ActorShowEquip);
				this.itemData = (param[4] as ItemData);
				this.comItem = this.goLocal.GetComponent<ComItem>();
				this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x0600C5D0 RID: 50640 RVA: 0x002FAEDD File Offset: 0x002F92DD
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600C5D1 RID: 50641 RVA: 0x002FAEE5 File Offset: 0x002F92E5
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600C5D2 RID: 50642 RVA: 0x002FAF04 File Offset: 0x002F9304
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C5D3 RID: 50643 RVA: 0x002FAF23 File Offset: 0x002F9323
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C5D4 RID: 50644 RVA: 0x002FAF2C File Offset: 0x002F932C
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(new object[]
				{
					this.goParent,
					this.goLocal,
					this.eEFashionWearSlotType,
					this.THIS,
					param[0]
				});
			}

			// Token: 0x0600C5D5 RID: 50645 RVA: 0x002FAF69 File Offset: 0x002F9369
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600C5D6 RID: 50646 RVA: 0x002FAF6C File Offset: 0x002F936C
			private void _UpdateItem()
			{
				string text = Utility.GetEnumDescription<EFashionWearSlotType>(this.eEFashionWearSlotType);
				text = TR.Value(text);
				this.comItem.SetupSlot(ComItem.ESlotType.Opened, text, null, string.Empty);
			}

			// Token: 0x0600C5D7 RID: 50647 RVA: 0x002FAF9F File Offset: 0x002F939F
			private void OnItemClicked(GameObject obj, ItemData item)
			{
				if (ActorShowFashion.FashionItemObject.onItemClicked != null)
				{
					ActorShowFashion.FashionItemObject.onItemClicked(obj, item);
				}
			}

			// Token: 0x04007122 RID: 28962
			protected GameObject goLocal;

			// Token: 0x04007123 RID: 28963
			protected GameObject goParent;

			// Token: 0x04007124 RID: 28964
			protected EFashionWearSlotType eEFashionWearSlotType;

			// Token: 0x04007125 RID: 28965
			protected ActorShowEquip THIS;

			// Token: 0x04007126 RID: 28966
			public static ComItem.OnItemClicked onItemClicked;

			// Token: 0x04007127 RID: 28967
			private ComItem comItem;

			// Token: 0x04007128 RID: 28968
			private ItemData itemData;
		}
	}
}
