using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200192D RID: 6445
	public class BlessingCardExchangeItem : MonoBehaviour
	{
		// Token: 0x0600FAAE RID: 64174 RVA: 0x0044A942 File Offset: 0x00448D42
		private void Awake()
		{
			if (this.exchangeBtn != null)
			{
				this.exchangeBtn.onClick.RemoveAllListeners();
				this.exchangeBtn.onClick.AddListener(new UnityAction(this.OnExchangeBtnClick));
			}
		}

		// Token: 0x0600FAAF RID: 64175 RVA: 0x0044A981 File Offset: 0x00448D81
		private void OnDestroy()
		{
			this.cardExchangeData = null;
			if (this.exchangeBtn != null)
			{
				this.exchangeBtn.onClick.RemoveListener(new UnityAction(this.OnExchangeBtnClick));
			}
		}

		// Token: 0x0600FAB0 RID: 64176 RVA: 0x0044A9B8 File Offset: 0x00448DB8
		public void OnItemVisiable(CardExchangeData cardExchangeData)
		{
			if (cardExchangeData == null)
			{
				return;
			}
			this.cardExchangeData = cardExchangeData;
			if (cardExchangeData.type == 1 && cardExchangeData.costCardList != null)
			{
				if (this.addGo != null)
				{
					this.addGo.CustomActive(cardExchangeData.costCardList.Count >= 2);
				}
				for (int i = 0; i < cardExchangeData.costCardList.Count; i++)
				{
					ItemSimpleData itemSimpleData = cardExchangeData.costCardList[i];
					if (i <= this.costCardList.Count)
					{
						GameObject parent = this.costCardList[i];
						CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(parent);
						if (commonNewItem != null)
						{
							commonNewItem.InitItem(itemSimpleData.ItemID, 1);
							commonNewItem.gameObject.transform.SetAsFirstSibling();
						}
					}
				}
			}
			if (cardExchangeData.reward != null)
			{
				ItemSimpleData reward = cardExchangeData.reward;
				CommonNewItem commonNewItem2 = CommonUtility.CreateCommonNewItem(this.rewardParent);
				if (commonNewItem2 != null)
				{
					commonNewItem2.InitItem(reward.ItemID, reward.Count);
					commonNewItem2.SetItemCountFontSize(this.fontSize);
				}
			}
			this.UpdateData(cardExchangeData);
		}

		// Token: 0x0600FAB1 RID: 64177 RVA: 0x0044AAEC File Offset: 0x00448EEC
		public void UpdateData(CardExchangeData cardExchangeData)
		{
			if (this.hasChangeGo != null)
			{
				this.hasChangeGo.CustomActive(false);
			}
			if (this.exchangeBtn != null)
			{
				this.exchangeBtn.enabled = false;
			}
			if (this.exchangeGray != null)
			{
				this.exchangeGray.enabled = true;
			}
			switch (cardExchangeData.state)
			{
			case 2:
				if (this.exchangeBtn != null)
				{
					this.exchangeBtn.enabled = true;
				}
				if (this.exchangeGray != null)
				{
					this.exchangeGray.enabled = false;
				}
				break;
			case 5:
				if (this.exchangeBtn != null)
				{
					this.exchangeBtn.CustomActive(false);
				}
				if (this.hasChangeGo != null)
				{
					this.hasChangeGo.CustomActive(true);
				}
				break;
			}
			if (cardExchangeData.type == 1)
			{
				for (int i = 0; i < cardExchangeData.costCardList.Count; i++)
				{
					ItemSimpleData itemSimpleData = cardExchangeData.costCardList[i];
					if (i <= this.costCountList.Count)
					{
						Text text = this.costCountList[i];
						int num = DataManager<ZillionaireGameDataManager>.GetInstance().FindBlessingCardCount(itemSimpleData.ItemID);
						string key = (num < itemSimpleData.Count) ? "common_expend_red" : "common_expend_green";
						if (text != null)
						{
							text.text = TR.Value(key, num, itemSimpleData.Count);
						}
					}
				}
			}
		}

		// Token: 0x0600FAB2 RID: 64178 RVA: 0x0044ACAB File Offset: 0x004490AB
		private void OnExchangeBtnClick()
		{
			if (this.cardExchangeData == null)
			{
				return;
			}
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyCardExchangeReq(this.cardExchangeData.tableId);
		}

		// Token: 0x04009C9E RID: 40094
		[SerializeField]
		private List<GameObject> costCardList;

		// Token: 0x04009C9F RID: 40095
		[SerializeField]
		private List<Text> costCountList;

		// Token: 0x04009CA0 RID: 40096
		[SerializeField]
		private GameObject addGo;

		// Token: 0x04009CA1 RID: 40097
		[SerializeField]
		private GameObject rewardParent;

		// Token: 0x04009CA2 RID: 40098
		[SerializeField]
		private Button exchangeBtn;

		// Token: 0x04009CA3 RID: 40099
		[SerializeField]
		private UIGray exchangeGray;

		// Token: 0x04009CA4 RID: 40100
		[SerializeField]
		private GameObject hasChangeGo;

		// Token: 0x04009CA5 RID: 40101
		[SerializeField]
		private int fontSize = 30;

		// Token: 0x04009CA6 RID: 40102
		private CardExchangeData cardExchangeData;
	}
}
