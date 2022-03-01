using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200194D RID: 6477
	public class PayConsumeItem4
	{
		// Token: 0x0600FBDA RID: 64474 RVA: 0x00450E14 File Offset: 0x0044F214
		public PayConsumeItem4(ActiveManager.ActivityData data, GameObject parent, ClientFrame THIS)
		{
			this.data = data;
			this.parent = parent;
			this.THIS = THIS;
			this.root = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Vip/PayConsumeItem4", true, 0U);
			if (this.root != null)
			{
				ComCommonBind component = this.root.GetComponent<ComCommonBind>();
				this.mTxtMoney = component.GetCom<Text>("txtMoney");
				this.mGirdItem = component.GetGameObject("girdItem");
				this.mSlider = component.GetCom<Slider>("slider");
				this.mTxtProgress = component.GetCom<Text>("txtProgress");
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

		// Token: 0x0600FBDB RID: 64475 RVA: 0x00450F4B File Offset: 0x0044F34B
		private void OnClickGet()
		{
			Singleton<PayManager>.GetInstance().GetRewards(this.data.ID);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(300, delegate
			{
				this.SetStat();
				MallPayFrame mallPayFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(MallPayFrame)) as MallPayFrame;
				VipFrame vipFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(VipFrame)) as VipFrame;
				if (mallPayFrame != null && vipFrame != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdatePayData, null, null, null, null);
				}
			}, 0, 0, false);
		}

		// Token: 0x0600FBDC RID: 64476 RVA: 0x00450F88 File Offset: 0x0044F388
		public void SetData()
		{
			if (this.data == null)
			{
				return;
			}
			this.SetStat();
			ComItem comItem = null;
			Dictionary<uint, int> dictionary = Singleton<PayManager>.GetInstance().GetAwardItems(this.data);
			if (this.isFirstPay)
			{
				dictionary = Singleton<PayManager>.GetInstance().GetFirstPayItems();
				comItem = Utility.AddItemIcon(this.THIS, this.mGirdItem.gameObject, Singleton<PayManager>.GetInstance().weaponItemID, 1, Singleton<PayManager>.GetInstance().weaponStrengthLevel);
			}
			if (!this.isFirstPay)
			{
			}
			Dictionary<uint, int>.Enumerator enumerator = dictionary.GetEnumerator();
			if (dictionary.Count <= 4)
			{
				this.awardItemWidth = 85;
			}
			else if (dictionary.Count > 4)
			{
				this.awardItemWidth = 72;
			}
			if (comItem != null)
			{
				if (dictionary.Count > 3)
				{
					this.awardItemWidth = 72;
					comItem.labLevel.fontSize = 25;
					comItem.labStrengthenLevel.fontSize = 25;
				}
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
			while (enumerator.MoveNext())
			{
				KeyValuePair<uint, int> keyValuePair = enumerator.Current;
				uint key = keyValuePair.Key;
				KeyValuePair<uint, int> keyValuePair2 = enumerator.Current;
				int value = keyValuePair2.Value;
				ComItem comItem2 = Utility.AddItemIcon(this.THIS, this.mGirdItem.gameObject, key, value, 0);
				if (comItem2 != null)
				{
					PayAwardItem payAwardItem2 = new PayAwardItem(comItem2, this.mGirdItem.gameObject);
					comItem2.ItemData.Count = 1;
					if (dictionary.Count > 4)
					{
						comItem2.labLevel.fontSize = 25;
						comItem2.labStrengthenLevel.fontSize = 25;
					}
					if (payAwardItem2 != null)
					{
						LayoutElement currAwardItemEle2 = payAwardItem2.GetCurrAwardItemEle();
						if (currAwardItemEle2 != null)
						{
							LayoutElement layoutElement2 = currAwardItemEle2;
							float num = (float)this.awardItemWidth;
							currAwardItemEle2.preferredHeight = num;
							layoutElement2.preferredWidth = num;
						}
					}
				}
			}
		}

		// Token: 0x0600FBDD RID: 64477 RVA: 0x004511AC File Offset: 0x0044F5AC
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
			int num;
			int num2;
			if (this.data.akActivityValues.Count == 2)
			{
				num = Convert.ToInt32(this.data.akActivityValues[0].value);
				num2 = Convert.ToInt32(this.data.akActivityValues[1].value);
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
					num = 0;
					num2 = 6;
				}
				else
				{
					num = 6;
					num2 = 0;
				}
				this.mTxtMoney.text = "6";
				this.isFirstPay = true;
			}
			if (this.data.status >= 4)
			{
				this.mTxtStaus.gameObject.CustomActive(true);
				this.mBtnGet.gameObject.CustomActive(false);
			}
			this.mTxtProgress.text = string.Format("{0}/{1}", num, num + num2);
			this.mSlider.value = (float)num / (float)(num + num2);
		}

		// Token: 0x04009D6C RID: 40300
		private GameObject root;

		// Token: 0x04009D6D RID: 40301
		private GameObject parent;

		// Token: 0x04009D6E RID: 40302
		public const string res_consumeItem = "UIFlatten/Prefabs/Vip/PayConsumeItem4";

		// Token: 0x04009D6F RID: 40303
		private ActiveManager.ActivityData data;

		// Token: 0x04009D70 RID: 40304
		private ClientFrame THIS;

		// Token: 0x04009D71 RID: 40305
		private Text mTxtMoney;

		// Token: 0x04009D72 RID: 40306
		private GameObject mGirdItem;

		// Token: 0x04009D73 RID: 40307
		private Slider mSlider;

		// Token: 0x04009D74 RID: 40308
		private Text mTxtProgress;

		// Token: 0x04009D75 RID: 40309
		private GameObject mTxtStaus;

		// Token: 0x04009D76 RID: 40310
		private Button mBtnGet;

		// Token: 0x04009D77 RID: 40311
		private bool isFirstPay;

		// Token: 0x04009D78 RID: 40312
		private int awardItemWidth = 50;
	}
}
