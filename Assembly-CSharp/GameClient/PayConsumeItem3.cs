using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200194C RID: 6476
	public class PayConsumeItem3
	{
		// Token: 0x0600FBD5 RID: 64469 RVA: 0x004509E8 File Offset: 0x0044EDE8
		public PayConsumeItem3(ActiveManager.ActivityData data, GameObject parent, ClientFrame THIS)
		{
			this.data = data;
			this.parent = parent;
			this.THIS = THIS;
			this.root = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Vip/PayConsumeItem3", true, 0U);
			if (this.root != null)
			{
				ComCommonBind component = this.root.GetComponent<ComCommonBind>();
				this.mTxtMoney = component.GetCom<Text>("txtMoney");
				this.mGirdItem = component.GetGameObject("girdItem");
				this.mTxtStaus = component.GetGameObject("txtStaus");
				this.mBtnGet = component.GetCom<Button>("btnGet");
				this.mBtnGet.onClick.RemoveListener(new UnityAction(this.OnClickGet));
				this.mBtnGet.onClick.AddListener(new UnityAction(this.OnClickGet));
				this.mBtnGet.gameObject.CustomActive(true);
				this.mTxtStaus.gameObject.CustomActive(false);
				Utility.AttachTo(this.root, parent, false);
			}
			this.SetData();
		}

		// Token: 0x0600FBD6 RID: 64470 RVA: 0x00450AFD File Offset: 0x0044EEFD
		private void OnClickGet()
		{
			Singleton<PayManager>.GetInstance().GetRewards(this.data.ID);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(300, delegate
			{
				this.SetStat();
			}, 0, 0, false);
		}

		// Token: 0x0600FBD7 RID: 64471 RVA: 0x00450B38 File Offset: 0x0044EF38
		public void SetData()
		{
			if (this.data == null)
			{
				return;
			}
			this.SetStat();
			Dictionary<uint, int> dictionary = Singleton<PayManager>.GetInstance().GetAwardItems(this.data);
			if (this.isFirstPay)
			{
				dictionary = Singleton<PayManager>.GetInstance().GetFirstPayItems();
				Utility.AddItemIcon(this.THIS, this.mGirdItem.gameObject, Singleton<PayManager>.GetInstance().weaponItemID, 1, Singleton<PayManager>.GetInstance().weaponStrengthLevel);
			}
			if (!this.isFirstPay)
			{
			}
			Dictionary<uint, int>.Enumerator enumerator = dictionary.GetEnumerator();
			if (dictionary.Count <= 4)
			{
				this.awardItemWidth = 65;
			}
			else if (dictionary.Count > 4)
			{
				this.awardItemWidth = 50;
			}
			while (enumerator.MoveNext())
			{
				KeyValuePair<uint, int> keyValuePair = enumerator.Current;
				uint key = keyValuePair.Key;
				KeyValuePair<uint, int> keyValuePair2 = enumerator.Current;
				int value = keyValuePair2.Value;
				ComItem comItem = Utility.AddItemIcon(this.THIS, this.mGirdItem.gameObject, key, value, 0);
				if (comItem != null)
				{
					PayAwardItem payAwardItem = new PayAwardItem(comItem, this.mGirdItem.gameObject);
					comItem.ItemData.Count = 1;
					if (payAwardItem != null)
					{
						LayoutElement currAwardItemEle = payAwardItem.GetCurrAwardItemEle();
						if (currAwardItemEle != null)
						{
							LayoutElement layoutElement = currAwardItemEle;
							float num = (float)this.awardItemWidth;
							currAwardItemEle.preferredHeight = num;
							layoutElement.preferredWidth = num;
						}
					}
				}
			}
		}

		// Token: 0x0600FBD8 RID: 64472 RVA: 0x00450CA0 File Offset: 0x0044F0A0
		public void SetStat()
		{
			bool flag = Singleton<PayManager>.GetInstance().CanGetRewards(this.data.ID);
			this.mBtnGet.interactable = flag;
			UIGray uigray = this.mBtnGet.gameObject.GetComponent<UIGray>();
			if (uigray == null)
			{
				uigray = this.mBtnGet.gameObject.AddComponent<UIGray>();
			}
			uigray.enabled = !flag;
			if (this.data.akActivityValues.Count == 2)
			{
				int num = Convert.ToInt32(this.data.akActivityValues[0].value);
				int num2 = Convert.ToInt32(this.data.akActivityValues[1].value);
				if (this.data.status > 1)
				{
					num += num2;
					num2 = 0;
				}
				this.mTxtMoney.text = (num + num2).ToString();
				if (num + num2 <= 6)
				{
					this.isFirstPay = true;
				}
			}
			else
			{
				if (this.data.status <= 1)
				{
				}
				this.mTxtMoney.text = "6";
				this.isFirstPay = true;
			}
			if (this.data.status >= 4)
			{
				this.mTxtStaus.gameObject.CustomActive(true);
				this.mBtnGet.gameObject.CustomActive(false);
			}
		}

		// Token: 0x04009D61 RID: 40289
		private GameObject root;

		// Token: 0x04009D62 RID: 40290
		private GameObject parent;

		// Token: 0x04009D63 RID: 40291
		public const string res_consumeItem = "UIFlatten/Prefabs/Vip/PayConsumeItem3";

		// Token: 0x04009D64 RID: 40292
		private ActiveManager.ActivityData data;

		// Token: 0x04009D65 RID: 40293
		private ClientFrame THIS;

		// Token: 0x04009D66 RID: 40294
		private Text mTxtMoney;

		// Token: 0x04009D67 RID: 40295
		private GameObject mGirdItem;

		// Token: 0x04009D68 RID: 40296
		private GameObject mTxtStaus;

		// Token: 0x04009D69 RID: 40297
		private Button mBtnGet;

		// Token: 0x04009D6A RID: 40298
		private bool isFirstPay;

		// Token: 0x04009D6B RID: 40299
		private int awardItemWidth = 50;
	}
}
