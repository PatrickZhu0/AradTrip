using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001419 RID: 5145
	public class AdventureTeamExpeditionRoleSelectItem : MonoBehaviour
	{
		// Token: 0x0600C778 RID: 51064 RVA: 0x00303F10 File Offset: 0x00302310
		public void InitItemView(int index, ExpeditionMemberInfo roleInfo)
		{
			if (this.mTitleText)
			{
				this.mTitleText.text = (index + 1).ToString();
			}
			this.tempRoleInfo = roleInfo;
			if (this.tempRoleInfo == null)
			{
				if (this.mAddRoleImage)
				{
					this.mAddRoleImage.SetActive(true);
				}
				if (this.mModelAvater)
				{
					this.mModelAvater.ClearAvatar();
					this.mModelAvater.LoadAvatar("Effects/Scene_effects/EffectUI/EffUI_chuangjue_fazhen_JS_jingtai", this.ModelLayer + index);
				}
			}
			else
			{
				if (this.mAddRoleImage)
				{
					this.mAddRoleImage.SetActive(false);
				}
				if (this.mModelRoot)
				{
					this.mModelRoot.SetActive(true);
				}
				this._InitRoleModel(index);
			}
			this._UpdateRoleSelectBtn();
		}

		// Token: 0x0600C779 RID: 51065 RVA: 0x00303FF4 File Offset: 0x003023F4
		public void OnItemRecycle()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600C77A RID: 51066 RVA: 0x00304002 File Offset: 0x00302402
		private void Awake()
		{
			this.ClearData();
		}

		// Token: 0x0600C77B RID: 51067 RVA: 0x0030400A File Offset: 0x0030240A
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600C77C RID: 51068 RVA: 0x00304018 File Offset: 0x00302418
		private void ClearData()
		{
			this.tempRoleInfo = null;
			if (this.mModelAvater)
			{
				this.mModelAvater.ClearAvatar();
			}
		}

		// Token: 0x0600C77D RID: 51069 RVA: 0x0030403C File Offset: 0x0030243C
		private void UnBindUiEventSystem()
		{
			if (this.mRoleSelectButton != null)
			{
				this.mRoleSelectButton.onClick.RemoveListener(new UnityAction(this._OnRoleSelectBtnClick));
			}
		}

		// Token: 0x0600C77E RID: 51070 RVA: 0x0030406C File Offset: 0x0030246C
		private void _InitRoleModel(int index)
		{
			if (this.mLevelext)
			{
				this.mLevelext.text = "Lv." + this.tempRoleInfo.level;
			}
			if (this.mRoleNameText)
			{
				this.mRoleNameText.text = this.tempRoleInfo.name;
			}
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
				if (this.mOccuText)
				{
					this.mOccuText.text = Utility.GetJobName((int)this.tempRoleInfo.occu, 0);
				}
				ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
					{
						tableItem.Mode
					});
				}
				else if (null != this.mModelAvater)
				{
					this.mModelAvater.LoadAvatar(tableItem2.ModelPath, this.ModelLayer + index);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(this.mModelAvater, this.tempRoleInfo.avatar.equipItemIds, (int)this.tempRoleInfo.occu, (int)this.tempRoleInfo.avatar.weaponStrengthen, null, false, this.tempRoleInfo.avatar.isShoWeapon, false);
					this.mModelAvater.ChangeAction("Anim_Show_Idle", 1f, true);
					this.mModelAvater.AttachAvatar("DisSelect", "Effects/Scene_effects/EffectUI/EffUI_chuangjue_fazhen_JS_jingtai", "[actor]Orign", false, true, false, 0f);
				}
			}
		}

		// Token: 0x0600C77F RID: 51071 RVA: 0x00304244 File Offset: 0x00302644
		private void _UpdateRoleSelectBtn()
		{
			if (DataManager<AdventureTeamDataManager>.GetInstance().IsExpeditionMapEnable())
			{
				if (this.mRoleSelectButton)
				{
					this.mRoleSelectButton.enabled = true;
					this.mRoleSelectButton.onClick.AddListener(new UnityAction(this._OnRoleSelectBtnClick));
				}
			}
			else if (this.mRoleSelectButton)
			{
				this.mRoleSelectButton.enabled = false;
			}
		}

		// Token: 0x0600C780 RID: 51072 RVA: 0x003042B9 File Offset: 0x003026B9
		private void _OnRoleSelectBtnClick()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().TryOpenExpeditionRoleSelectFrame(this.tempRoleInfo);
		}

		// Token: 0x04007284 RID: 29316
		private ExpeditionMemberInfo tempRoleInfo;

		// Token: 0x04007285 RID: 29317
		[SerializeField]
		private Text mTitleText;

		// Token: 0x04007286 RID: 29318
		[SerializeField]
		private Text mLevelext;

		// Token: 0x04007287 RID: 29319
		[SerializeField]
		private Text mOccuText;

		// Token: 0x04007288 RID: 29320
		[SerializeField]
		private Text mRoleNameText;

		// Token: 0x04007289 RID: 29321
		[SerializeField]
		private Button mRoleSelectButton;

		// Token: 0x0400728A RID: 29322
		[SerializeField]
		private GeAvatarRendererEx mModelAvater;

		// Token: 0x0400728B RID: 29323
		[SerializeField]
		private GameObject mModelRoot;

		// Token: 0x0400728C RID: 29324
		[SerializeField]
		private GameObject mAddRoleImage;

		// Token: 0x0400728D RID: 29325
		[SerializeField]
		private int ModelLayer = 17;
	}
}
