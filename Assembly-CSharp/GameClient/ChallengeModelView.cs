using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014D8 RID: 5336
	public class ChallengeModelView : MonoBehaviour
	{
		// Token: 0x0600CEED RID: 52973 RVA: 0x00330A51 File Offset: 0x0032EE51
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CEEE RID: 52974 RVA: 0x00330A59 File Offset: 0x0032EE59
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CEEF RID: 52975 RVA: 0x00330A68 File Offset: 0x0032EE68
		private void BindEvents()
		{
			if (this.deepButton != null)
			{
				this.deepButton.onClick.RemoveAllListeners();
				this.deepButton.onClick.AddListener(new UnityAction(this.OnDeepButtonClick));
			}
			if (this.ancientButton != null)
			{
				this.ancientButton.onClick.RemoveAllListeners();
				this.ancientButton.onClick.AddListener(new UnityAction(this.OnAncientButtonClick));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.teamButton != null)
			{
				this.teamButton.onClick.RemoveAllListeners();
				this.teamButton.onClick.AddListener(new UnityAction(this.OnTeamButtonClick));
			}
			if (this.teamChatList != null)
			{
				this.teamChatList.Initialize();
				ComUIListScript comUIListScript = this.teamChatList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTeamChatVisible));
				ComUIListScript comUIListScript2 = this.teamChatList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTeamChatRecycle));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnChallengeTeamChatDataUpdate, new ClientEventSystem.UIEventHandler(this.OnChallengeTeamChatDataUpdate));
		}

		// Token: 0x0600CEF0 RID: 52976 RVA: 0x00330BF0 File Offset: 0x0032EFF0
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.deepButton != null)
			{
				this.deepButton.onClick.RemoveAllListeners();
			}
			if (this.ancientButton != null)
			{
				this.ancientButton.onClick.RemoveAllListeners();
			}
			if (this.teamButton != null)
			{
				this.teamButton.onClick.RemoveAllListeners();
			}
			if (this.teamChatList != null)
			{
				ComUIListScript comUIListScript = this.teamChatList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTeamChatVisible));
				ComUIListScript comUIListScript2 = this.teamChatList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTeamChatRecycle));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnChallengeTeamChatDataUpdate, new ClientEventSystem.UIEventHandler(this.OnChallengeTeamChatDataUpdate));
		}

		// Token: 0x0600CEF1 RID: 52977 RVA: 0x00330CFB File Offset: 0x0032F0FB
		private void ClearData()
		{
			if (this._chatBlockList != null)
			{
				this._chatBlockList.Clear();
				this._chatBlockList = null;
			}
		}

		// Token: 0x0600CEF2 RID: 52978 RVA: 0x00330D1A File Offset: 0x0032F11A
		public void InitView()
		{
			this.InitDeepModel();
			this.InitAncientModel();
			this.InitOtherModel();
			this.InitChallengeTeamContent();
		}

		// Token: 0x0600CEF3 RID: 52979 RVA: 0x00330D34 File Offset: 0x0032F134
		private void InitDeepModel()
		{
			if (this.deepModelDropControl == null)
			{
				return;
			}
			DungeonModelTable challengeDungeonModelTableByModelType = ChallengeUtility.GetChallengeDungeonModelTableByModelType(DungeonModelTable.eType.DeepModel);
			this.deepModelDropControl.InitModelControl(challengeDungeonModelTableByModelType);
		}

		// Token: 0x0600CEF4 RID: 52980 RVA: 0x00330D68 File Offset: 0x0032F168
		private void InitAncientModel()
		{
			if (this.ancientModelDropControl == null)
			{
				return;
			}
			DungeonModelTable challengeDungeonModelTableByModelType = ChallengeUtility.GetChallengeDungeonModelTableByModelType(DungeonModelTable.eType.AncientModel);
			this.deepModelDropControl.InitModelControl(challengeDungeonModelTableByModelType);
		}

		// Token: 0x0600CEF5 RID: 52981 RVA: 0x00330D9A File Offset: 0x0032F19A
		private void InitOtherModel()
		{
		}

		// Token: 0x0600CEF6 RID: 52982 RVA: 0x00330D9C File Offset: 0x0032F19C
		private void InitChallengeTeamContent()
		{
			if (this.teamTips != null)
			{
				this.teamTips.text = TR.Value("challenge_team_model_tips");
			}
			this.UpdateChallengeTeamChatList();
		}

		// Token: 0x0600CEF7 RID: 52983 RVA: 0x00330DCA File Offset: 0x0032F1CA
		private void OnDeepButtonClick()
		{
		}

		// Token: 0x0600CEF8 RID: 52984 RVA: 0x00330DCC File Offset: 0x0032F1CC
		private void OnAncientButtonClick()
		{
		}

		// Token: 0x0600CEF9 RID: 52985 RVA: 0x00330DCE File Offset: 0x0032F1CE
		private void OnCloseFrame()
		{
			ChallengeUtility.OnCloseChallengeModelFrame();
		}

		// Token: 0x0600CEFA RID: 52986 RVA: 0x00330DD5 File Offset: 0x0032F1D5
		private void OnTeamButtonClick()
		{
			Logger.LogErrorFormat("OnTeamButtonClick", new object[0]);
			ChallengeUtility.OnOpenTeamListFrame();
		}

		// Token: 0x0600CEFB RID: 52987 RVA: 0x00330DEC File Offset: 0x0032F1EC
		private void UpdateChallengeTeamChatList()
		{
			this.SetChatBlockList();
			this._chatBlockList.Clear();
			for (int i = 0; i < DataManager<ChatManager>.GetInstance().GlobalChatBlock.Count; i++)
			{
				ChatBlock chatBlock = DataManager<ChatManager>.GetInstance().GlobalChatBlock[i];
				if (chatBlock != null && chatBlock.chatData != null && chatBlock.chatData.eChatType == ChatType.CT_ACOMMPANY)
				{
					this._chatBlockList.Add(chatBlock);
				}
			}
			this.SetTeamChatListAmount();
		}

		// Token: 0x0600CEFC RID: 52988 RVA: 0x00330E6F File Offset: 0x0032F26F
		private void SetChatBlockList()
		{
			if (this._chatBlockList == null)
			{
				this._chatBlockList = new List<ChatBlock>();
			}
		}

		// Token: 0x0600CEFD RID: 52989 RVA: 0x00330E88 File Offset: 0x0032F288
		private void SetTeamChatListAmount()
		{
			int elementAmount = 0;
			if (this._chatBlockList != null)
			{
				elementAmount = this._chatBlockList.Count;
			}
			if (this.teamChatList != null)
			{
				this.teamChatList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600CEFE RID: 52990 RVA: 0x00330ECB File Offset: 0x0032F2CB
		private void OnChallengeTeamChatDataUpdate(UIEvent uiEvent)
		{
			this.UpdateChallengeTeamChatList();
		}

		// Token: 0x0600CEFF RID: 52991 RVA: 0x00330ED4 File Offset: 0x0032F2D4
		private void OnTeamChatVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._chatBlockList == null)
			{
				return;
			}
			if (this.teamChatList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._chatBlockList.Count)
			{
				return;
			}
			ChatBlock chatBlock = this._chatBlockList[item.m_index];
			ChallengeModelTeamChatItem component = item.GetComponent<ChallengeModelTeamChatItem>();
			if (component != null && chatBlock != null)
			{
				component.InitItem(chatBlock);
			}
		}

		// Token: 0x0600CF00 RID: 52992 RVA: 0x00330F61 File Offset: 0x0032F361
		private void OnTeamChatRecycle(ComUIListElementScript item)
		{
		}

		// Token: 0x040078E4 RID: 30948
		private List<ChatBlock> _chatBlockList;

		// Token: 0x040078E5 RID: 30949
		[Space(20f)]
		[Header("Deep")]
		[Space(10f)]
		[SerializeField]
		private Button deepButton;

		// Token: 0x040078E6 RID: 30950
		[SerializeField]
		private ChallengeModelDropControl deepModelDropControl;

		// Token: 0x040078E7 RID: 30951
		[Space(20f)]
		[Header("Ancient")]
		[Space(10f)]
		[SerializeField]
		private Button ancientButton;

		// Token: 0x040078E8 RID: 30952
		[SerializeField]
		private ChallengeModelDropControl ancientModelDropControl;

		// Token: 0x040078E9 RID: 30953
		[Space(20f)]
		[Header("TeamRoot")]
		[Space(10f)]
		[SerializeField]
		private Button teamButton;

		// Token: 0x040078EA RID: 30954
		[SerializeField]
		private Text teamTips;

		// Token: 0x040078EB RID: 30955
		[SerializeField]
		private ComUIListScript teamChatList;

		// Token: 0x040078EC RID: 30956
		[Space(10f)]
		[Header("Close")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}
