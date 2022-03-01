using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001421 RID: 5153
	public class AdventureTeamContentLevelIncomeControl : MonoBehaviour
	{
		// Token: 0x0600C7A5 RID: 51109 RVA: 0x00304C0A File Offset: 0x0030300A
		private void Awake()
		{
			this.BindEvents();
			this._InitTR();
		}

		// Token: 0x0600C7A6 RID: 51110 RVA: 0x00304C18 File Offset: 0x00303018
		private void OnDestroy()
		{
			this.UnBindEvents();
			this._ClearView();
		}

		// Token: 0x0600C7A7 RID: 51111 RVA: 0x00304C28 File Offset: 0x00303028
		private void BindEvents()
		{
			if (this.minusButton != null)
			{
				this.minusButton.onClick.AddListener(new UnityAction(this.OnMinusButtonClickedCallBack));
			}
			if (this.addButton != null)
			{
				this.addButton.onClick.AddListener(new UnityAction(this.OnAddButtonClickedCallBack));
			}
			if (this.openBlessShopBtn)
			{
				this.openBlessShopBtn.onClick.AddListener(new UnityAction(this.OnOpenBlessShopBtnClick));
			}
			if (this.openBountyShopBtn)
			{
				this.openBountyShopBtn.onClick.AddListener(new UnityAction(this.OnOpenBountyShopBtnClick));
			}
			if (this.mAdventureTeamChangeNameBtn)
			{
				this.mAdventureTeamChangeNameBtn.onClick.AddListener(new UnityAction(this._OnChangeNameBtnClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamBlessCrystalCountChanged, new ClientEventSystem.UIEventHandler(this._OnBlessCrystalCountChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamBlessCrystalExpChanged, new ClientEventSystem.UIEventHandler(this._OnBlessCrystalExpChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamBountyCountChanged, new ClientEventSystem.UIEventHandler(this._OnBountyCountChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamBaseInfoRes, new ClientEventSystem.UIEventHandler(this._OnBaseInfoRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamBlessCrystalInfoRes, new ClientEventSystem.UIEventHandler(this._OnBlessCrystalInfoRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamRenameSucc, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamRenameSucc));
		}

		// Token: 0x0600C7A8 RID: 51112 RVA: 0x00304DB8 File Offset: 0x003031B8
		private void UnBindEvents()
		{
			if (this.minusButton != null)
			{
				this.minusButton.onClick.RemoveListener(new UnityAction(this.OnMinusButtonClickedCallBack));
			}
			if (this.addButton != null)
			{
				this.addButton.onClick.RemoveListener(new UnityAction(this.OnAddButtonClickedCallBack));
			}
			if (this.openBlessShopBtn)
			{
				this.openBlessShopBtn.onClick.RemoveListener(new UnityAction(this.OnOpenBlessShopBtnClick));
			}
			if (this.openBountyShopBtn)
			{
				this.openBountyShopBtn.onClick.RemoveListener(new UnityAction(this.OnOpenBountyShopBtnClick));
			}
			if (this.mAdventureTeamChangeNameBtn)
			{
				this.mAdventureTeamChangeNameBtn.onClick.RemoveListener(new UnityAction(this._OnChangeNameBtnClick));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamBlessCrystalCountChanged, new ClientEventSystem.UIEventHandler(this._OnBlessCrystalCountChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamBlessCrystalExpChanged, new ClientEventSystem.UIEventHandler(this._OnBlessCrystalExpChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamBountyCountChanged, new ClientEventSystem.UIEventHandler(this._OnBountyCountChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamBaseInfoRes, new ClientEventSystem.UIEventHandler(this._OnBaseInfoRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamBlessCrystalInfoRes, new ClientEventSystem.UIEventHandler(this._OnBlessCrystalInfoRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamRenameSucc, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamRenameSucc));
		}

		// Token: 0x0600C7A9 RID: 51113 RVA: 0x00304F48 File Offset: 0x00303348
		private void _InitTR()
		{
			this.tr_adventure_team_name_format = TR.Value("adventure_team_role_select_nameinfo");
			this.tr_adventure_team_grade_color = TR.Value("adventure_team_grade_color");
			this.tr_adventure_team_not_in_rank = TR.Value("adventure_team_not_in_rank");
			this.tr_adventure_team_role_field_count_format = TR.Value("adventure_team_role_field_count");
			this.tr_bless_crystal_count_format = TR.Value("adventure_team_bless_crystal_count");
			this.tr_bless_crystal_introduction = TR.Value("adventure_team_bless_crystal_introducation");
			this.tr_bounty_count_format = TR.Value("adventure_team_bounty_count");
			this.tr_bounty_introduction = TR.Value("adventure_team_bounty_introduction");
			this.tr_adventure_team_grade_with_score = TR.Value("adventure_team_grade_with_score");
		}

		// Token: 0x0600C7AA RID: 51114 RVA: 0x00304FE8 File Offset: 0x003033E8
		private void _ClearView()
		{
			this.tr_adventure_team_name_format = string.Empty;
			this.tr_adventure_team_grade_color = string.Empty;
			this.tr_adventure_team_not_in_rank = string.Empty;
			this.tr_adventure_team_role_field_count_format = string.Empty;
			this.tr_bless_crystal_count_format = string.Empty;
			this.tr_bless_crystal_introduction = string.Empty;
			this.tr_bounty_count_format = string.Empty;
			this.tr_bounty_introduction = string.Empty;
			this.tr_adventure_team_grade_with_score = string.Empty;
			if (this._blessCrystalComItem != null)
			{
				ComItemManager.Destroy(this._blessCrystalComItem);
				this._blessCrystalComItem = null;
			}
			if (this._bountyComItem != null)
			{
				ComItemManager.Destroy(this._bountyComItem);
				this._bountyComItem = null;
			}
		}

		// Token: 0x0600C7AB RID: 51115 RVA: 0x003050A0 File Offset: 0x003034A0
		private void _InitAdventureTeamBaseInfo()
		{
			if (this.mAdventureTeamName)
			{
				this.tr_adventure_team_name_format = this.tr_adventure_team_name_format.Replace("\n", string.Empty);
				this.mAdventureTeamName.text = string.Format(this.tr_adventure_team_name_format, DataManager<AdventureTeamDataManager>.GetInstance().GetColorAdventureTeamName());
			}
			if (this.mRoleNumFormat && ClientApplication.playerinfo != null && ClientApplication.playerinfo.roleinfo != null)
			{
				int hasOwnedRoles = RecoveryRoleCachedObject.HasOwnedRoles;
				int enabledRoleField = RecoveryRoleCachedObject.EnabledRoleField;
				this.mRoleNumFormat.text = string.Format(this.tr_adventure_team_role_field_count_format, hasOwnedRoles, enabledRoleField);
			}
			if (this.mAdventureTeamLevel)
			{
				this.mAdventureTeamLevel.SetNum(DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamLevel());
			}
			if (this.mAdventureTeamExpBar)
			{
				this.mAdventureTeamExpBar.SetExp((ulong)((long)DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamCurrExp()), true, (ulong exp) => DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamCurrExpWithUpLevelExp(exp));
			}
			if (this.mAdventureTeamGrade)
			{
				string colorAdventureTeamGrade = DataManager<AdventureTeamDataManager>.GetInstance().GetColorAdventureTeamGrade();
				uint adventureTeamScore = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamScore();
				this.mAdventureTeamGrade.text = string.Format(this.tr_adventure_team_grade_with_score, colorAdventureTeamGrade, adventureTeamScore.ToString());
			}
			if (this.mAdentureTeamRank)
			{
				uint adventureTeamRank = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamRank();
				if (adventureTeamRank == 0U)
				{
					this.mAdentureTeamRank.text = this.tr_adventure_team_not_in_rank;
				}
				else
				{
					this.mAdentureTeamRank.text = adventureTeamRank.ToString();
				}
			}
		}

		// Token: 0x0600C7AC RID: 51116 RVA: 0x00305254 File Offset: 0x00303654
		private void _UpdateBaseInfo()
		{
			if (this.mAdventureTeamName)
			{
				this.tr_adventure_team_name_format = this.tr_adventure_team_name_format.Replace("\n", string.Empty);
				this.mAdventureTeamName.text = string.Format(this.tr_adventure_team_name_format, DataManager<AdventureTeamDataManager>.GetInstance().GetColorAdventureTeamName());
			}
		}

		// Token: 0x0600C7AD RID: 51117 RVA: 0x003052AC File Offset: 0x003036AC
		private void _InitIncomeInfo()
		{
			int adventureTeamLevel = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamLevel();
			if (adventureTeamLevel < DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMinimum || adventureTeamLevel > DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMaximum)
			{
				this._adventureTeamLevel = DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMinimum;
			}
			else
			{
				this._adventureTeamLevel = adventureTeamLevel;
			}
			if (this.dotRoot)
			{
				this.dotRoot.InitDots(DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMaximum, true);
				this.dotRoot.CustomActive(false);
			}
			this.UpdateIncomeContent();
		}

		// Token: 0x0600C7AE RID: 51118 RVA: 0x00305338 File Offset: 0x00303738
		private void UpdateIncomeContent()
		{
			this.UpdateIncomeInfo();
			this.UpdateIncomeButton();
			if (this.dotRoot)
			{
				int adventureTeamLevelMaximum = DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMaximum;
				this.dotRoot.CustomActive(adventureTeamLevelMaximum >= 2);
				this.dotRoot.SetDots(this._adventureTeamLevel, adventureTeamLevelMaximum);
			}
		}

		// Token: 0x0600C7AF RID: 51119 RVA: 0x00305390 File Offset: 0x00303790
		private void UpdateIncomeInfo()
		{
			if (this.mAdventureTeamLevelTitle)
			{
				this.mAdventureTeamLevelTitle.text = Utility.GetUnitNumWithHeadZero(this._adventureTeamLevel, false);
			}
			if (this.propertyIncomeDesc)
			{
				this.propertyIncomeDesc.text = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamIncomeDescByLevel(this._adventureTeamLevel);
			}
		}

		// Token: 0x0600C7B0 RID: 51120 RVA: 0x003053F0 File Offset: 0x003037F0
		private void UpdateIncomeButton()
		{
			if (this._adventureTeamLevel <= DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMinimum)
			{
				this.SetMinusButton(false);
				this.SetAddButton(true);
			}
			else if (this._adventureTeamLevel >= DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMaximum)
			{
				this.SetMinusButton(true);
				this.SetAddButton(false);
			}
			else
			{
				this.SetMinusButton(true);
				this.SetAddButton(true);
			}
		}

		// Token: 0x0600C7B1 RID: 51121 RVA: 0x0030545B File Offset: 0x0030385B
		private void SetMinusButton(bool flag)
		{
			if (this.minusButton != null)
			{
				this.minusButton.interactable = flag;
			}
			if (this.minusButtonGray != null)
			{
				this.minusButtonGray.enabled = !flag;
			}
		}

		// Token: 0x0600C7B2 RID: 51122 RVA: 0x0030549A File Offset: 0x0030389A
		private void SetAddButton(bool flag)
		{
			if (this.addButton != null)
			{
				this.addButton.interactable = flag;
			}
			if (this.addButtonGray != null)
			{
				this.addButtonGray.enabled = !flag;
			}
		}

		// Token: 0x0600C7B3 RID: 51123 RVA: 0x003054DC File Offset: 0x003038DC
		private void _InitBlessCrystalContent()
		{
			BlessCrystalModel blessCrystalModel = DataManager<AdventureTeamDataManager>.GetInstance().BlessCrystalModel;
			if (blessCrystalModel == null)
			{
				return;
			}
			if (this.blessCrystalNameLabel)
			{
				this.blessCrystalNameLabel.text = blessCrystalModel.itemName;
			}
			if (this.blessCrystalIcon && !string.IsNullOrEmpty(blessCrystalModel.itemIconPath))
			{
				ETCImageLoader.LoadSprite(ref this.blessCrystalIcon, blessCrystalModel.itemIconPath, true);
			}
			if (this.blessCrystalItemRoot)
			{
				ItemData item = ItemDataManager.CreateItemDataFromTable((int)blessCrystalModel.itemTableId, 100, 0);
				if (this._blessCrystalComItem == null)
				{
					this._blessCrystalComItem = ComItemManager.Create(this.blessCrystalItemRoot);
				}
				this._blessCrystalComItem.Setup(item, delegate(GameObject go, ItemData itemData)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
				});
				this._blessCrystalComItem.CustomActive(true);
			}
			if (this.blessCrystalIntroductionTitle)
			{
				this.blessCrystalIntroductionTitle.text = string.Format(this.tr_bless_crystal_introduction, blessCrystalModel.itemName);
			}
			this._UpdateBlessCrystalContent();
		}

		// Token: 0x0600C7B4 RID: 51124 RVA: 0x003055F8 File Offset: 0x003039F8
		private void _UpdateBlessCrystalContent()
		{
			BlessCrystalModel blessCrystalModel = DataManager<AdventureTeamDataManager>.GetInstance().BlessCrystalModel;
			if (blessCrystalModel == null)
			{
				return;
			}
			if (this.blessCrystalOwnCount)
			{
				this.blessCrystalOwnCount.text = string.Format(this.tr_bless_crystal_count_format, blessCrystalModel.currOwnCount.ToString(), blessCrystalModel.currNumMaximum.ToString());
			}
			if (this.blessCrystalExpBar)
			{
				this.blessCrystalExpBar.SetExp(blessCrystalModel.currOwnExp, true, (ulong exp) => DataManager<AdventureTeamDataManager>.GetInstance().GetBlessCrystalShopCurrExpWithMaxExp(exp));
			}
		}

		// Token: 0x0600C7B5 RID: 51125 RVA: 0x003056A0 File Offset: 0x00303AA0
		private void _InitBountyContent()
		{
			BountyModle bountyModel = DataManager<AdventureTeamDataManager>.GetInstance().BountyModel;
			if (bountyModel == null)
			{
				return;
			}
			if (this.bountyNameLabel)
			{
				this.bountyNameLabel.text = bountyModel.itemName;
			}
			if (this.blessCrystalIcon && !string.IsNullOrEmpty(bountyModel.itemIconPath))
			{
				ETCImageLoader.LoadSprite(ref this.blessCrystalIcon, bountyModel.itemIconPath, true);
			}
			if (this.bountyItemRoot)
			{
				ItemData item = ItemDataManager.CreateItemDataFromTable((int)bountyModel.itemTableId, 100, 0);
				if (this._bountyComItem == null)
				{
					this._bountyComItem = ComItemManager.Create(this.bountyItemRoot);
				}
				this._bountyComItem.Setup(item, delegate(GameObject go, ItemData itemData)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
				});
				this._bountyComItem.CustomActive(true);
			}
			if (this.bountyIntroductionTitle)
			{
				this.bountyIntroductionTitle.text = string.Format(this.tr_bounty_introduction, bountyModel.itemName, bountyModel.itemName);
			}
			this._UpdateBountyContent();
		}

		// Token: 0x0600C7B6 RID: 51126 RVA: 0x003057C4 File Offset: 0x00303BC4
		private void _UpdateBountyContent()
		{
			BountyModle bountyModel = DataManager<AdventureTeamDataManager>.GetInstance().BountyModel;
			if (bountyModel == null)
			{
				return;
			}
			if (this.bountyOwnCount)
			{
				this.bountyOwnCount.text = string.Format(this.tr_bounty_count_format, bountyModel.currOwnCount.ToString());
			}
		}

		// Token: 0x0600C7B7 RID: 51127 RVA: 0x0030581C File Offset: 0x00303C1C
		private void OnMinusButtonClickedCallBack()
		{
			if (this._adventureTeamLevel <= DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMinimum)
			{
				return;
			}
			this._adventureTeamLevel--;
			if (this._adventureTeamLevel < DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMinimum)
			{
				this._adventureTeamLevel = DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMinimum;
			}
			this.UpdateIncomeContent();
		}

		// Token: 0x0600C7B8 RID: 51128 RVA: 0x00305878 File Offset: 0x00303C78
		private void OnAddButtonClickedCallBack()
		{
			if (this._adventureTeamLevel >= DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMaximum)
			{
				return;
			}
			this._adventureTeamLevel++;
			if (this._adventureTeamLevel > DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMaximum)
			{
				this._adventureTeamLevel = DataManager<AdventureTeamDataManager>.GetInstance().AdventureTeamLevelMaximum;
			}
			this.UpdateIncomeContent();
		}

		// Token: 0x0600C7B9 RID: 51129 RVA: 0x003058D4 File Offset: 0x00303CD4
		private void OnOpenBlessShopBtnClick()
		{
			DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(50, 51, 0, -1);
		}

		// Token: 0x0600C7BA RID: 51130 RVA: 0x003058E6 File Offset: 0x00303CE6
		private void OnOpenBountyShopBtnClick()
		{
			DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(50, 52, 0, -1);
		}

		// Token: 0x0600C7BB RID: 51131 RVA: 0x003058F8 File Offset: 0x00303CF8
		private void _OnChangeNameBtnClick()
		{
			AdventureTeamRenameModel userData = new AdventureTeamRenameModel();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventureTeamChangeNameFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600C7BC RID: 51132 RVA: 0x0030591D File Offset: 0x00303D1D
		private void _OnBlessCrystalInfoRes(UIEvent uiEvent)
		{
			this._InitBlessCrystalContent();
		}

		// Token: 0x0600C7BD RID: 51133 RVA: 0x00305925 File Offset: 0x00303D25
		private void _OnBaseInfoRes(UIEvent uiEvent)
		{
			this._InitAdventureTeamBaseInfo();
			this._InitIncomeInfo();
			this._InitBountyContent();
		}

		// Token: 0x0600C7BE RID: 51134 RVA: 0x00305939 File Offset: 0x00303D39
		private void _OnBlessCrystalCountChanged(UIEvent uiEvent)
		{
			this._UpdateBlessCrystalContent();
		}

		// Token: 0x0600C7BF RID: 51135 RVA: 0x00305941 File Offset: 0x00303D41
		private void _OnBlessCrystalExpChanged(UIEvent uiEvent)
		{
			this._UpdateBlessCrystalContent();
		}

		// Token: 0x0600C7C0 RID: 51136 RVA: 0x00305949 File Offset: 0x00303D49
		private void _OnBountyCountChanged(UIEvent uiEvent)
		{
			this._UpdateBountyContent();
		}

		// Token: 0x0600C7C1 RID: 51137 RVA: 0x00305951 File Offset: 0x00303D51
		private void _OnAdventureTeamRenameSucc(UIEvent _uiEvent)
		{
			this._UpdateBaseInfo();
		}

		// Token: 0x0600C7C2 RID: 51138 RVA: 0x00305959 File Offset: 0x00303D59
		public void TryInitBaseInfoView()
		{
			this._InitAdventureTeamBaseInfo();
			this._InitIncomeInfo();
			this._InitBountyContent();
			this._InitBlessCrystalContent();
		}

		// Token: 0x040072A8 RID: 29352
		[Space(15f)]
		[Header("Left Content")]
		[Header("Title")]
		[SerializeField]
		private Text mAdventureTeamName;

		// Token: 0x040072A9 RID: 29353
		[SerializeField]
		private Button mAdventureTeamChangeNameBtn;

		// Token: 0x040072AA RID: 29354
		[SerializeField]
		private Text mRoleNumFormat;

		// Token: 0x040072AB RID: 29355
		[SerializeField]
		private Text mAdventureTeamGrade;

		// Token: 0x040072AC RID: 29356
		[SerializeField]
		private Text mAdentureTeamRank;

		// Token: 0x040072AD RID: 29357
		[SerializeField]
		private Button mAdventureTeamRankHelpBtn;

		// Token: 0x040072AE RID: 29358
		[SerializeField]
		private ComArtLettering mAdventureTeamLevel;

		// Token: 0x040072AF RID: 29359
		[SerializeField]
		private ComExpBar mAdventureTeamExpBar;

		// Token: 0x040072B0 RID: 29360
		[Space(5f)]
		[Header("Content")]
		[SerializeField]
		private Text mAdventureTeamLevelTitle;

		// Token: 0x040072B1 RID: 29361
		[SerializeField]
		private Text propertyIncomeDesc;

		// Token: 0x040072B2 RID: 29362
		[Space(5f)]
		[Header("Button")]
		[SerializeField]
		private Button minusButton;

		// Token: 0x040072B3 RID: 29363
		[SerializeField]
		private UIGray minusButtonGray;

		// Token: 0x040072B4 RID: 29364
		[SerializeField]
		private Button addButton;

		// Token: 0x040072B5 RID: 29365
		[SerializeField]
		private UIGray addButtonGray;

		// Token: 0x040072B6 RID: 29366
		[SerializeField]
		private ComDotController dotRoot;

		// Token: 0x040072B7 RID: 29367
		[Space(15f)]
		[Header("Right Content")]
		[Space(5f)]
		[Header("BlessShop")]
		[SerializeField]
		private Text blessCrystalNameLabel;

		// Token: 0x040072B8 RID: 29368
		[SerializeField]
		private Text blessCrystalOwnCount;

		// Token: 0x040072B9 RID: 29369
		[SerializeField]
		private Image blessCrystalIcon;

		// Token: 0x040072BA RID: 29370
		[SerializeField]
		private Text blessCrystalIntroductionTitle;

		// Token: 0x040072BB RID: 29371
		[SerializeField]
		private GameObject blessCrystalItemRoot;

		// Token: 0x040072BC RID: 29372
		[SerializeField]
		private ComExpBar blessCrystalExpBar;

		// Token: 0x040072BD RID: 29373
		[SerializeField]
		private Button openBlessShopBtn;

		// Token: 0x040072BE RID: 29374
		[Space(10f)]
		[Header("BountyShop")]
		[SerializeField]
		private Text bountyNameLabel;

		// Token: 0x040072BF RID: 29375
		[SerializeField]
		private Text bountyOwnCount;

		// Token: 0x040072C0 RID: 29376
		[SerializeField]
		private Image bountyIcon;

		// Token: 0x040072C1 RID: 29377
		[SerializeField]
		private GameObject bountyItemRoot;

		// Token: 0x040072C2 RID: 29378
		[SerializeField]
		private Text bountyIntroductionTitle;

		// Token: 0x040072C3 RID: 29379
		[SerializeField]
		private Button openBountyShopBtn;

		// Token: 0x040072C4 RID: 29380
		private int _adventureTeamLevel;

		// Token: 0x040072C5 RID: 29381
		private ComItem _blessCrystalComItem;

		// Token: 0x040072C6 RID: 29382
		private ComItem _bountyComItem;

		// Token: 0x040072C7 RID: 29383
		private string tr_adventure_team_name_format = string.Empty;

		// Token: 0x040072C8 RID: 29384
		private string tr_adventure_team_grade_color = string.Empty;

		// Token: 0x040072C9 RID: 29385
		private string tr_adventure_team_not_in_rank = string.Empty;

		// Token: 0x040072CA RID: 29386
		private string tr_adventure_team_role_field_count_format = string.Empty;

		// Token: 0x040072CB RID: 29387
		private string tr_bless_crystal_count_format = string.Empty;

		// Token: 0x040072CC RID: 29388
		private string tr_bless_crystal_introduction = string.Empty;

		// Token: 0x040072CD RID: 29389
		private string tr_bounty_count_format = string.Empty;

		// Token: 0x040072CE RID: 29390
		private string tr_bounty_introduction = string.Empty;

		// Token: 0x040072CF RID: 29391
		private string tr_adventure_team_grade_with_score = string.Empty;
	}
}
