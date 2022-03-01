using System;
using System.Collections.Generic;
using Parser;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013ED RID: 5101
	internal class ActorShowEquip : ClientFrame
	{
		// Token: 0x0600C5B5 RID: 50613 RVA: 0x002FA6F8 File Offset: 0x002F8AF8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActorShow/ActorShowEquip";
		}

		// Token: 0x0600C5B6 RID: 50614 RVA: 0x002FA700 File Offset: 0x002F8B00
		protected override void _OnOpenFrame()
		{
			this.m_akCachedEquiptItemObjects.Clear();
			this.m_kData = (this.userData as ActorShowEquipData);
			if (this.m_kData != null)
			{
				ActorShowEquip.m_queryPlayerType = this.m_kData.m_queryPlayerType;
				ActorShowEquip.m_zoneId = this.m_kData.m_zoneId;
			}
			else
			{
				ActorShowEquip.m_queryPlayerType = 0U;
				ActorShowEquip.m_zoneId = 0U;
			}
			this._InitSlots();
			this._InitEquipts();
		}

		// Token: 0x0600C5B7 RID: 50615 RVA: 0x002FA771 File Offset: 0x002F8B71
		protected override void _OnCloseFrame()
		{
			this.m_akCachedEquiptItemObjects.Clear();
			ActorShowEquip.m_queryPlayerType = 0U;
			ActorShowEquip.m_zoneId = 0U;
		}

		// Token: 0x0600C5B8 RID: 50616 RVA: 0x002FA78C File Offset: 0x002F8B8C
		private void _InitSlots()
		{
			this.m_goLeft = Utility.FindChild(this.frame, "Equips/Left");
			this.m_goRight = Utility.FindChild(this.frame, "Equips/Right");
			List<ComItem> list = new List<ComItem>();
			int num = 101;
			for (int i = 0; i < num; i++)
			{
				ComItem item = base.CreateComItem((i >= num / 2) ? this.m_goRight : this.m_goLeft);
				list.Add(item);
			}
			for (int j = 1; j < 102; j++)
			{
				MapIndex enumAttribute = Utility.GetEnumAttribute<EEquipWearSlotType, MapIndex>((EEquipWearSlotType)j);
				if (enumAttribute.Index >= 0 && enumAttribute.Index < list.Count)
				{
					ComItem comItem = list[enumAttribute.Index];
					GameObject gameObject = comItem.transform.parent.gameObject;
					GameObject gameObject2 = comItem.transform.gameObject;
					EEquipWearSlotType eequipWearSlotType = (EEquipWearSlotType)j;
					CachedObjectDicManager<EEquipWearSlotType, ActorShowEquip.EquipItemObject> akCachedEquiptItemObjects = this.m_akCachedEquiptItemObjects;
					EEquipWearSlotType key = (EEquipWearSlotType)j;
					object[] array = new object[5];
					array[0] = gameObject;
					array[1] = gameObject2;
					array[2] = eequipWearSlotType;
					array[3] = this;
					akCachedEquiptItemObjects.Create(key, array);
				}
			}
		}

		// Token: 0x0600C5B9 RID: 50617 RVA: 0x002FA8A8 File Offset: 0x002F8CA8
		private void _InitEquipts()
		{
			if (this.m_kData.m_akEquipts != null)
			{
				for (int i = 0; i < this.m_kData.m_akEquipts.Count; i++)
				{
					ItemData itemData = this.m_kData.m_akEquipts[i];
					if (itemData != null && this.m_akCachedEquiptItemObjects.HasObject(itemData.EquipWearSlotType))
					{
						this.m_akCachedEquiptItemObjects.RefreshObject(itemData.EquipWearSlotType, new object[]
						{
							itemData
						});
					}
				}
			}
		}

		// Token: 0x0600C5BA RID: 50618 RVA: 0x002FA930 File Offset: 0x002F8D30
		[UIEventHandle("close")]
		private void OnClickClose()
		{
			this.CloseThisFrame();
		}

		// Token: 0x0600C5BB RID: 50619 RVA: 0x002FA938 File Offset: 0x002F8D38
		public void CloseThisFrame()
		{
			this.frameMgr.CloseFrame<ActorShowEquip>(this, false);
		}

		// Token: 0x04007112 RID: 28946
		public ActorShowEquipData m_kData;

		// Token: 0x04007113 RID: 28947
		public static uint m_queryPlayerType;

		// Token: 0x04007114 RID: 28948
		public static uint m_zoneId;

		// Token: 0x04007115 RID: 28949
		private GameObject m_goLeft;

		// Token: 0x04007116 RID: 28950
		private GameObject m_goRight;

		// Token: 0x04007117 RID: 28951
		private CachedObjectDicManager<EEquipWearSlotType, ActorShowEquip.EquipItemObject> m_akCachedEquiptItemObjects = new CachedObjectDicManager<EEquipWearSlotType, ActorShowEquip.EquipItemObject>();

		// Token: 0x020013EE RID: 5102
		public class EquipItemObject : CachedObject
		{
			// Token: 0x0600C5BD RID: 50621 RVA: 0x002FA950 File Offset: 0x002F8D50
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goLocal = (param[1] as GameObject);
				this.eEEquipWearSlotType = (EEquipWearSlotType)param[2];
				this.THIS = (param[3] as ActorShowEquip);
				this.itemData = (param[4] as ItemData);
				this.comItem = this.goLocal.GetComponent<ComItem>();
				this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x0600C5BE RID: 50622 RVA: 0x002FA9DD File Offset: 0x002F8DDD
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600C5BF RID: 50623 RVA: 0x002FA9E5 File Offset: 0x002F8DE5
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600C5C0 RID: 50624 RVA: 0x002FAA04 File Offset: 0x002F8E04
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C5C1 RID: 50625 RVA: 0x002FAA23 File Offset: 0x002F8E23
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C5C2 RID: 50626 RVA: 0x002FAA2C File Offset: 0x002F8E2C
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(new object[]
				{
					this.goParent,
					this.goLocal,
					this.eEEquipWearSlotType,
					this.THIS,
					param[0]
				});
			}

			// Token: 0x0600C5C3 RID: 50627 RVA: 0x002FAA69 File Offset: 0x002F8E69
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600C5C4 RID: 50628 RVA: 0x002FAA6C File Offset: 0x002F8E6C
			private void _UpdateItem()
			{
				string text = Utility.GetEnumDescription<EEquipWearSlotType>(this.eEEquipWearSlotType);
				text = TR.Value(text);
				this.comItem.SetupSlot(ComItem.ESlotType.Opened, text, null, string.Empty);
			}

			// Token: 0x0600C5C5 RID: 50629 RVA: 0x002FAA9F File Offset: 0x002F8E9F
			private void OnItemClicked(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					DataManager<LinkManager>.GetInstance().AttachDatas = this.THIS.m_kData;
					ItemParser.OnItemLink(item.GUID, item.TableID, ActorShowEquip.m_queryPlayerType, ActorShowEquip.m_zoneId);
				}
			}

			// Token: 0x04007118 RID: 28952
			protected GameObject goLocal;

			// Token: 0x04007119 RID: 28953
			protected GameObject goParent;

			// Token: 0x0400711A RID: 28954
			protected EEquipWearSlotType eEEquipWearSlotType;

			// Token: 0x0400711B RID: 28955
			protected ActorShowEquip THIS;

			// Token: 0x0400711C RID: 28956
			private ComItem comItem;

			// Token: 0x0400711D RID: 28957
			private ItemData itemData;
		}
	}
}
