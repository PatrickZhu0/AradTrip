using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200193C RID: 6460
	public class ZillionaireGameTurntableView : MonoBehaviour
	{
		// Token: 0x0600FB1F RID: 64287 RVA: 0x0044CB91 File Offset: 0x0044AF91
		private void OnDestroy()
		{
			this.zillionaireGameTurntableData = null;
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
				this.coroutine = null;
			}
		}

		// Token: 0x0600FB20 RID: 64288 RVA: 0x0044CBB8 File Offset: 0x0044AFB8
		public void InitView(ZillionaireGameTurntableData zillionaireGameTurntableData)
		{
			if (zillionaireGameTurntableData == null)
			{
				return;
			}
			this.zillionaireGameTurntableData = zillionaireGameTurntableData;
			this.InitItem();
			this.coroutine = base.StartCoroutine(this.StartTurn());
		}

		// Token: 0x0600FB21 RID: 64289 RVA: 0x0044CBE0 File Offset: 0x0044AFE0
		private void InitItem()
		{
			if (this.zillionaireGameTurntableData.itemSimpleDataList != null)
			{
				for (int i = 0; i < this.zillionaireGameTurntableData.itemSimpleDataList.Count; i++)
				{
					ItemSimpleData itemSimpleData = this.zillionaireGameTurntableData.itemSimpleDataList[i];
					if (itemSimpleData != null)
					{
						if (i <= this.rewardPositionList.Count)
						{
							GameObject parent = this.rewardPositionList[i];
							CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(parent);
							if (commonNewItem != null)
							{
								commonNewItem.InitItem(itemSimpleData.ItemID, itemSimpleData.Count);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600FB22 RID: 64290 RVA: 0x0044CC80 File Offset: 0x0044B080
		private IEnumerator StartTurn()
		{
			yield return Yielders.GetWaitForSeconds(0.3f);
			if (this.startUIGray != null)
			{
				this.startUIGray.enabled = true;
			}
			int position = -1;
			if (this.zillionaireGameTurntableData.itemSimpleDataList != null)
			{
				for (int i = 0; i < this.zillionaireGameTurntableData.itemSimpleDataList.Count; i++)
				{
					ItemSimpleData itemSimpleData = this.zillionaireGameTurntableData.itemSimpleDataList[i];
					if (itemSimpleData != null)
					{
						if (itemSimpleData.ItemID == this.zillionaireGameTurntableData.rewardItemId)
						{
							if (itemSimpleData.Count == this.zillionaireGameTurntableData.rewardCount)
							{
								position = i;
								break;
							}
						}
					}
				}
				if (position != -1)
				{
					if (this.theLuckyRoller != null)
					{
						this.theLuckyRoller.RotateUp(8, position, true, delegate
						{
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<ZillionaireGameTurntableFrame>(null, false);
							ItemData itemData;
							if (this.zillionaireGameTurntableData.realRewardItemId > 0)
							{
								itemData = ItemDataManager.CreateItemDataFromTable(this.zillionaireGameTurntableData.realRewardItemId, 100, 0);
							}
							else
							{
								itemData = ItemDataManager.CreateItemDataFromTable(this.zillionaireGameTurntableData.rewardItemId, 100, 0);
							}
							if (itemData != null)
							{
								itemData.Count = this.zillionaireGameTurntableData.rewardCount;
							}
							SystemNotifyManager.SysNotifyGetNewItemEffect(itemData, false, string.Empty);
						});
					}
				}
				else
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<ZillionaireGameTurntableFrame>(null, false);
				}
			}
			yield break;
		}

		// Token: 0x04009CE9 RID: 40169
		[SerializeField]
		private List<GameObject> rewardPositionList = new List<GameObject>();

		// Token: 0x04009CEA RID: 40170
		[SerializeField]
		private TheLuckyRoller theLuckyRoller;

		// Token: 0x04009CEB RID: 40171
		[SerializeField]
		private UIGray startUIGray;

		// Token: 0x04009CEC RID: 40172
		private ZillionaireGameTurntableData zillionaireGameTurntableData;

		// Token: 0x04009CED RID: 40173
		private Coroutine coroutine;
	}
}
