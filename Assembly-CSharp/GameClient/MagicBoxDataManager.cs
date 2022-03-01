using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200129C RID: 4764
	public class MagicBoxDataManager : DataManager<MagicBoxDataManager>
	{
		// Token: 0x0600B75E RID: 46942 RVA: 0x0029D937 File Offset: 0x0029BD37
		public override void Clear()
		{
			this.itemRrewardList.Clear();
			this.itemDoubleRewardList.Clear();
		}

		// Token: 0x0600B75F RID: 46943 RVA: 0x0029D94F File Offset: 0x0029BD4F
		public override void Initialize()
		{
		}

		// Token: 0x0600B760 RID: 46944 RVA: 0x0029D954 File Offset: 0x0029BD54
		public void SendCSOpenMagBoxReq(ulong itemUid, byte isBatch)
		{
			CSOpenMagBoxReq csopenMagBoxReq = new CSOpenMagBoxReq();
			csopenMagBoxReq.itemUid = itemUid;
			csopenMagBoxReq.isBatch = isBatch;
			NetManager.Instance().SendCommand<CSOpenMagBoxReq>(ServerType.GATE_SERVER, csopenMagBoxReq);
		}

		// Token: 0x0600B761 RID: 46945 RVA: 0x0029D984 File Offset: 0x0029BD84
		public void AnsyOpenMagBox(UnityAction callback, ulong item, int times)
		{
			if (times > 10)
			{
				times = 10;
			}
			if (times > 0)
			{
				times--;
				this.SendCSOpenMagBoxReq(item, 0);
				DataManager<WaitNetMessageManager>.GetInstance().Wait(500970U, delegate(MsgDATA data)
				{
					if (data == null)
					{
						DataManager<PackageDataManager>.GetInstance().ResetMagicBoxAndMagicHammer();
						return;
					}
					SCOpenMagBoxRes scopenMagBoxRes = new SCOpenMagBoxRes();
					int num = 0;
					scopenMagBoxRes.decode(data.bytes, ref num);
					List<Item> list = ItemDecoder.Decode(data.bytes, ref num, data.bytes.Length, false);
					if (list == null)
					{
						DataManager<PackageDataManager>.GetInstance().ResetMagicBoxAndMagicHammer();
						return;
					}
					if (scopenMagBoxRes.retCode != 0U)
					{
						SystemNotifyManager.SystemNotify((int)scopenMagBoxRes.retCode, string.Empty);
					}
					else
					{
						int num2 = 0;
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(800002001, string.Empty, string.Empty);
						if (tableItem == null)
						{
							return;
						}
						JarBonus tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>(tableItem.ID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							int num3 = (DataManager<CountDataManager>.GetInstance().GetCount(tableItem2.CounterKey) + tableItem2.ComboBuyNum) / tableItem2.ComboBuyNum;
							int num4 = Mathf.CeilToInt((float)num3 / (float)tableItem2.ExBonusNum_1 + 0.1f);
							if (num4 < 1)
							{
								num2 = tableItem2.ExBonusNum_1 - num3;
							}
							else
							{
								num2 = num4 * tableItem2.ExBonusNum_1 - num3;
							}
						}
						if (num2 == tableItem2.ExBonusNum_1)
						{
							this._ResItemList(scopenMagBoxRes, list, this.itemDoubleRewardList);
						}
						else
						{
							this._ResItemList(scopenMagBoxRes, list, this.itemRrewardList);
						}
						this.AnsyOpenMagBox(callback, item, times);
					}
				}, false, 15f, null);
			}
			else if (callback != null)
			{
				callback.Invoke();
			}
		}

		// Token: 0x0600B762 RID: 46946 RVA: 0x0029DA30 File Offset: 0x0029BE30
		private void _ResItemList(SCOpenMagBoxRes msgRet, List<Item> items, List<ItemData> itemDataList)
		{
			for (int i = 0; i < msgRet.rewards.Length; i++)
			{
				OpenJarResult openJarResult = msgRet.rewards[i];
				JarItemPool tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JarItemPool>((int)openJarResult.jarItemId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogError("can’t find JarItemPool....");
				}
				ItemData itemData = null;
				for (int j = 0; j < items.Count; j++)
				{
					if ((long)tableItem.ItemID == (long)((ulong)items[j].dataid))
					{
						Item item = items[j];
						item.num -= (ushort)tableItem.ItemNum;
						itemData = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(items[j]);
						itemData.Count = tableItem.ItemNum;
						if (itemData != null)
						{
							if (items[j].num <= 0)
							{
								items.RemoveAt(j);
							}
							break;
						}
					}
				}
				if (itemData == null)
				{
					itemData = ItemDataManager.CreateItemDataFromTable(tableItem.ItemID, 100, 0);
					itemData.Count = tableItem.ItemNum;
				}
				itemDataList.Add(itemData);
			}
		}

		// Token: 0x0400676E RID: 26478
		public List<ItemData> itemRrewardList = new List<ItemData>();

		// Token: 0x0400676F RID: 26479
		public List<ItemData> itemDoubleRewardList = new List<ItemData>();
	}
}
