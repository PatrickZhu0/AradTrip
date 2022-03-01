using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014D4 RID: 5332
	public class ChallengeTeamDuplicationView : MonoBehaviour
	{
		// Token: 0x0600CEBF RID: 52927 RVA: 0x0032FF57 File Offset: 0x0032E357
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CEC0 RID: 52928 RVA: 0x0032FF5F File Offset: 0x0032E35F
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CEC1 RID: 52929 RVA: 0x0032FF70 File Offset: 0x0032E370
		private void BindUiEvents()
		{
			if (this.teamDuplicationToggleWithNormalLevel != null)
			{
				this.teamDuplicationToggleWithNormalLevel.onValueChanged.RemoveAllListeners();
				this.teamDuplicationToggleWithNormalLevel.onValueChanged.AddListener(new UnityAction<bool>(this.OnTeamDuplicationToggleWithNormalLevelClick));
			}
			if (this.teamDuplicationToggleWith65Level != null)
			{
				this.teamDuplicationToggleWith65Level.onValueChanged.RemoveAllListeners();
				this.teamDuplicationToggleWith65Level.onValueChanged.AddListener(new UnityAction<bool>(this.OnTeamDuplicationToggleWith65LevelClick));
			}
			if (this.forwardButton != null)
			{
				this.forwardButton.ResetListener();
				this.forwardButton.SetButtonListener(new Action(this.OnForwardButtonClick));
			}
			if (this.dropItemList != null)
			{
				this.dropItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.dropItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x0600CEC2 RID: 52930 RVA: 0x00330070 File Offset: 0x0032E470
		private void UnBindUiEvents()
		{
			if (this.teamDuplicationToggleWithNormalLevel != null)
			{
				this.teamDuplicationToggleWithNormalLevel.onValueChanged.RemoveAllListeners();
			}
			if (this.teamDuplicationToggleWith65Level != null)
			{
				this.teamDuplicationToggleWith65Level.onValueChanged.RemoveAllListeners();
			}
			if (this.forwardButton != null)
			{
				this.forwardButton.ResetButtonListener();
			}
			if (this.dropItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.dropItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x0600CEC3 RID: 52931 RVA: 0x00330113 File Offset: 0x0032E513
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600CEC4 RID: 52932 RVA: 0x0033011B File Offset: 0x0032E51B
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600CEC5 RID: 52933 RVA: 0x00330123 File Offset: 0x0032E523
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewFuncUnlock, new ClientEventSystem.UIEventHandler(this.OnReceiveNewFuncUnLockMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateUnlockFunc, new ClientEventSystem.UIEventHandler(this.OnUpdateUnlockFuncMessage));
		}

		// Token: 0x0600CEC6 RID: 52934 RVA: 0x0033015B File Offset: 0x0032E55B
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewFuncUnlock, new ClientEventSystem.UIEventHandler(this.OnReceiveNewFuncUnLockMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateUnlockFunc, new ClientEventSystem.UIEventHandler(this.OnUpdateUnlockFuncMessage));
		}

		// Token: 0x0600CEC7 RID: 52935 RVA: 0x00330193 File Offset: 0x0032E593
		private void ClearData()
		{
			this._dropItemIdList = null;
			this._dungeonModelTable = null;
			this._dungeonModelTableWith65Level = null;
			this._dungeonModelTableWithNormalLevel = null;
			this._isTeamDuplicationWithNormalLevel = true;
		}

		// Token: 0x0600CEC8 RID: 52936 RVA: 0x003301B8 File Offset: 0x0032E5B8
		public void InitView(int teamDuplicationType = 1)
		{
			this._isTeamDuplicationWithNormalLevel = (teamDuplicationType <= 1);
			this.UpdateTeamDuplicationView();
			this.SetTeamDuplicationToggle();
		}

		// Token: 0x0600CEC9 RID: 52937 RVA: 0x003301D4 File Offset: 0x0032E5D4
		private void UpdateTeamDuplicationView()
		{
			this.UpdateTeamDuplicationToggleSelectedEffect();
			int costItemId = DataManager<TeamDuplicationDataManager>.GetInstance().GetCostItemIdWith65Level();
			int costItemNumber = DataManager<TeamDuplicationDataManager>.GetInstance().GetCostItemNumberWith65Level();
			if (this._isTeamDuplicationWithNormalLevel)
			{
				if (this._dungeonModelTableWithNormalLevel == null)
				{
					this._dungeonModelTableWithNormalLevel = ChallengeUtility.GetDungeonModelTableOfTeamDuplication(true);
				}
				this._dungeonModelTable = this._dungeonModelTableWithNormalLevel;
				costItemId = DataManager<TeamDuplicationDataManager>.GetInstance().GetCostItemIdWithNormalLevel();
				costItemNumber = DataManager<TeamDuplicationDataManager>.GetInstance().GetCostItemNumberWithNormalLevel();
			}
			else
			{
				if (this._dungeonModelTableWith65Level == null)
				{
					this._dungeonModelTableWith65Level = ChallengeUtility.GetDungeonModelTableOfTeamDuplication(false);
				}
				this._dungeonModelTable = this._dungeonModelTableWith65Level;
			}
			if (this._dungeonModelTable == null)
			{
				return;
			}
			this._dropItemIdList = this._dungeonModelTable.DropShow.ToList<int>();
			if (this.dropItemList != null && this._dropItemIdList != null)
			{
				this.dropItemList.SetElementAmount(this._dropItemIdList.Count);
			}
			int level = this._dungeonModelTable.Level;
			if (this._isTeamDuplicationWithNormalLevel)
			{
				CommonUtility.UpdateGameObjectVisible(this.tipRootWithNormalLevel, true);
				CommonUtility.UpdateGameObjectVisible(this.tipRootWith65Level, false);
				if (this.tipLabelWithNormalLevel != null)
				{
					this.tipLabelWithNormalLevel.text = TR.Value("team_duplication_unlock_level_format", level);
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.tipRootWithNormalLevel, false);
				CommonUtility.UpdateGameObjectVisible(this.tipRootWith65Level, true);
				if (this.tipLabelWith65Level != null)
				{
					this.tipLabelWith65Level.text = TR.Value("team_duplication_unlock_level_format_param_two", level);
				}
			}
			this.UpdateTeamDuplicationCostItem(costItemId, costItemNumber);
			this.UpdateForwardButtonStatus();
			this.UpdateShopButtonControl();
		}

		// Token: 0x0600CECA RID: 52938 RVA: 0x00330378 File Offset: 0x0032E778
		private void SetTeamDuplicationToggle()
		{
			if (this._isTeamDuplicationWithNormalLevel)
			{
				if (this.teamDuplicationToggleWithNormalLevel != null)
				{
					this.teamDuplicationToggleWithNormalLevel.isOn = false;
					this.teamDuplicationToggleWithNormalLevel.isOn = true;
				}
			}
			else if (this.teamDuplicationToggleWith65Level != null)
			{
				this.teamDuplicationToggleWith65Level.isOn = false;
				this.teamDuplicationToggleWith65Level.isOn = true;
			}
		}

		// Token: 0x0600CECB RID: 52939 RVA: 0x003303E7 File Offset: 0x0032E7E7
		public void OnEnableView()
		{
			this.UpdateForwardButtonStatus();
		}

		// Token: 0x0600CECC RID: 52940 RVA: 0x003303F0 File Offset: 0x0032E7F0
		private void OnReceiveNewFuncUnLockMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			FunctionUnLock.eFuncType eFuncType = (FunctionUnLock.eFuncType)uiEvent.Param2;
			if (eFuncType != FunctionUnLock.eFuncType.TeamCopy && eFuncType != FunctionUnLock.eFuncType.TeamCopyTwo)
			{
				return;
			}
			this.UpdateForwardButtonStatus();
		}

		// Token: 0x0600CECD RID: 52941 RVA: 0x0033043D File Offset: 0x0032E83D
		private void OnUpdateUnlockFuncMessage(UIEvent uiEvent)
		{
			this.UpdateForwardButtonStatus();
		}

		// Token: 0x0600CECE RID: 52942 RVA: 0x00330448 File Offset: 0x0032E848
		private void UpdateForwardButtonStatus()
		{
			bool flag = TeamDuplicationUtility.IsShowTeamDuplicationWithNormalLevel();
			if (!this._isTeamDuplicationWithNormalLevel)
			{
				flag = TeamDuplicationUtility.IsShowTeamDuplicationWith65Level();
			}
			this.forwardButton.UpdateButtonState(flag);
			CommonUtility.UpdateGameObjectUiGray(this.forwardButtonUiGray, !flag);
		}

		// Token: 0x0600CECF RID: 52943 RVA: 0x00330488 File Offset: 0x0032E888
		private void UpdateTeamDuplicationCostItem(int costItemId, int costItemNumber)
		{
			if (this.costItemNumberLabel != null)
			{
				this.costItemNumberLabel.text = costItemNumber.ToString();
			}
			if (this.costItemImage != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(costItemId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.costItemImage, tableItem.Icon, true);
				}
			}
		}

		// Token: 0x0600CED0 RID: 52944 RVA: 0x00330500 File Offset: 0x0032E900
		private void UpdateTeamDuplicationToggleSelectedEffect()
		{
			if (this._isTeamDuplicationWithNormalLevel)
			{
				if (this._effectPrefabWithNormalLevel == null)
				{
					this._effectPrefabWithNormalLevel = CommonUtility.LoadGameObject(this.effectRootWithNormalLevel);
				}
			}
			else if (this._effectPrefabWith65Level == null)
			{
				this._effectPrefabWith65Level = CommonUtility.LoadGameObject(this.effectRootWith65Level);
			}
		}

		// Token: 0x0600CED1 RID: 52945 RVA: 0x00330561 File Offset: 0x0032E961
		private void OnTeamDuplicationToggleWithNormalLevelClick(bool value)
		{
			if (!value)
			{
				return;
			}
			if (this._isTeamDuplicationWithNormalLevel)
			{
				return;
			}
			this._isTeamDuplicationWithNormalLevel = true;
			this.UpdateTeamDuplicationView();
		}

		// Token: 0x0600CED2 RID: 52946 RVA: 0x00330583 File Offset: 0x0032E983
		private void OnTeamDuplicationToggleWith65LevelClick(bool value)
		{
			if (!value)
			{
				return;
			}
			if (!this._isTeamDuplicationWithNormalLevel)
			{
				return;
			}
			this._isTeamDuplicationWithNormalLevel = false;
			this.UpdateTeamDuplicationView();
		}

		// Token: 0x0600CED3 RID: 52947 RVA: 0x003305A8 File Offset: 0x0032E9A8
		private void UpdateShopButtonControl()
		{
			if (this.shopButtonControl == null)
			{
				return;
			}
			int shopId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationShopIdWith65Level;
			if (this._isTeamDuplicationWithNormalLevel)
			{
				shopId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationShopIdWithNormalLevel;
			}
			this.shopButtonControl.SetShopId(shopId);
		}

		// Token: 0x0600CED4 RID: 52948 RVA: 0x003305F4 File Offset: 0x0032E9F4
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.dropItemList == null)
			{
				return;
			}
			if (this._dropItemIdList == null || this._dropItemIdList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._dropItemIdList.Count)
			{
				return;
			}
			int num = this._dropItemIdList[item.m_index];
			ChallengeChapterDropItem component = item.GetComponent<ChallengeChapterDropItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, 0);
			}
		}

		// Token: 0x0600CED5 RID: 52949 RVA: 0x00330694 File Offset: 0x0032EA94
		private void OnForwardButtonClick()
		{
			TeamDuplicationUtility.EnterToTeamDuplicationSceneFromTown(this._isTeamDuplicationWithNormalLevel);
		}

		// Token: 0x040078C9 RID: 30921
		private bool _isTeamDuplicationWithNormalLevel = true;

		// Token: 0x040078CA RID: 30922
		private List<int> _dropItemIdList;

		// Token: 0x040078CB RID: 30923
		private DungeonModelTable _dungeonModelTableWithNormalLevel;

		// Token: 0x040078CC RID: 30924
		private DungeonModelTable _dungeonModelTableWith65Level;

		// Token: 0x040078CD RID: 30925
		private DungeonModelTable _dungeonModelTable;

		// Token: 0x040078CE RID: 30926
		private GameObject _effectPrefabWithNormalLevel;

		// Token: 0x040078CF RID: 30927
		private GameObject _effectPrefabWith65Level;

		// Token: 0x040078D0 RID: 30928
		[Space(25f)]
		[Header("Toggle")]
		[SerializeField]
		private Toggle teamDuplicationToggleWithNormalLevel;

		// Token: 0x040078D1 RID: 30929
		[SerializeField]
		private Toggle teamDuplicationToggleWith65Level;

		// Token: 0x040078D2 RID: 30930
		[SerializeField]
		private GameObject effectRootWithNormalLevel;

		// Token: 0x040078D3 RID: 30931
		[SerializeField]
		private GameObject effectRootWith65Level;

		// Token: 0x040078D4 RID: 30932
		[Space(25f)]
		[Header("TipRoot")]
		[SerializeField]
		private GameObject tipRootWithNormalLevel;

		// Token: 0x040078D5 RID: 30933
		[SerializeField]
		private GameObject tipRootWith65Level;

		// Token: 0x040078D6 RID: 30934
		[Space(25f)]
		[Header("Level")]
		[SerializeField]
		private Text tipLabelWithNormalLevel;

		// Token: 0x040078D7 RID: 30935
		[SerializeField]
		private Text tipLabelWith65Level;

		// Token: 0x040078D8 RID: 30936
		[Space(25f)]
		[Header("Cost")]
		[SerializeField]
		private Image costItemImage;

		// Token: 0x040078D9 RID: 30937
		[SerializeField]
		private Text costItemNumberLabel;

		// Token: 0x040078DA RID: 30938
		[Space(25f)]
		[Header("DropItem")]
		[SerializeField]
		private ComUIListScriptEx dropItemList;

		// Token: 0x040078DB RID: 30939
		[Space(25f)]
		[Header("forwardButton")]
		[SerializeField]
		private ComButtonWithCd forwardButton;

		// Token: 0x040078DC RID: 30940
		[SerializeField]
		private UIGray forwardButtonUiGray;

		// Token: 0x040078DD RID: 30941
		[Space(25f)]
		[Header("forwardButton")]
		[Space(10f)]
		[SerializeField]
		private CommonShopButtonControl shopButtonControl;
	}
}
