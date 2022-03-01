using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200140D RID: 5133
	public class AdventureTeamExpeditionCharacterSelectUnit : MonoBehaviour
	{
		// Token: 0x0600C6E4 RID: 50916 RVA: 0x00300CAE File Offset: 0x002FF0AE
		private void Awake()
		{
			this._InitTR();
			this.ClearData();
		}

		// Token: 0x0600C6E5 RID: 50917 RVA: 0x00300CBC File Offset: 0x002FF0BC
		private void OnDestroy()
		{
			this._ClearTR();
			this.ClearData();
		}

		// Token: 0x0600C6E6 RID: 50918 RVA: 0x00300CCA File Offset: 0x002FF0CA
		private void _InitTR()
		{
			this.tr_expedition_role_select_lv_limit = TR.Value("adventure_team_expedition_role_select_lv_limit");
			this.tr_expedition_role_select_dispatch = TR.Value("adventure_team_expedition_role_select_dispatch");
		}

		// Token: 0x0600C6E7 RID: 50919 RVA: 0x00300CEC File Offset: 0x002FF0EC
		private void _ClearTR()
		{
			this.tr_expedition_role_select_lv_limit = string.Empty;
			this.tr_expedition_role_select_dispatch = string.Empty;
		}

		// Token: 0x0600C6E8 RID: 50920 RVA: 0x00300D04 File Offset: 0x002FF104
		public void InitItemView(ExpeditionMemberInfo roleInfo, ExpeditionRoleState roleState)
		{
			this.tempRoleInfo = roleInfo;
			this.tempRoleState = roleState;
		}

		// Token: 0x0600C6E9 RID: 50921 RVA: 0x00300D14 File Offset: 0x002FF114
		public void UpdateItemInfo()
		{
			switch (this.tempRoleState)
			{
			case ExpeditionRoleState.PREPARE:
				this.mUnEnableObj.SetActive(false);
				this.mIsSelectImage.SetActive(false);
				this.mChangeExpeditionRoleBtn.onClick.AddListener(new UnityAction(this._OnChangeRoleBtnClick));
				this.mChangeExpeditionRoleBtn.enabled = true;
				break;
			case ExpeditionRoleState.SELECT:
				this.mUnEnableObj.SetActive(false);
				this.mIsSelectImage.SetActive(true);
				this.mChangeExpeditionRoleBtn.onClick.AddListener(new UnityAction(this._OnChangeRoleBtnClick));
				this.mChangeExpeditionRoleBtn.enabled = true;
				break;
			case ExpeditionRoleState.LEVEL_LIMIT:
				this.mUnEnableObj.SetActive(true);
				this.mUnEnableText.text = this.tr_expedition_role_select_lv_limit;
				this.mIsSelectImage.SetActive(false);
				this.mChangeExpeditionRoleBtn.enabled = false;
				break;
			case ExpeditionRoleState.EXPEDITION:
				this.mUnEnableObj.SetActive(true);
				this.mUnEnableText.text = this.tr_expedition_role_select_dispatch;
				this.mIsSelectImage.SetActive(false);
				this.mChangeExpeditionRoleBtn.enabled = false;
				break;
			}
			this.mRoleLv.text = "Lv." + this.tempRoleInfo.level.ToString();
			this.mRoleName.text = this.tempRoleInfo.name;
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)this.tempRoleInfo.occu, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find JobTable with id:{0}", new object[]
				{
					this.tempRoleInfo.occu
				});
			}
			else
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				ETCImageLoader.LoadSprite(ref this.mRoleIcon, tableItem2.IconPath, true);
				this.mRoleOccu.text = tableItem.Name;
			}
		}

		// Token: 0x0600C6EA RID: 50922 RVA: 0x00300F14 File Offset: 0x002FF314
		private void _OnChangeRoleBtnClick()
		{
			if (this.tempRoleState == ExpeditionRoleState.PREPARE)
			{
				bool flag = DataManager<AdventureTeamDataManager>.GetInstance().AddExpeditionRole(this.tempRoleInfo);
				if (flag)
				{
					this.tempRoleState = ExpeditionRoleState.SELECT;
					this.mIsSelectImage.SetActive(true);
				}
			}
			else if (this.tempRoleState == ExpeditionRoleState.SELECT)
			{
				bool flag2 = DataManager<AdventureTeamDataManager>.GetInstance().RemoveExpeditionRole(this.tempRoleInfo);
				if (flag2)
				{
					this.tempRoleState = ExpeditionRoleState.PREPARE;
					this.mIsSelectImage.SetActive(false);
				}
			}
		}

		// Token: 0x0600C6EB RID: 50923 RVA: 0x00300F91 File Offset: 0x002FF391
		public void OnItemRecycle()
		{
			this.ClearData();
		}

		// Token: 0x0600C6EC RID: 50924 RVA: 0x00300F99 File Offset: 0x002FF399
		private void ClearData()
		{
			this.tempRoleInfo = null;
			this.mChangeExpeditionRoleBtn.onClick.RemoveListener(new UnityAction(this._OnChangeRoleBtnClick));
		}

		// Token: 0x0400721E RID: 29214
		[SerializeField]
		private Text mRoleOccu;

		// Token: 0x0400721F RID: 29215
		[SerializeField]
		private Text mRoleName;

		// Token: 0x04007220 RID: 29216
		[SerializeField]
		private Text mRoleLv;

		// Token: 0x04007221 RID: 29217
		[SerializeField]
		private Text mUnEnableText;

		// Token: 0x04007222 RID: 29218
		[SerializeField]
		private GameObject mUnEnableObj;

		// Token: 0x04007223 RID: 29219
		[SerializeField]
		private Button mChangeExpeditionRoleBtn;

		// Token: 0x04007224 RID: 29220
		[SerializeField]
		private GameObject mIsSelectImage;

		// Token: 0x04007225 RID: 29221
		[SerializeField]
		private Image mRoleIcon;

		// Token: 0x04007226 RID: 29222
		[SerializeField]
		private ExpeditionMemberInfo tempRoleInfo;

		// Token: 0x04007227 RID: 29223
		[SerializeField]
		private ExpeditionRoleState tempRoleState;

		// Token: 0x04007228 RID: 29224
		private string tr_expedition_role_select_lv_limit = string.Empty;

		// Token: 0x04007229 RID: 29225
		private string tr_expedition_role_select_dispatch = string.Empty;
	}
}
