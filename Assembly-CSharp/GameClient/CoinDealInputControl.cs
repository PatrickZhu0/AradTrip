using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001585 RID: 5509
	public class CoinDealInputControl : MonoBehaviour
	{
		// Token: 0x0600D76C RID: 55148 RVA: 0x0035D4D5 File Offset: 0x0035B8D5
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D76D RID: 55149 RVA: 0x0035D4DD File Offset: 0x0035B8DD
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D76E RID: 55150 RVA: 0x0035D4EC File Offset: 0x0035B8EC
		private void ClearData()
		{
			this._coinDealMinCoinNumber = 0;
			this._coinDealMaxCoinNumber = 0;
			this._coinDealMinSinglePrice = 0;
			this._coinDealMaxSinglePrice = 0;
			this._onCoinNumberChangeAction = null;
			this._onSinglePriceChangeAction = null;
			this._currentCoinDealCoinNumber = 0;
			this._currentCoinDealSinglePrice = 0;
			this._coinDealKeyboardInputType = CoinDealKeyBoardInputType.None;
		}

		// Token: 0x0600D76F RID: 55151 RVA: 0x0035D538 File Offset: 0x0035B938
		private void BindUiEvents()
		{
			if (this.coinDealButtonMinusTen != null)
			{
				this.coinDealButtonMinusTen.onClick.RemoveAllListeners();
				this.coinDealButtonMinusTen.onClick.AddListener(new UnityAction(this.OnCoinDealButtonMinusTenClick));
			}
			if (this.coinDealButtonMinusOne != null)
			{
				this.coinDealButtonMinusOne.onClick.RemoveAllListeners();
				this.coinDealButtonMinusOne.onClick.AddListener(new UnityAction(this.OnCoinDealButtonMinusOneClick));
			}
			if (this.coinDealButtonAddTen != null)
			{
				this.coinDealButtonAddTen.onClick.RemoveAllListeners();
				this.coinDealButtonAddTen.onClick.AddListener(new UnityAction(this.OnCoinDealButtonAddTenClick));
			}
			if (this.coinDealButtonAddOne != null)
			{
				this.coinDealButtonAddOne.onClick.RemoveAllListeners();
				this.coinDealButtonAddOne.onClick.AddListener(new UnityAction(this.OnCoinDealButtonAddOneClick));
			}
			if (this.coinDealKeyBoardButton != null)
			{
				this.coinDealKeyBoardButton.onClick.RemoveAllListeners();
				this.coinDealKeyBoardButton.onClick.AddListener(new UnityAction(this.OnCoinDealKeyBoardButtonClick));
			}
			if (this.singlePriceButtonMinusTen != null)
			{
				this.singlePriceButtonMinusTen.onClick.RemoveAllListeners();
				this.singlePriceButtonMinusTen.onClick.AddListener(new UnityAction(this.OnSinglePriceButtonMinusTenClick));
			}
			if (this.singlePriceButtonMinusOne != null)
			{
				this.singlePriceButtonMinusOne.onClick.RemoveAllListeners();
				this.singlePriceButtonMinusOne.onClick.AddListener(new UnityAction(this.OnSinglePriceButtonMinusOneClick));
			}
			if (this.singlePriceButtonAddOne != null)
			{
				this.singlePriceButtonAddOne.onClick.RemoveAllListeners();
				this.singlePriceButtonAddOne.onClick.AddListener(new UnityAction(this.OnSinglePriceButtonAddOneClick));
			}
			if (this.singlePriceButtonAddTen != null)
			{
				this.singlePriceButtonAddTen.onClick.RemoveAllListeners();
				this.singlePriceButtonAddTen.onClick.AddListener(new UnityAction(this.OnSinglePriceButtonAddTenClick));
			}
			if (this.singlePriceKeyBoardButton != null)
			{
				this.singlePriceKeyBoardButton.onClick.RemoveAllListeners();
				this.singlePriceKeyBoardButton.onClick.AddListener(new UnityAction(this.OnSinglePriceKeyBoardButtonClick));
			}
		}

		// Token: 0x0600D770 RID: 55152 RVA: 0x0035D7A8 File Offset: 0x0035BBA8
		private void UnBindUiEvents()
		{
			if (this.coinDealButtonMinusTen != null)
			{
				this.coinDealButtonMinusTen.onClick.RemoveAllListeners();
			}
			if (this.coinDealButtonMinusOne != null)
			{
				this.coinDealButtonMinusOne.onClick.RemoveAllListeners();
			}
			if (this.coinDealButtonAddTen != null)
			{
				this.coinDealButtonAddTen.onClick.RemoveAllListeners();
			}
			if (this.coinDealButtonAddOne != null)
			{
				this.coinDealButtonAddOne.onClick.RemoveAllListeners();
			}
			if (this.coinDealKeyBoardButton != null)
			{
				this.coinDealKeyBoardButton.onClick.RemoveAllListeners();
			}
			if (this.singlePriceButtonMinusTen != null)
			{
				this.singlePriceButtonMinusTen.onClick.RemoveAllListeners();
			}
			if (this.singlePriceButtonMinusOne != null)
			{
				this.singlePriceButtonMinusOne.onClick.RemoveAllListeners();
			}
			if (this.singlePriceButtonAddOne != null)
			{
				this.singlePriceButtonAddOne.onClick.RemoveAllListeners();
			}
			if (this.singlePriceButtonAddTen != null)
			{
				this.singlePriceButtonAddTen.onClick.RemoveAllListeners();
			}
			if (this.singlePriceKeyBoardButton != null)
			{
				this.singlePriceKeyBoardButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D771 RID: 55153 RVA: 0x0035D8FF File Offset: 0x0035BCFF
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600D772 RID: 55154 RVA: 0x0035D907 File Offset: 0x0035BD07
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600D773 RID: 55155 RVA: 0x0035D90F File Offset: 0x0035BD0F
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
		}

		// Token: 0x0600D774 RID: 55156 RVA: 0x0035D92C File Offset: 0x0035BD2C
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
		}

		// Token: 0x0600D775 RID: 55157 RVA: 0x0035D94C File Offset: 0x0035BD4C
		public void InitControl(GoldConsignmentOrderType orderType, int coinNumber, int singlePrice, OnCoinDealCoinNumberChangeAction onCoinNumberChangeAction = null, OnCoinDealSinglePriceChangeAction onSinglePriceChangeAction = null)
		{
			this._orderType = orderType;
			this._currentCoinDealCoinNumber = coinNumber;
			this._currentCoinDealSinglePrice = singlePrice;
			this._onCoinNumberChangeAction = onCoinNumberChangeAction;
			this._onSinglePriceChangeAction = onSinglePriceChangeAction;
			if (this._orderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				this.UpdateCoinDealCoinNumberDataWithBuy();
			}
			else
			{
				this.UpdateCoinDealCoinNumberDataWithSell();
			}
			this.UpdateCoinDealCoinNumberValueLabel();
			this.UpdateCoinDealCoinNumberButtonState();
			this.UpdateCoinDealSinglePriceData();
			this.UpdateCoinDealSinglePriceValueLabel();
			this.UpdateCoinDealSinglePriceButtonState();
		}

		// Token: 0x0600D776 RID: 55158 RVA: 0x0035D9B9 File Offset: 0x0035BDB9
		public void UpdateCoinDealCoinNumberState()
		{
			if (this._orderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				this.UpdateCoinDealCoinNumberDataWithBuy();
				this.UpdateCoinDealCoinNumberButtonState();
			}
			else
			{
				this.UpdateCoinDealCoinNumberDataWithSell();
				this.UpdateCoinDealCoinNumberButtonState();
			}
		}

		// Token: 0x0600D777 RID: 55159 RVA: 0x0035D9E4 File Offset: 0x0035BDE4
		private void UpdateCoinDealCoinNumberDataWithBuy()
		{
			int coinDealMinCoinNumberWithBase = CoinDealUtility.GetCoinDealMinCoinNumberWithBase();
			int coinDealMaxCoinNumberWithBase = CoinDealUtility.GetCoinDealMaxCoinNumberWithBase();
			int coinDealPlayerCoinNumberWithBuy = CoinDealUtility.GetCoinDealPlayerCoinNumberWithBuy(this._currentCoinDealSinglePrice);
			this._coinDealMinCoinNumber = coinDealMinCoinNumberWithBase;
			this._coinDealMaxCoinNumber = coinDealMaxCoinNumberWithBase;
			if (coinDealPlayerCoinNumberWithBuy <= coinDealMinCoinNumberWithBase)
			{
				this._coinDealMaxCoinNumber = coinDealMinCoinNumberWithBase;
			}
			else if (coinDealPlayerCoinNumberWithBuy <= coinDealMaxCoinNumberWithBase)
			{
				this._coinDealMaxCoinNumber = coinDealPlayerCoinNumberWithBuy;
			}
		}

		// Token: 0x0600D778 RID: 55160 RVA: 0x0035DA38 File Offset: 0x0035BE38
		private void UpdateCoinDealCoinNumberDataWithSell()
		{
			int coinDealMinCoinNumberWithBase = CoinDealUtility.GetCoinDealMinCoinNumberWithBase();
			int coinDealMaxCoinNumberWithBase = CoinDealUtility.GetCoinDealMaxCoinNumberWithBase();
			int coinDealPlayerCoinNumberWithSell = CoinDealUtility.GetCoinDealPlayerCoinNumberWithSell();
			this._coinDealMinCoinNumber = coinDealMinCoinNumberWithBase;
			this._coinDealMaxCoinNumber = coinDealMaxCoinNumberWithBase;
			if (coinDealPlayerCoinNumberWithSell <= coinDealMinCoinNumberWithBase)
			{
				this._coinDealMaxCoinNumber = coinDealMinCoinNumberWithBase;
			}
			else if (coinDealPlayerCoinNumberWithSell <= coinDealMaxCoinNumberWithBase)
			{
				this._coinDealMaxCoinNumber = coinDealPlayerCoinNumberWithSell;
			}
		}

		// Token: 0x0600D779 RID: 55161 RVA: 0x0035DA88 File Offset: 0x0035BE88
		private void UpdateCoinDealCoinNumberValueLabel()
		{
			if (this.coinDealCoinNumberValueBaseLabel != null)
			{
				this.coinDealCoinNumberValueBaseLabel.text = this._currentCoinDealCoinNumber.ToString();
			}
			if (this.coinDealCoinNumberValueCommonLabel != null)
			{
				string coinDealCommonCoinNumberStr = CoinDealUtility.GetCoinDealCommonCoinNumberStr(this._currentCoinDealCoinNumber);
				this.coinDealCoinNumberValueCommonLabel.text = coinDealCommonCoinNumberStr;
			}
		}

		// Token: 0x0600D77A RID: 55162 RVA: 0x0035DAEC File Offset: 0x0035BEEC
		private void UpdateCoinDealCoinNumberButtonState()
		{
			if (this._currentCoinDealCoinNumber <= this._coinDealMinCoinNumber)
			{
				CommonUtility.UpdateButtonState(this.coinDealButtonMinusTen, this.coinDealButtonGrayMinusTen, false);
				CommonUtility.UpdateButtonState(this.coinDealButtonMinusOne, this.coinDealButtonGrayMinusOne, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.coinDealButtonMinusTen, this.coinDealButtonGrayMinusTen, true);
				CommonUtility.UpdateButtonState(this.coinDealButtonMinusOne, this.coinDealButtonGrayMinusOne, true);
			}
			if (this._currentCoinDealCoinNumber >= this._coinDealMaxCoinNumber)
			{
				CommonUtility.UpdateButtonState(this.coinDealButtonAddTen, this.coinDealButtonGrayAddTen, false);
				CommonUtility.UpdateButtonState(this.coinDealButtonAddOne, this.coinDealButtonGrayAddOne, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.coinDealButtonAddTen, this.coinDealButtonGrayAddTen, true);
				CommonUtility.UpdateButtonState(this.coinDealButtonAddOne, this.coinDealButtonGrayAddOne, true);
			}
		}

		// Token: 0x0600D77B RID: 55163 RVA: 0x0035DBB5 File Offset: 0x0035BFB5
		public void UpdateCoinDealSinglePriceWithSinglePrice(int singlePrice)
		{
			this._currentCoinDealSinglePrice = singlePrice;
			this.UpdateCoinDealSinglePriceValueLabel();
			this.UpdateCoinDealSinglePriceData();
			this.UpdateCoinDealSinglePriceButtonState();
		}

		// Token: 0x0600D77C RID: 55164 RVA: 0x0035DBD0 File Offset: 0x0035BFD0
		public void UpdateCoinDealSinglePriceWithoutSinglePrice()
		{
			this.UpdateCoinDealSinglePriceData();
			this.UpdateCoinDealSinglePriceButtonState();
		}

		// Token: 0x0600D77D RID: 55165 RVA: 0x0035DBDE File Offset: 0x0035BFDE
		private void UpdateCoinDealSinglePriceData()
		{
			this._coinDealMinSinglePrice = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMinDealPriceValue();
			this._coinDealMaxSinglePrice = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMaxDealPriceValue();
		}

		// Token: 0x0600D77E RID: 55166 RVA: 0x0035DC00 File Offset: 0x0035C000
		private void UpdateCoinDealSinglePriceValueLabel()
		{
			if (this.singlePriceValueLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)((long)this._currentCoinDealSinglePrice));
				this.singlePriceValueLabel.text = text;
			}
		}

		// Token: 0x0600D77F RID: 55167 RVA: 0x0035DC38 File Offset: 0x0035C038
		private void UpdateCoinDealSinglePriceButtonState()
		{
			if (this._currentCoinDealSinglePrice <= this._coinDealMinSinglePrice)
			{
				CommonUtility.UpdateButtonState(this.singlePriceButtonMinusTen, this.singlePriceButtonGrayMinusTen, false);
				CommonUtility.UpdateButtonState(this.singlePriceButtonMinusOne, this.singlePriceButtonGrayMinusOne, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.singlePriceButtonMinusTen, this.singlePriceButtonGrayMinusTen, true);
				CommonUtility.UpdateButtonState(this.singlePriceButtonMinusOne, this.singlePriceButtonGrayMinusOne, true);
			}
			if (this._currentCoinDealSinglePrice >= this._coinDealMaxSinglePrice)
			{
				CommonUtility.UpdateButtonState(this.singlePriceButtonAddTen, this.singlePriceButtonGrayAddTen, false);
				CommonUtility.UpdateButtonState(this.singlePriceButtonAddOne, this.singlePriceButtonGrayAddOne, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.singlePriceButtonAddTen, this.singlePriceButtonGrayAddTen, true);
				CommonUtility.UpdateButtonState(this.singlePriceButtonAddOne, this.singlePriceButtonGrayAddOne, true);
			}
		}

		// Token: 0x0600D780 RID: 55168 RVA: 0x0035DD01 File Offset: 0x0035C101
		private void UpdateCoinDealCoinNumberViewByChangeValue()
		{
			this.UpdateCoinDealCoinNumberValueLabel();
			this.UpdateCoinDealCoinNumberButtonState();
			if (this._onCoinNumberChangeAction != null)
			{
				this._onCoinNumberChangeAction(this._currentCoinDealCoinNumber);
			}
		}

		// Token: 0x0600D781 RID: 55169 RVA: 0x0035DD2C File Offset: 0x0035C12C
		private void UpdateCoinDealSinglePriceViewByChangeValue(bool isChangeCoinNumber = true)
		{
			this.UpdateCoinDealSinglePriceValueLabel();
			this.UpdateCoinDealSinglePriceButtonState();
			if (this._onSinglePriceChangeAction != null)
			{
				this._onSinglePriceChangeAction(this._currentCoinDealSinglePrice);
			}
			if (isChangeCoinNumber && this._orderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				this.UpdateCoinDealCoinNumberViewByChangeSinglePrice();
			}
		}

		// Token: 0x0600D782 RID: 55170 RVA: 0x0035DD7C File Offset: 0x0035C17C
		private void OnCoinDealButtonMinusTenClick()
		{
			if (this._currentCoinDealCoinNumber <= this._coinDealMinCoinNumber)
			{
				return;
			}
			this._currentCoinDealCoinNumber -= 10;
			if (this._currentCoinDealCoinNumber <= this._coinDealMinCoinNumber)
			{
				this._currentCoinDealCoinNumber = this._coinDealMinCoinNumber;
			}
			this.UpdateCoinDealCoinNumberViewByChangeValue();
		}

		// Token: 0x0600D783 RID: 55171 RVA: 0x0035DDD0 File Offset: 0x0035C1D0
		private void OnCoinDealButtonMinusOneClick()
		{
			if (this._currentCoinDealCoinNumber <= this._coinDealMinCoinNumber)
			{
				return;
			}
			this._currentCoinDealCoinNumber--;
			if (this._currentCoinDealCoinNumber <= this._coinDealMinCoinNumber)
			{
				this._currentCoinDealCoinNumber = this._coinDealMinCoinNumber;
			}
			this.UpdateCoinDealCoinNumberViewByChangeValue();
		}

		// Token: 0x0600D784 RID: 55172 RVA: 0x0035DE20 File Offset: 0x0035C220
		private void OnCoinDealButtonAddTenClick()
		{
			if (this._currentCoinDealCoinNumber >= this._coinDealMaxCoinNumber)
			{
				return;
			}
			this._currentCoinDealCoinNumber += 10;
			if (this._currentCoinDealCoinNumber >= this._coinDealMaxCoinNumber)
			{
				this._currentCoinDealCoinNumber = this._coinDealMaxCoinNumber;
			}
			this.UpdateCoinDealCoinNumberViewByChangeValue();
		}

		// Token: 0x0600D785 RID: 55173 RVA: 0x0035DE74 File Offset: 0x0035C274
		private void OnCoinDealButtonAddOneClick()
		{
			if (this._currentCoinDealCoinNumber >= this._coinDealMaxCoinNumber)
			{
				return;
			}
			this._currentCoinDealCoinNumber++;
			if (this._currentCoinDealCoinNumber >= this._coinDealMaxCoinNumber)
			{
				this._currentCoinDealCoinNumber = this._coinDealMaxCoinNumber;
			}
			this.UpdateCoinDealCoinNumberViewByChangeValue();
		}

		// Token: 0x0600D786 RID: 55174 RVA: 0x0035DEC4 File Offset: 0x0035C2C4
		private void OnCoinDealKeyBoardButtonClick()
		{
			this._coinDealKeyboardInputType = CoinDealKeyBoardInputType.CoinNumberType;
			CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(450f, -40f, 0f), (ulong)((long)this._currentCoinDealCoinNumber), (ulong)((long)this._coinDealMaxCoinNumber));
		}

		// Token: 0x0600D787 RID: 55175 RVA: 0x0035DEF4 File Offset: 0x0035C2F4
		private void OnSinglePriceButtonMinusTenClick()
		{
			if (this._currentCoinDealSinglePrice <= this._coinDealMinSinglePrice)
			{
				return;
			}
			this._currentCoinDealSinglePrice -= 10;
			if (this._currentCoinDealSinglePrice <= this._coinDealMinSinglePrice)
			{
				this._currentCoinDealSinglePrice = this._coinDealMinSinglePrice;
			}
			this.UpdateCoinDealSinglePriceViewByChangeValue(true);
		}

		// Token: 0x0600D788 RID: 55176 RVA: 0x0035DF48 File Offset: 0x0035C348
		private void OnSinglePriceButtonMinusOneClick()
		{
			if (this._currentCoinDealSinglePrice <= this._coinDealMinSinglePrice)
			{
				return;
			}
			this._currentCoinDealSinglePrice--;
			if (this._currentCoinDealSinglePrice <= this._coinDealMinSinglePrice)
			{
				this._currentCoinDealSinglePrice = this._coinDealMinSinglePrice;
			}
			this.UpdateCoinDealSinglePriceViewByChangeValue(true);
		}

		// Token: 0x0600D789 RID: 55177 RVA: 0x0035DF9C File Offset: 0x0035C39C
		private void OnSinglePriceButtonAddTenClick()
		{
			if (this._currentCoinDealSinglePrice >= this._coinDealMaxSinglePrice)
			{
				return;
			}
			this._currentCoinDealSinglePrice += 10;
			if (this._currentCoinDealSinglePrice >= this._coinDealMaxSinglePrice)
			{
				this._currentCoinDealSinglePrice = this._coinDealMaxSinglePrice;
			}
			this.UpdateCoinDealSinglePriceViewByChangeValue(true);
		}

		// Token: 0x0600D78A RID: 55178 RVA: 0x0035DFF0 File Offset: 0x0035C3F0
		private void OnSinglePriceButtonAddOneClick()
		{
			if (this._currentCoinDealSinglePrice >= this._coinDealMaxSinglePrice)
			{
				return;
			}
			this._currentCoinDealSinglePrice++;
			if (this._currentCoinDealSinglePrice >= this._coinDealMaxSinglePrice)
			{
				this._currentCoinDealSinglePrice = this._coinDealMaxSinglePrice;
			}
			this.UpdateCoinDealSinglePriceViewByChangeValue(true);
		}

		// Token: 0x0600D78B RID: 55179 RVA: 0x0035E041 File Offset: 0x0035C441
		private void OnSinglePriceKeyBoardButtonClick()
		{
			this._coinDealKeyboardInputType = CoinDealKeyBoardInputType.SinglePriceType;
			CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(450f, -195f, 0f), (ulong)((long)this._currentCoinDealSinglePrice), (ulong)((long)this._coinDealMaxSinglePrice));
		}

		// Token: 0x0600D78C RID: 55180 RVA: 0x0035E071 File Offset: 0x0035C471
		private void UpdateCoinDealCoinNumberViewByChangeSinglePrice()
		{
			this.UpdateCoinDealCoinNumberDataWithBuy();
			this.UpdateCoinDealCoinNumberButtonState();
		}

		// Token: 0x0600D78D RID: 55181 RVA: 0x0035E080 File Offset: 0x0035C480
		private void OnCommonKeyBoardInput(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			CommonKeyBoardInputType commonKeyBoardInputType = (CommonKeyBoardInputType)uiEvent.Param1;
			ulong keyBoardInputValue = (ulong)uiEvent.Param2;
			if (commonKeyBoardInputType == CommonKeyBoardInputType.ChangeNumber)
			{
				this.UpdateValueByUserInput(keyBoardInputValue);
			}
			else if (commonKeyBoardInputType == CommonKeyBoardInputType.Finished)
			{
				this.UpdateValueByFinishInput(keyBoardInputValue);
				this._coinDealKeyboardInputType = CoinDealKeyBoardInputType.None;
			}
		}

		// Token: 0x0600D78E RID: 55182 RVA: 0x0035E0EC File Offset: 0x0035C4EC
		private void UpdateValueByUserInput(ulong keyBoardInputValue)
		{
			int inputValue = (int)keyBoardInputValue;
			CoinDealKeyBoardInputType coinDealKeyboardInputType = this._coinDealKeyboardInputType;
			if (coinDealKeyboardInputType != CoinDealKeyBoardInputType.CoinNumberType)
			{
				if (coinDealKeyboardInputType == CoinDealKeyBoardInputType.SinglePriceType)
				{
					this.UpdateCoinDealSinglePriceByKeyBoardChangeInput(inputValue);
				}
			}
			else
			{
				this.UpdateCoinDealCoinNumberByKeyBoardChangeInput(inputValue);
			}
		}

		// Token: 0x0600D78F RID: 55183 RVA: 0x0035E134 File Offset: 0x0035C534
		private void UpdateValueByFinishInput(ulong keyBoardInputValue)
		{
			int inputValue = (int)keyBoardInputValue;
			CoinDealKeyBoardInputType coinDealKeyboardInputType = this._coinDealKeyboardInputType;
			if (coinDealKeyboardInputType != CoinDealKeyBoardInputType.CoinNumberType)
			{
				if (coinDealKeyboardInputType == CoinDealKeyBoardInputType.SinglePriceType)
				{
					this.UpdateCoinDealSinglePriceByKeyBoardFinishInput(inputValue);
				}
			}
			else
			{
				this.UpdateCoinDealCoinNumberByKeyBoardFinishInput(inputValue);
			}
		}

		// Token: 0x0600D790 RID: 55184 RVA: 0x0035E17A File Offset: 0x0035C57A
		private void UpdateCoinDealCoinNumberByKeyBoardChangeInput(int inputValue)
		{
			this._currentCoinDealCoinNumber = inputValue;
			if (this._currentCoinDealCoinNumber >= this._coinDealMaxCoinNumber)
			{
				this._currentCoinDealCoinNumber = this._coinDealMaxCoinNumber;
			}
			this.UpdateCoinDealCoinNumberViewByChangeValue();
		}

		// Token: 0x0600D791 RID: 55185 RVA: 0x0035E1A6 File Offset: 0x0035C5A6
		private void UpdateCoinDealSinglePriceByKeyBoardChangeInput(int inputValue)
		{
			this._currentCoinDealSinglePrice = inputValue;
			if (this._currentCoinDealSinglePrice >= this._coinDealMaxSinglePrice)
			{
				this._currentCoinDealSinglePrice = this._coinDealMaxSinglePrice;
			}
			this.UpdateCoinDealSinglePriceViewByChangeValue(false);
		}

		// Token: 0x0600D792 RID: 55186 RVA: 0x0035E1D4 File Offset: 0x0035C5D4
		private void UpdateCoinDealCoinNumberByKeyBoardFinishInput(int inputValue)
		{
			this._currentCoinDealCoinNumber = inputValue;
			if (this._currentCoinDealCoinNumber <= this._coinDealMinCoinNumber)
			{
				this._currentCoinDealCoinNumber = this._coinDealMinCoinNumber;
			}
			else if (this._currentCoinDealCoinNumber >= this._coinDealMaxCoinNumber)
			{
				this._currentCoinDealCoinNumber = this._coinDealMaxCoinNumber;
			}
			this.UpdateCoinDealCoinNumberViewByChangeValue();
		}

		// Token: 0x0600D793 RID: 55187 RVA: 0x0035E230 File Offset: 0x0035C630
		private void UpdateCoinDealSinglePriceByKeyBoardFinishInput(int inputValue)
		{
			this._currentCoinDealSinglePrice = inputValue;
			if (this._currentCoinDealSinglePrice <= this._coinDealMinSinglePrice)
			{
				this._currentCoinDealSinglePrice = this._coinDealMinSinglePrice;
			}
			else if (this._currentCoinDealSinglePrice >= this._coinDealMaxSinglePrice)
			{
				this._currentCoinDealSinglePrice = this._coinDealMaxSinglePrice;
			}
			this.UpdateCoinDealSinglePriceViewByChangeValue(true);
		}

		// Token: 0x04007E6F RID: 32367
		private OnCoinDealCoinNumberChangeAction _onCoinNumberChangeAction;

		// Token: 0x04007E70 RID: 32368
		private OnCoinDealSinglePriceChangeAction _onSinglePriceChangeAction;

		// Token: 0x04007E71 RID: 32369
		private int _coinDealMinCoinNumber;

		// Token: 0x04007E72 RID: 32370
		private int _coinDealMaxCoinNumber;

		// Token: 0x04007E73 RID: 32371
		private int _coinDealMinSinglePrice;

		// Token: 0x04007E74 RID: 32372
		private int _coinDealMaxSinglePrice;

		// Token: 0x04007E75 RID: 32373
		private GoldConsignmentOrderType _orderType;

		// Token: 0x04007E76 RID: 32374
		private int _currentCoinDealCoinNumber;

		// Token: 0x04007E77 RID: 32375
		private int _currentCoinDealSinglePrice;

		// Token: 0x04007E78 RID: 32376
		private CoinDealKeyBoardInputType _coinDealKeyboardInputType = CoinDealKeyBoardInputType.None;

		// Token: 0x04007E79 RID: 32377
		[Space(10f)]
		[Header("DealCoin")]
		[Space(10f)]
		[SerializeField]
		private Text coinDealCoinNumberValueBaseLabel;

		// Token: 0x04007E7A RID: 32378
		[SerializeField]
		private Text coinDealCoinNumberValueCommonLabel;

		// Token: 0x04007E7B RID: 32379
		[SerializeField]
		private Button coinDealButtonMinusTen;

		// Token: 0x04007E7C RID: 32380
		[SerializeField]
		private UIGray coinDealButtonGrayMinusTen;

		// Token: 0x04007E7D RID: 32381
		[SerializeField]
		private Button coinDealButtonMinusOne;

		// Token: 0x04007E7E RID: 32382
		[SerializeField]
		private UIGray coinDealButtonGrayMinusOne;

		// Token: 0x04007E7F RID: 32383
		[SerializeField]
		private Button coinDealButtonAddOne;

		// Token: 0x04007E80 RID: 32384
		[SerializeField]
		private UIGray coinDealButtonGrayAddOne;

		// Token: 0x04007E81 RID: 32385
		[SerializeField]
		private Button coinDealButtonAddTen;

		// Token: 0x04007E82 RID: 32386
		[SerializeField]
		private UIGray coinDealButtonGrayAddTen;

		// Token: 0x04007E83 RID: 32387
		[SerializeField]
		private Button coinDealKeyBoardButton;

		// Token: 0x04007E84 RID: 32388
		[Space(10f)]
		[Header("singlePrice")]
		[Space(10f)]
		[SerializeField]
		private Text singlePriceValueLabel;

		// Token: 0x04007E85 RID: 32389
		[SerializeField]
		private Button singlePriceButtonMinusTen;

		// Token: 0x04007E86 RID: 32390
		[SerializeField]
		private UIGray singlePriceButtonGrayMinusTen;

		// Token: 0x04007E87 RID: 32391
		[SerializeField]
		private Button singlePriceButtonMinusOne;

		// Token: 0x04007E88 RID: 32392
		[SerializeField]
		private UIGray singlePriceButtonGrayMinusOne;

		// Token: 0x04007E89 RID: 32393
		[SerializeField]
		private Button singlePriceButtonAddOne;

		// Token: 0x04007E8A RID: 32394
		[SerializeField]
		private UIGray singlePriceButtonGrayAddOne;

		// Token: 0x04007E8B RID: 32395
		[SerializeField]
		private Button singlePriceButtonAddTen;

		// Token: 0x04007E8C RID: 32396
		[SerializeField]
		private UIGray singlePriceButtonGrayAddTen;

		// Token: 0x04007E8D RID: 32397
		[SerializeField]
		private Button singlePriceKeyBoardButton;
	}
}
