using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013FF RID: 5119
	public class AdventureTeamChangeNameView : MonoBehaviour
	{
		// Token: 0x0600C64D RID: 50765 RVA: 0x002FDBE0 File Offset: 0x002FBFE0
		private void Awake()
		{
			this._BindUIEvents();
			this._InitTR();
		}

		// Token: 0x0600C64E RID: 50766 RVA: 0x002FDBEE File Offset: 0x002FBFEE
		private void OnDestroy()
		{
			this._UnBindUIEvents();
		}

		// Token: 0x0600C64F RID: 50767 RVA: 0x002FDBF8 File Offset: 0x002FBFF8
		private void _BindUIEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.AddListener(new UnityAction(this._OnCloseButtonClickCallBack));
			}
			if (this.okButton != null)
			{
				this.okButton.onClick.AddListener(new UnityAction(this._OnOkButtonClickCallBack));
			}
			if (this.nameInputFiled != null)
			{
				this.nameInputFiled.onValueChanged.AddListener(new UnityAction<string>(this._OnNameInputValueChanged));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamRenameSucc, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamRenameSucc));
		}

		// Token: 0x0600C650 RID: 50768 RVA: 0x002FDCA8 File Offset: 0x002FC0A8
		private void _UnBindUIEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveListener(new UnityAction(this._OnCloseButtonClickCallBack));
			}
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveListener(new UnityAction(this._OnOkButtonClickCallBack));
			}
			if (this.nameInputFiled != null)
			{
				this.nameInputFiled.onValueChanged.RemoveListener(new UnityAction<string>(this._OnNameInputValueChanged));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamRenameSucc, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamRenameSucc));
		}

		// Token: 0x0600C651 RID: 50769 RVA: 0x002FDD57 File Offset: 0x002FC157
		private void _InitTR()
		{
			this.tr_title_adventure_team_change_name = TR.Value("adventure_team_change_name");
			this.tr_common_msg_btn_ok = TR.Value("common_data_sure");
		}

		// Token: 0x0600C652 RID: 50770 RVA: 0x002FDD79 File Offset: 0x002FC179
		private void _ClearView()
		{
			this.tr_title_adventure_team_change_name = null;
			this.tr_common_msg_btn_ok = null;
			this.renameModel = null;
		}

		// Token: 0x0600C653 RID: 50771 RVA: 0x002FDD90 File Offset: 0x002FC190
		private void _InitBaseData()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = this.tr_title_adventure_team_change_name;
			}
			if (this.okButtonText != null)
			{
				this.okButtonText.text = this.tr_common_msg_btn_ok;
			}
		}

		// Token: 0x0600C654 RID: 50772 RVA: 0x002FDDE4 File Offset: 0x002FC1E4
		private void _InitNameInputData()
		{
			this._limitNumber = DataManager<AdventureTeamDataManager>.GetInstance().RenameLimitCharNum;
			if (this.nameInputFiled != null && this.nameInputFiled.characterLimit > this._limitNumber)
			{
				this._limitNumber = this.nameInputFiled.characterLimit;
			}
			if (this.nameInputPlaceHolder != null)
			{
				this.nameInputPlaceHolder.text = TR.Value("adventure_team_input_new_name");
			}
			this._UpdateNameInputData();
		}

		// Token: 0x0600C655 RID: 50773 RVA: 0x002FDE68 File Offset: 0x002FC268
		private void _UpdateNameInputData()
		{
			if (this.nameInputNumberLabel != null && this.nameInputFiled != null && this.nameInputFiled.text != null)
			{
				this.nameInputNumberLabel.text = string.Format(TR.Value("adventure_team_name_count"), this.nameInputFiled.text.Length, this._limitNumber);
				if (this.renameModel != null)
				{
					this.renameModel.newNameStr = this.nameInputFiled.text;
				}
			}
		}

		// Token: 0x0600C656 RID: 50774 RVA: 0x002FDF02 File Offset: 0x002FC302
		private void _CloseFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdventureTeamChangeNameFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdventureTeamChangeNameFrame>(null, false);
			}
		}

		// Token: 0x0600C657 RID: 50775 RVA: 0x002FDF20 File Offset: 0x002FC320
		private void _OnNameInputValueChanged(string text)
		{
			this._UpdateNameInputData();
		}

		// Token: 0x0600C658 RID: 50776 RVA: 0x002FDF28 File Offset: 0x002FC328
		private void _OnCloseButtonClickCallBack()
		{
			this._CloseFrame();
		}

		// Token: 0x0600C659 RID: 50777 RVA: 0x002FDF30 File Offset: 0x002FC330
		private void _OnOkButtonClickCallBack()
		{
			if (this.comBtnCD == null)
			{
				return;
			}
			if (this.comBtnCD.IsBtnWork() && this.renameModel != null)
			{
				this._TryUseOrBuyAdventureTeamRenameCard();
			}
		}

		// Token: 0x0600C65A RID: 50778 RVA: 0x002FDF65 File Offset: 0x002FC365
		private void _OnAdventureTeamRenameSucc(UIEvent _uiEvent)
		{
			this._CloseFrame();
		}

		// Token: 0x0600C65B RID: 50779 RVA: 0x002FDF70 File Offset: 0x002FC370
		private void _OnBuyAdventureTeamRenameCardSucc(UIEvent _uiEvent)
		{
			if (_uiEvent != null && _uiEvent.Param1 != null)
			{
				ItemSimpleData itemSimpleData = _uiEvent.Param1 as ItemSimpleData;
				if (itemSimpleData == null)
				{
					return;
				}
				MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>(itemSimpleData.ItemID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				if (tableItem.itemid == DataManager<AdventureTeamDataManager>.GetInstance().RenameCardTableId)
				{
					this._TryUseOrBuyAdventureTeamRenameCard();
				}
			}
		}

		// Token: 0x0600C65C RID: 50780 RVA: 0x002FDFE0 File Offset: 0x002FC3E0
		private void _TryUseOrBuyAdventureTeamRenameCard()
		{
			if (this.renameModel == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this.renameModel.newNameStr))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventure_team_change_name_no_content"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.renameModel.newNameStr.Length > DataManager<AdventureTeamDataManager>.GetInstance().RenameLimitCharNum)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventure_team_change_name_exceed_upper_limit"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			List<ulong> itemsByPackageThirdType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageThirdType(EPackageType.Consumable, ItemTable.eSubType.ChangeName, ItemTable.eThirdType.ChangeAdventureName);
			if (itemsByPackageThirdType == null || itemsByPackageThirdType.Count <= 0)
			{
				this.renameModel.renameItemGUID = 0UL;
				this.renameModel.renameItemTableId = 0U;
				DataManager<AdventureTeamDataManager>.GetInstance().QuickChangeTeamNameByCostItem(this.renameModel);
			}
			else
			{
				ulong num = itemsByPackageThirdType[0];
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
				this.renameModel.renameItemGUID = num;
				if (item != null)
				{
					this.renameModel.renameItemTableId = (uint)item.TableID;
				}
				DataManager<AdventureTeamDataManager>.GetInstance().ReqChangeTeamName(this.renameModel);
			}
		}

		// Token: 0x0600C65D RID: 50781 RVA: 0x002FE0EB File Offset: 0x002FC4EB
		public void InitData(AdventureTeamRenameModel model)
		{
			this.renameModel = model;
			this._InitBaseData();
			this._InitNameInputData();
		}

		// Token: 0x0600C65E RID: 50782 RVA: 0x002FE100 File Offset: 0x002FC500
		public void Clear()
		{
			this._ClearView();
		}

		// Token: 0x040071BF RID: 29119
		private AdventureTeamRenameModel renameModel;

		// Token: 0x040071C0 RID: 29120
		private string tr_title_adventure_team_change_name = string.Empty;

		// Token: 0x040071C1 RID: 29121
		private string tr_common_msg_btn_ok = string.Empty;

		// Token: 0x040071C2 RID: 29122
		private int _limitNumber = 7;

		// Token: 0x040071C3 RID: 29123
		[Space(10f)]
		[Header("Title")]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x040071C4 RID: 29124
		[Space(10f)]
		[Header("nameInput")]
		[SerializeField]
		private InputField nameInputFiled;

		// Token: 0x040071C5 RID: 29125
		[SerializeField]
		private Text nameInputPlaceHolder;

		// Token: 0x040071C6 RID: 29126
		[SerializeField]
		private Text nameInputNumberLabel;

		// Token: 0x040071C7 RID: 29127
		[Space(10f)]
		[Header("Button")]
		[SerializeField]
		private Button closeButton;

		// Token: 0x040071C8 RID: 29128
		[SerializeField]
		private Button okButton;

		// Token: 0x040071C9 RID: 29129
		[SerializeField]
		private SetComButtonCD comBtnCD;

		// Token: 0x040071CA RID: 29130
		[SerializeField]
		private Text okButtonText;

		// Token: 0x040071CB RID: 29131
		[SerializeField]
		private float waitTimeToUseRenameCard = 1f;
	}
}
