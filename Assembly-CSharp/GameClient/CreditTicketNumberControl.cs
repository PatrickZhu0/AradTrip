using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001587 RID: 5511
	public class CreditTicketNumberControl : MonoBehaviour
	{
		// Token: 0x0600D7B1 RID: 55217 RVA: 0x0035EA97 File Offset: 0x0035CE97
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D7B2 RID: 55218 RVA: 0x0035EA9F File Offset: 0x0035CE9F
		private void OnDestroy()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x0600D7B3 RID: 55219 RVA: 0x0035EAA7 File Offset: 0x0035CEA7
		private void BindUiEvents()
		{
			if (this.searchButton != null)
			{
				this.searchButton.onClick.RemoveAllListeners();
				this.searchButton.onClick.AddListener(new UnityAction(this.OnSearchButtonClick));
			}
		}

		// Token: 0x0600D7B4 RID: 55220 RVA: 0x0035EAE6 File Offset: 0x0035CEE6
		private void UnBindUiEvents()
		{
			if (this.searchButton != null)
			{
				this.searchButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D7B5 RID: 55221 RVA: 0x0035EB0C File Offset: 0x0035CF0C
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this.OnPlayerVipLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CreditTicketOwnerBySelfChanged, new ClientEventSystem.UIEventHandler(this.OnCreditTicketOwnerBySelfChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CreditTicketGetInMonthChanged, new ClientEventSystem.UIEventHandler(this.OnCreditTicketGetInMonthChanged));
		}

		// Token: 0x0600D7B6 RID: 55222 RVA: 0x0035EB7C File Offset: 0x0035CF7C
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this.OnPlayerVipLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CreditTicketOwnerBySelfChanged, new ClientEventSystem.UIEventHandler(this.OnCreditTicketOwnerBySelfChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CreditTicketGetInMonthChanged, new ClientEventSystem.UIEventHandler(this.OnCreditTicketGetInMonthChanged));
		}

		// Token: 0x0600D7B7 RID: 55223 RVA: 0x0035EBEC File Offset: 0x0035CFEC
		public void InitControl(int itemId)
		{
			this._itemId = itemId;
			this.InitIcon();
			this.UpdateCreditTicketNumberLabel();
		}

		// Token: 0x0600D7B8 RID: 55224 RVA: 0x0035EC01 File Offset: 0x0035D001
		public void OnEnableControl()
		{
			this.UpdateCreditTicketNumberLabel();
		}

		// Token: 0x0600D7B9 RID: 55225 RVA: 0x0035EC0C File Offset: 0x0035D00C
		private void InitIcon()
		{
			if (this.creditTicketIcon == null)
			{
				return;
			}
			this._creditTicketItemTable = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketItemTable();
			if (this._creditTicketItemTable == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.creditTicketIcon, this._creditTicketItemTable.Icon, true);
		}

		// Token: 0x0600D7BA RID: 55226 RVA: 0x0035EC60 File Offset: 0x0035D060
		private void UpdateCreditTicketNumberLabel()
		{
			CreditTicketType creditTicketType = this.creditTicketType;
			if (creditTicketType != CreditTicketType.MonthGetType)
			{
				if (creditTicketType == CreditTicketType.OwnerType)
				{
					this.UpdateCreditTicketNumberOwnerBySelf();
				}
			}
			else
			{
				this.UpdateCreditTicketNumberGetInMonth();
			}
		}

		// Token: 0x0600D7BB RID: 55227 RVA: 0x0035ECA4 File Offset: 0x0035D0A4
		private void UpdateCreditTicketNumberGetInMonth()
		{
			if (this.creditTicketNumberLabel == null)
			{
				return;
			}
			uint creditTicketGetInMonth = DataManager<PlayerBaseData>.GetInstance().CreditTicketGetInMonth;
			int creditTicketMaxNumberInMonth = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketMaxNumberInMonth();
			string arg = Utility.ToThousandsSeparator((ulong)creditTicketGetInMonth);
			string arg2 = Utility.ToThousandsSeparator((ulong)((long)creditTicketMaxNumberInMonth));
			string text = TR.Value("Common_Two_Number_Format_One", arg, arg2);
			this.creditTicketNumberLabel.text = text;
		}

		// Token: 0x0600D7BC RID: 55228 RVA: 0x0035ED04 File Offset: 0x0035D104
		private void UpdateCreditTicketNumberOwnerBySelf()
		{
			if (this.creditTicketNumberLabel == null)
			{
				return;
			}
			uint creditTicketOwnerBySelf = DataManager<PlayerBaseData>.GetInstance().CreditTicketOwnerBySelf;
			int creditTicketMaxNumberInSelfPlayer = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketMaxNumberInSelfPlayer();
			string arg = Utility.ToThousandsSeparator((ulong)creditTicketOwnerBySelf);
			string arg2 = Utility.ToThousandsSeparator((ulong)((long)creditTicketMaxNumberInSelfPlayer));
			string text = TR.Value("Common_Two_Number_Format_One", arg, arg2);
			this.creditTicketNumberLabel.text = text;
		}

		// Token: 0x0600D7BD RID: 55229 RVA: 0x0035ED64 File Offset: 0x0035D164
		private void OnPlayerVipLevelChanged(UIEvent uiEvent)
		{
			this.UpdateCreditTicketNumberLabel();
		}

		// Token: 0x0600D7BE RID: 55230 RVA: 0x0035ED6C File Offset: 0x0035D16C
		private void OnLevelChanged(UIEvent uiEvent)
		{
			this.UpdateCreditTicketNumberLabel();
		}

		// Token: 0x0600D7BF RID: 55231 RVA: 0x0035ED74 File Offset: 0x0035D174
		private void OnCreditTicketOwnerBySelfChanged(UIEvent uiEvent)
		{
			if (this.creditTicketType == CreditTicketType.OwnerType)
			{
				this.UpdateCreditTicketNumberLabel();
			}
		}

		// Token: 0x0600D7C0 RID: 55232 RVA: 0x0035ED88 File Offset: 0x0035D188
		private void OnCreditTicketGetInMonthChanged(UIEvent uiEvent)
		{
			if (this.creditTicketType == CreditTicketType.MonthGetType)
			{
				this.UpdateCreditTicketNumberLabel();
			}
		}

		// Token: 0x0600D7C1 RID: 55233 RVA: 0x0035ED9C File Offset: 0x0035D19C
		private void OnSearchButtonClick()
		{
			CoinDealUtility.OnOpenCoinDealRecordDetailFrame();
		}

		// Token: 0x04007E9D RID: 32413
		private int _itemId;

		// Token: 0x04007E9E RID: 32414
		private ItemTable _creditTicketItemTable;

		// Token: 0x04007E9F RID: 32415
		[Space(10f)]
		[Header("Type")]
		[Space(10f)]
		[SerializeField]
		private CreditTicketType creditTicketType;

		// Token: 0x04007EA0 RID: 32416
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Image creditTicketIcon;

		// Token: 0x04007EA1 RID: 32417
		[SerializeField]
		private Text creditTicketNumberLabel;

		// Token: 0x04007EA2 RID: 32418
		[SerializeField]
		private Button searchButton;
	}
}
