using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200140F RID: 5135
	public class AdventureTeamExpeditionCharacterSelectView : MonoBehaviour
	{
		// Token: 0x0600C6EE RID: 50926 RVA: 0x00300FDD File Offset: 0x002FF3DD
		private void Awake()
		{
			this._BindUIEvents();
			this._InitTR();
			this._InitRolesScrollListBind();
		}

		// Token: 0x0600C6EF RID: 50927 RVA: 0x00300FF1 File Offset: 0x002FF3F1
		private void OnDestroy()
		{
			this._UnBindUIEvents();
		}

		// Token: 0x0600C6F0 RID: 50928 RVA: 0x00300FF9 File Offset: 0x002FF3F9
		private void _bindEvents()
		{
		}

		// Token: 0x0600C6F1 RID: 50929 RVA: 0x00300FFB File Offset: 0x002FF3FB
		private void _unBindEvente()
		{
		}

		// Token: 0x0600C6F2 RID: 50930 RVA: 0x00301000 File Offset: 0x002FF400
		private void _BindUIEvents()
		{
			if (this.mCloseButton != null)
			{
				this.mCloseButton.onClick.AddListener(new UnityAction(this._OnCloseButtonClickCallBack));
			}
			if (this.mBackGroundBtn != null)
			{
				this.mBackGroundBtn.onClick.AddListener(new UnityAction(this._OnCloseButtonClickCallBack));
			}
		}

		// Token: 0x0600C6F3 RID: 50931 RVA: 0x00301068 File Offset: 0x002FF468
		private void _UnBindUIEvents()
		{
			if (this.mCloseButton != null)
			{
				this.mCloseButton.onClick.RemoveListener(new UnityAction(this._OnCloseButtonClickCallBack));
			}
			if (this.mBackGroundBtn != null)
			{
				this.mBackGroundBtn.onClick.RemoveListener(new UnityAction(this._OnCloseButtonClickCallBack));
			}
		}

		// Token: 0x0600C6F4 RID: 50932 RVA: 0x003010CF File Offset: 0x002FF4CF
		private void _InitTR()
		{
			this.rolesList = new List<ExpeditionMemberInfo>[4];
			this.tr_title_adventure_team_expedition_select_name = TR.Value("adventure_team_expedition_select_name");
		}

		// Token: 0x0600C6F5 RID: 50933 RVA: 0x003010ED File Offset: 0x002FF4ED
		private void _ClearView()
		{
			this.tr_title_adventure_team_expedition_select_name = string.Empty;
			this.rolesList = null;
			this.rolesNum = 0;
		}

		// Token: 0x0600C6F6 RID: 50934 RVA: 0x00301108 File Offset: 0x002FF508
		private void _InitBaseData()
		{
			if (this.mTitleLabel != null)
			{
				this.mTitleLabel.text = this.tr_title_adventure_team_expedition_select_name;
			}
			this._UpdateBaseDate();
			for (int i = 0; i < this.rolesList.Length; i++)
			{
				this.rolesNum += this.rolesList[i].Count;
			}
			this.mRolesRoot.SetElementAmount(this.rolesNum);
		}

		// Token: 0x0600C6F7 RID: 50935 RVA: 0x00301181 File Offset: 0x002FF581
		private void _CloseFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdventureTeamExpeditionCharacterSelectFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdventureTeamExpeditionCharacterSelectFrame>(null, false);
			}
		}

		// Token: 0x0600C6F8 RID: 50936 RVA: 0x003011A0 File Offset: 0x002FF5A0
		private void _InitRolesScrollListBind()
		{
			this.mRolesRoot.Initialize();
			this.mRolesRoot.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateRolesScrollListBind(item);
				}
			};
			this.mRolesRoot.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (item == null)
				{
					return;
				}
				AdventureTeamExpeditionCharacterSelectUnit component = item.GetComponent<AdventureTeamExpeditionCharacterSelectUnit>();
				if (component != null)
				{
					component.OnItemRecycle();
				}
			};
		}

		// Token: 0x0600C6F9 RID: 50937 RVA: 0x003011F8 File Offset: 0x002FF5F8
		private void _UpdateRolesScrollListBind(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionCharacterSelectUnit component = item.GetComponent<AdventureTeamExpeditionCharacterSelectUnit>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.rolesNum)
			{
				return;
			}
			ExpeditionRoleState expeditionRoleState;
			ExpeditionMemberInfo roleInfoByIndex = this.GetRoleInfoByIndex(item.m_index, out expeditionRoleState);
			if (DataManager<AdventureTeamDataManager>.GetInstance().IsRolesInExpeditionList(roleInfoByIndex))
			{
				expeditionRoleState = ExpeditionRoleState.SELECT;
			}
			else if (expeditionRoleState == ExpeditionRoleState.SELECT)
			{
				expeditionRoleState = ExpeditionRoleState.PREPARE;
			}
			component.InitItemView(roleInfoByIndex, expeditionRoleState);
			component.UpdateItemInfo();
		}

		// Token: 0x0600C6FA RID: 50938 RVA: 0x00301284 File Offset: 0x002FF684
		private ExpeditionMemberInfo GetRoleInfoByIndex(int index, out ExpeditionRoleState state)
		{
			if (index < this.rolesList[0].Count)
			{
				state = ExpeditionRoleState.SELECT;
				return this.rolesList[0][index];
			}
			if (index < this.rolesList[0].Count + this.rolesList[1].Count)
			{
				state = ExpeditionRoleState.PREPARE;
				return this.rolesList[1][index - this.rolesList[0].Count];
			}
			if (index < this.rolesList[0].Count + this.rolesList[1].Count + this.rolesList[2].Count)
			{
				state = ExpeditionRoleState.LEVEL_LIMIT;
				return this.rolesList[2][index - this.rolesList[0].Count - this.rolesList[1].Count];
			}
			state = ExpeditionRoleState.EXPEDITION;
			return this.rolesList[3][index - this.rolesList[0].Count - this.rolesList[1].Count - this.rolesList[2].Count];
		}

		// Token: 0x0600C6FB RID: 50939 RVA: 0x00301390 File Offset: 0x002FF790
		private void _UpdateBaseDate()
		{
			this.rolesList[0] = new List<ExpeditionMemberInfo>();
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo != null && DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.roles != null)
			{
				for (int i = 0; i < DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.roles.Count; i++)
				{
					this.rolesList[0].Add(DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.roles[i]);
				}
			}
			List<ExpeditionMemberInfo>[] expeditionRolesList = DataManager<AdventureTeamDataManager>.GetInstance().GetExpeditionRolesList();
			if (expeditionRolesList != null)
			{
				for (int j = 1; j < this.rolesList.Length; j++)
				{
					this.rolesList[j] = expeditionRolesList[j - 1];
				}
			}
		}

		// Token: 0x0600C6FC RID: 50940 RVA: 0x0030144B File Offset: 0x002FF84B
		private void _OnCloseButtonClickCallBack()
		{
			this._CloseFrame();
		}

		// Token: 0x0600C6FD RID: 50941 RVA: 0x00301453 File Offset: 0x002FF853
		public void InitData()
		{
			this._InitBaseData();
		}

		// Token: 0x0600C6FE RID: 50942 RVA: 0x0030145B File Offset: 0x002FF85B
		public void Clear()
		{
			this._ClearView();
		}

		// Token: 0x0400722F RID: 29231
		private string tr_title_adventure_team_expedition_select_name = string.Empty;

		// Token: 0x04007230 RID: 29232
		private List<ExpeditionMemberInfo>[] rolesList = new List<ExpeditionMemberInfo>[4];

		// Token: 0x04007231 RID: 29233
		private int rolesNum;

		// Token: 0x04007232 RID: 29234
		[SerializeField]
		private Text mTitleLabel;

		// Token: 0x04007233 RID: 29235
		[SerializeField]
		private Button mCloseButton;

		// Token: 0x04007234 RID: 29236
		[SerializeField]
		private ComUIListScript mRolesRoot;

		// Token: 0x04007235 RID: 29237
		[SerializeField]
		private Button mBackGroundBtn;
	}
}
