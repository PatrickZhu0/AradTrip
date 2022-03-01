using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200003F RID: 63
	internal class ComLegendMaterialItem : MonoBehaviour
	{
		// Token: 0x0600018F RID: 399 RVA: 0x0000EA70 File Offset: 0x0000CE70
		public void SetItemData(ComLegendMaterialItemData data)
		{
			this.data = data;
			if (null == this.comItem && null != this.goItemParent)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			if (null != this.comItem)
			{
				this.comItem.Setup(data.itemData, delegate(GameObject obj, ItemData item)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				});
			}
			MissionManager.TokenObject tokenObject = data.parseObject.tokens.Find((MissionManager.TokenObject x) => x.eMaterialRegexType == MissionManager.MaterialRegexType.MRT_KEY_VALUE);
			if (data.itemData.TableID == this.mGoldItemId)
			{
				this.process.text = data.parseObject.content;
			}
			else
			{
				int num;
				if (data.itemData.SubType == 160)
				{
					num = DataManager<ItemDataManager>.GetInstance().GetItemCountBySubType(EPackageType.Material, ItemTable.eSubType.ST_SORROW_MEMENTO);
				}
				else
				{
					num = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(data.itemData.TableID);
				}
				string content = data.parseObject.content;
				string[] array = content.Split(new char[]
				{
					'/'
				});
				int num2 = 0;
				if (array != null && array.Length >= 2)
				{
					int.TryParse(array[1], out num2);
				}
				this.process.text = string.Format("{0}/{1}", num, num2);
			}
			if (tokenObject != null)
			{
				int num3 = (int)tokenObject.param0;
				int num4 = (int)tokenObject.param1;
				bool flag = (bool)tokenObject.param2;
				num3 = IntMath.Min(num3, num4);
				bool flag2 = false;
				if (data != null && data.itemData != null)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(data.itemData.TableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						flag2 = (tableItem.Type == ItemTable.eType.INCOME);
					}
				}
				if (null != this.comStateController)
				{
					int num5 = 0;
					num5 |= ((!flag2) ? 0 : 1);
					num5 |= ((num3 < num4) ? 0 : 2);
					if (flag)
					{
						this.comStateController.Key = ComLegendMaterialItem.statusKeys[4];
					}
					else
					{
						this.comStateController.Key = ComLegendMaterialItem.statusKeys[num5];
					}
				}
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000ECE2 File Offset: 0x0000D0E2
		private void OnDestroy()
		{
			if (null != this.comItem)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
			this.data = null;
		}

		// Token: 0x0400017E RID: 382
		public GameObject goItemParent;

		// Token: 0x0400017F RID: 383
		public Text process;

		// Token: 0x04000180 RID: 384
		public StateController comStateController;

		// Token: 0x04000181 RID: 385
		private ComItem comItem;

		// Token: 0x04000182 RID: 386
		private ComLegendMaterialItemData data;

		// Token: 0x04000183 RID: 387
		private int mGoldItemId = 600000001;

		// Token: 0x04000184 RID: 388
		public static string[] statusKeys = new string[]
		{
			"normal_not_enough",
			"gold_not_enough",
			"normal_enough",
			"gold_enough",
			"task_over"
		};
	}
}
