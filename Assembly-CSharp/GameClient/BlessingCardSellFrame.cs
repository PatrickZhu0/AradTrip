using System;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001931 RID: 6449
	public class BlessingCardSellFrame : ClientFrame
	{
		// Token: 0x0600FAD4 RID: 64212 RVA: 0x0044B510 File Offset: 0x00449910
		protected override void _bindExUI()
		{
			this.mInputField = this.mBind.GetCom<InputField>("InputField");
			this.mInputField.onValueChanged.AddListener(new UnityAction<string>(this.OnInputFieldValueChanged));
			this.mTotalPrice = this.mBind.GetCom<Text>("TotalPrice");
			this.mCloseicon = this.mBind.GetCom<Button>("closeicon");
			this.mCloseicon.onClick.AddListener(new UnityAction(this._onCloseiconButtonClick));
			this.mIncrease = this.mBind.GetCom<Button>("Increase");
			this.mIncrease.onClick.AddListener(new UnityAction(this._onIncreaseButtonClick));
			this.mDecrease = this.mBind.GetCom<Button>("Decrease");
			this.mDecrease.onClick.AddListener(new UnityAction(this._onDecreaseButtonClick));
			this.mMaxNum = this.mBind.GetCom<Button>("MaxNum");
			this.mMaxNum.onClick.AddListener(new UnityAction(this._onMaxNumButtonClick));
			this.mSell = this.mBind.GetCom<Button>("Sell");
			this.mSell.onClick.AddListener(new UnityAction(this._onSellButtonClick));
		}

		// Token: 0x0600FAD5 RID: 64213 RVA: 0x0044B660 File Offset: 0x00449A60
		protected override void _unbindExUI()
		{
			this.mInputField.onValueChanged.RemoveListener(new UnityAction<string>(this.OnInputFieldValueChanged));
			this.mInputField = null;
			this.mTotalPrice = null;
			this.mCloseicon.onClick.RemoveListener(new UnityAction(this._onCloseiconButtonClick));
			this.mCloseicon = null;
			this.mIncrease.onClick.RemoveListener(new UnityAction(this._onIncreaseButtonClick));
			this.mIncrease = null;
			this.mDecrease.onClick.RemoveListener(new UnityAction(this._onDecreaseButtonClick));
			this.mDecrease = null;
			this.mMaxNum.onClick.RemoveListener(new UnityAction(this._onMaxNumButtonClick));
			this.mMaxNum = null;
			this.mSell.onClick.RemoveListener(new UnityAction(this._onSellButtonClick));
			this.mSell = null;
		}

		// Token: 0x0600FAD6 RID: 64214 RVA: 0x0044B746 File Offset: 0x00449B46
		private void _onCloseiconButtonClick()
		{
			this.frameMgr.CloseFrame<BlessingCardSellFrame>(this, false);
		}

		// Token: 0x0600FAD7 RID: 64215 RVA: 0x0044B758 File Offset: 0x00449B58
		private void _onIncreaseButtonClick()
		{
			if (this.monpolyCard == null)
			{
				return;
			}
			int num = 0;
			if (int.TryParse(this.mInputField.text, out num))
			{
				num++;
				if (num >= 1 && num <= (int)this.monpolyCard.num)
				{
					this.mInputField.text = num.ToString();
				}
			}
		}

		// Token: 0x0600FAD8 RID: 64216 RVA: 0x0044B7C0 File Offset: 0x00449BC0
		private void _onDecreaseButtonClick()
		{
			if (this.monpolyCard == null)
			{
				return;
			}
			int num = 0;
			if (int.TryParse(this.mInputField.text, out num))
			{
				num--;
				if (num > 0 && num <= (int)this.monpolyCard.num)
				{
					this.mInputField.text = num.ToString();
				}
			}
		}

		// Token: 0x0600FAD9 RID: 64217 RVA: 0x0044B826 File Offset: 0x00449C26
		private void _onMaxNumButtonClick()
		{
			if (this.monpolyCard == null)
			{
				return;
			}
			this.mInputField.text = this.monpolyCard.num.ToString();
		}

		// Token: 0x0600FADA RID: 64218 RVA: 0x0044B858 File Offset: 0x00449C58
		private void _onSellButtonClick()
		{
			if (this.monpolyCard == null)
			{
				return;
			}
			int num = 0;
			int.TryParse(this.mInputField.text, out num);
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolySellCardReq((int)this.monpolyCard.id, num);
			this._onCloseiconButtonClick();
		}

		// Token: 0x0600FADB RID: 64219 RVA: 0x0044B8A2 File Offset: 0x00449CA2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/BlessingCardSellFrame";
		}

		// Token: 0x0600FADC RID: 64220 RVA: 0x0044B8AC File Offset: 0x00449CAC
		protected override void _OnOpenFrame()
		{
			this.monpolyCard = (this.userData as MonpolyCard);
			if (this.monpolyCard != null)
			{
				for (int i = 0; i < DataManager<ZillionaireGameDataManager>.GetInstance().monopolyCardTableList.Count; i++)
				{
					MonopolyCardTable monopolyCardTable = DataManager<ZillionaireGameDataManager>.GetInstance().monopolyCardTableList[i];
					if (monopolyCardTable != null)
					{
						if (monopolyCardTable.card == (int)this.monpolyCard.id)
						{
							this.coinNum = monopolyCardTable.coinNum;
						}
					}
				}
				this.mInputField.text = this.monpolyCard.num.ToString();
				if (this.mTotalPrice != null)
				{
					int num = (int)(this.monpolyCard.num * (uint)this.coinNum);
					this.mTotalPrice.text = num.ToString();
				}
			}
		}

		// Token: 0x0600FADD RID: 64221 RVA: 0x0044B995 File Offset: 0x00449D95
		protected override void _OnCloseFrame()
		{
			this.monpolyCard = null;
			this.coinNum = 0;
		}

		// Token: 0x0600FADE RID: 64222 RVA: 0x0044B9A8 File Offset: 0x00449DA8
		private void OnInputFieldValueChanged(string value)
		{
			int num = 0;
			if (int.TryParse(value, out num))
			{
				if (num < 0)
				{
					num = 0;
				}
				if (num > (int)this.monpolyCard.num)
				{
					num = (int)this.monpolyCard.num;
				}
				int num2 = num * this.coinNum;
				this.mTotalPrice.text = num2.ToString();
				this.mInputField.text = num.ToString();
			}
		}

		// Token: 0x04009CB6 RID: 40118
		private MonpolyCard monpolyCard;

		// Token: 0x04009CB7 RID: 40119
		private int coinNum;

		// Token: 0x04009CB8 RID: 40120
		private InputField mInputField;

		// Token: 0x04009CB9 RID: 40121
		private Text mTotalPrice;

		// Token: 0x04009CBA RID: 40122
		private Button mCloseicon;

		// Token: 0x04009CBB RID: 40123
		private Button mIncrease;

		// Token: 0x04009CBC RID: 40124
		private Button mDecrease;

		// Token: 0x04009CBD RID: 40125
		private Button mMaxNum;

		// Token: 0x04009CBE RID: 40126
		private Button mSell;
	}
}
