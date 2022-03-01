using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200194A RID: 6474
	public class PayConsumeItem2
	{
		// Token: 0x0600FBCA RID: 64458 RVA: 0x0045034C File Offset: 0x0044E74C
		public PayConsumeItem2(ActiveManager.ActivityData data, GameObject parent, ClientFrame THIS)
		{
			this.data = data;
			this.parent = parent;
			this.THIS = THIS;
			this.root = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Vip/PayConsumeItem2", true, 0U);
			if (this.root != null)
			{
				ComCommonBind component = this.root.GetComponent<ComCommonBind>();
				this.mTxtMoney = component.GetCom<Text>("txtMoney");
				this.mSlider = component.GetCom<Slider>("slider");
				this.mTxtProgress = component.GetCom<Text>("txtProgress");
				this.mGirdItem = component.GetCom<GridLayoutGroup>("girdItem");
				this.mTxtStaus = component.GetCom<Text>("txtStaus");
				this.mBtnGet = component.GetCom<Button>("btnGet");
				this.mBtnGet.onClick.AddListener(new UnityAction(this.OnClickGet));
				this.mBtnGet.gameObject.CustomActive(true);
				this.mTxtStaus.gameObject.CustomActive(false);
				Utility.AttachTo(this.root, parent, false);
			}
			this.SetData();
		}

		// Token: 0x0600FBCB RID: 64459 RVA: 0x00450460 File Offset: 0x0044E860
		public void SetStat()
		{
			bool flag = Singleton<PayManager>.GetInstance().CanGetRewards(this.data.ID);
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
			this.mTxtProgress.text = string.Format("{0}/{1}", num, num + num2);
			this.mSlider.value = (float)num / (float)(num + num2);
			if (this.data.status >= 4)
			{
				this.mTxtStaus.gameObject.CustomActive(true);
				this.mBtnGet.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600FBCC RID: 64460 RVA: 0x004505F3 File Offset: 0x0044E9F3
		private void OnClickGet()
		{
			Singleton<PayManager>.GetInstance().GetRewards(this.data.ID);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(300, delegate
			{
				this.SetStat();
			}, 0, 0, false);
		}

		// Token: 0x0600FBCD RID: 64461 RVA: 0x00450630 File Offset: 0x0044EA30
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
			foreach (KeyValuePair<uint, int> keyValuePair in dictionary)
			{
				uint key = keyValuePair.Key;
				Dictionary<uint, int>.Enumerator enumerator;
				KeyValuePair<uint, int> keyValuePair2 = enumerator.Current;
				int value = keyValuePair2.Value;
				Utility.AddItemIcon(this.THIS, this.mGirdItem.gameObject, key, value, 0);
			}
		}

		// Token: 0x04009D4B RID: 40267
		private GameObject root;

		// Token: 0x04009D4C RID: 40268
		private GameObject parent;

		// Token: 0x04009D4D RID: 40269
		public const string res_consumeItem = "UIFlatten/Prefabs/Vip/PayConsumeItem2";

		// Token: 0x04009D4E RID: 40270
		private ActiveManager.ActivityData data;

		// Token: 0x04009D4F RID: 40271
		private ClientFrame THIS;

		// Token: 0x04009D50 RID: 40272
		private Text mTxtMoney;

		// Token: 0x04009D51 RID: 40273
		private Slider mSlider;

		// Token: 0x04009D52 RID: 40274
		private Text mTxtProgress;

		// Token: 0x04009D53 RID: 40275
		private GridLayoutGroup mGirdItem;

		// Token: 0x04009D54 RID: 40276
		private Text mTxtStaus;

		// Token: 0x04009D55 RID: 40277
		private Button mBtnGet;

		// Token: 0x04009D56 RID: 40278
		private bool isFirstPay;
	}
}
