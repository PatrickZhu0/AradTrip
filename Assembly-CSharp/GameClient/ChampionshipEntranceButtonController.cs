using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014E0 RID: 5344
	public class ChampionshipEntranceButtonController : MonoBehaviour
	{
		// Token: 0x0600CF4D RID: 53069 RVA: 0x003327EF File Offset: 0x00330BEF
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CF4E RID: 53070 RVA: 0x003327F7 File Offset: 0x00330BF7
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CF4F RID: 53071 RVA: 0x00332808 File Offset: 0x00330C08
		private void BindUiEvents()
		{
			if (this.oneButtonWithCd != null)
			{
				this.oneButtonWithCd.ResetListener();
				this.oneButtonWithCd.SetButtonListener(new Action(this.OnOneButtonClick));
			}
			if (this.leftButton != null)
			{
				this.leftButton.onClick.RemoveAllListeners();
				this.leftButton.onClick.AddListener(new UnityAction(this.OnLeftButtonClick));
			}
			if (this.rightButtonWithCd != null)
			{
				this.rightButtonWithCd.ResetListener();
				this.rightButtonWithCd.SetButtonListener(new Action(this.OnRightButtonClick));
			}
		}

		// Token: 0x0600CF50 RID: 53072 RVA: 0x003328B8 File Offset: 0x00330CB8
		private void UnBindUiEvents()
		{
			if (this.oneButtonWithCd != null)
			{
				this.oneButtonWithCd.ResetButtonListener();
			}
			if (this.leftButton != null)
			{
				this.leftButton.onClick.RemoveAllListeners();
			}
			if (this.rightButtonWithCd != null)
			{
				this.rightButtonWithCd.ResetButtonListener();
			}
		}

		// Token: 0x0600CF51 RID: 53073 RVA: 0x0033291E File Offset: 0x00330D1E
		private void ClearData()
		{
			this._championshipScheduleTable = null;
			this._isChampionshipScheduleOpenToPlayer = false;
			this._isChampionshipScheduleAlreadySignUp = false;
			this._isChampionshipScheduleOpenInTime = false;
			this._signUpCostItemId = 0;
			this._signUpCostValue = 0;
			this._signUpCostTable = null;
		}

		// Token: 0x0600CF52 RID: 53074 RVA: 0x00332951 File Offset: 0x00330D51
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600CF53 RID: 53075 RVA: 0x00332959 File Offset: 0x00330D59
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600CF54 RID: 53076 RVA: 0x00332961 File Offset: 0x00330D61
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipSignUpSucceedMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSignUpSucceedMessage));
		}

		// Token: 0x0600CF55 RID: 53077 RVA: 0x0033297E File Offset: 0x00330D7E
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipSignUpSucceedMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSignUpSucceedMessage));
		}

		// Token: 0x0600CF56 RID: 53078 RVA: 0x0033299C File Offset: 0x00330D9C
		public void Init(ChampionshipScheduleTable scheduleTable)
		{
			this._championshipScheduleTable = scheduleTable;
			this._isChampionshipScheduleAlreadySignUp = DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleAlreadySignUp;
			this._isChampionshipScheduleOpenInTime = DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenInTime;
			this._isChampionshipScheduleOpenToPlayer = DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenToPlayer;
			this._alreadySignUpPlayerGuid = DataManager<ChampionshipDataManager>.GetInstance().AlreadySignUpPlayerGuid;
			if (this._championshipScheduleTable == null)
			{
				return;
			}
			this._scheduleType = this._championshipScheduleTable.ScheduleType;
			this.UpdateEntranceButtonView();
		}

		// Token: 0x0600CF57 RID: 53079 RVA: 0x00332A14 File Offset: 0x00330E14
		private void UpdateEntranceButtonView()
		{
			CommonUtility.UpdateGameObjectVisible(this.oneButtonRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.twoButtonRoot, false);
			if (this._championshipScheduleTable == null)
			{
				return;
			}
			if (this._scheduleType >= ChampionshipScheduleTable.eScheduleType.SignUp && this._scheduleType <= ChampionshipScheduleTable.eScheduleType.Sixteen_Select)
			{
				CommonUtility.UpdateGameObjectVisible(this.twoButtonRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.oneButtonRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.otherPlayerSignUpFlag, false);
				string path = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Jinrusaichang";
				bool flag = true;
				if (this._scheduleType == ChampionshipScheduleTable.eScheduleType.SignUp)
				{
					CommonUtility.UpdateGameObjectVisible(this.costRoot, true);
					this.UpdateSignUpCost();
					if (this._alreadySignUpPlayerGuid > 0UL && this._alreadySignUpPlayerGuid != DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						flag = false;
						path = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Baoming";
						CommonUtility.UpdateGameObjectVisible(this.otherPlayerSignUpFlag, true);
					}
					else if (this._isChampionshipScheduleAlreadySignUp)
					{
						flag = false;
						path = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Yibaoming";
					}
					else
					{
						path = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Baoming";
					}
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.costRoot, false);
					if (!this._isChampionshipScheduleOpenInTime)
					{
						flag = false;
						path = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Weikaiqi";
					}
					else if (!this._isChampionshipScheduleOpenToPlayer)
					{
						flag = false;
						path = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Weijinji";
						if (this._scheduleType == ChampionshipScheduleTable.eScheduleType.Sea_Select)
						{
							path = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Weibaoming";
						}
					}
				}
				if (this.oneButtonImage != null)
				{
					ETCImageLoader.LoadSprite(ref this.oneButtonImage, path, true);
					this.oneButtonImage.SetNativeSize();
				}
				if (this.oneButtonWithCd != null)
				{
					this.oneButtonWithCd.UpdateButtonState(flag);
					CommonUtility.UpdateGameObjectUiGray(this.oneButtonGray, !flag);
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.oneButtonRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.twoButtonRoot, true);
				CommonUtility.UpdateButtonState(this.leftButton, this.leftButtonGray, true);
				bool flag2 = true;
				string path2 = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Jinrusaichang";
				if (ChampionshipUtility.IsInChampionshipEndShow())
				{
					flag2 = false;
					path2 = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Yijieshu";
				}
				else if (!this._isChampionshipScheduleOpenInTime)
				{
					flag2 = false;
					path2 = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Weikaiqi";
				}
				else if (!this._isChampionshipScheduleOpenToPlayer)
				{
					flag2 = false;
					path2 = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Weijinji";
				}
				if (this.rightButtonImage != null)
				{
					ETCImageLoader.LoadSprite(ref this.rightButtonImage, path2, true);
					this.rightButtonImage.SetNativeSize();
				}
				this.rightButtonWithCd.UpdateButtonState(flag2);
				CommonUtility.UpdateGameObjectUiGray(this.rightButtonGray, !flag2);
			}
		}

		// Token: 0x0600CF58 RID: 53080 RVA: 0x00332C64 File Offset: 0x00331064
		private void OnOneButtonClick()
		{
			if (this._scheduleType == ChampionshipScheduleTable.eScheduleType.SignUp)
			{
				if (this._isChampionshipScheduleAlreadySignUp)
				{
					return;
				}
				if (DataManager<PlayerBaseData>.GetInstance().Level < 60)
				{
					string msgContent = TR.Value("Championship_SignUp_Limit_By_Level", 60);
					SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (this._signUpCostItemId <= 0 || this._signUpCostValue <= 0)
				{
					return;
				}
				if (this._signUpCostTable == null)
				{
					return;
				}
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = this._signUpCostItemId;
				costInfo.nCount = this._signUpCostValue;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, new Action(this.OnShowChampionshipEnrollTipFrame), "common_money_cost", null);
			}
			else
			{
				this.OnEnterChampionshipPrepareScene();
			}
		}

		// Token: 0x0600CF59 RID: 53081 RVA: 0x00332D20 File Offset: 0x00331120
		private void OnLeftButtonClick()
		{
			ChampionshipUtility.OnOpenChampionshipFightRaceFrame(this._championshipScheduleTable.ID);
		}

		// Token: 0x0600CF5A RID: 53082 RVA: 0x00332D32 File Offset: 0x00331132
		private void OnRightButtonClick()
		{
			this.OnEnterChampionshipPrepareScene();
		}

		// Token: 0x0600CF5B RID: 53083 RVA: 0x00332D3C File Offset: 0x0033113C
		private void OnShowChampionshipEnrollTipFrame()
		{
			string tipContent = TR.Value("Championship_SignUp_Description_Label", this._signUpCostValue, this._signUpCostTable.Name);
			CommonUtility.OnShowCommonMsgBox(tipContent, new Action(this.OnSendChampionshipEnrollReq), TR.Value("common_data_sure_2"));
		}

		// Token: 0x0600CF5C RID: 53084 RVA: 0x00332D86 File Offset: 0x00331186
		private void OnSendChampionshipEnrollReq()
		{
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionEnrollReq();
		}

		// Token: 0x0600CF5D RID: 53085 RVA: 0x00332D94 File Offset: 0x00331194
		private void OnEnterChampionshipPrepareScene()
		{
			if (!this._isChampionshipScheduleOpenInTime)
			{
				return;
			}
			if (!this._isChampionshipScheduleOpenToPlayer)
			{
				return;
			}
			if (this._championshipScheduleTable == null)
			{
				return;
			}
			int sceneIdByChampionshipScheduleId = ChampionshipUtility.GetSceneIdByChampionshipScheduleId(this._championshipScheduleTable.ID);
			CommonUtility.OnEndSceneInClientSystemTown(sceneIdByChampionshipScheduleId);
			ChampionshipUtility.OnCloseChampionshipEntranceFrame();
		}

		// Token: 0x0600CF5E RID: 53086 RVA: 0x00332DE4 File Offset: 0x003311E4
		private void OnReceiveChampionshipSignUpSucceedMessage(UIEvent uiEvent)
		{
			this._isChampionshipScheduleAlreadySignUp = DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleAlreadySignUp;
			if (!this._isChampionshipScheduleAlreadySignUp)
			{
				return;
			}
			if (this._scheduleType != ChampionshipScheduleTable.eScheduleType.SignUp)
			{
				return;
			}
			string path = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Yibaoming";
			if (this.oneButtonImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.oneButtonImage, path, true);
				this.oneButtonImage.SetNativeSize();
			}
			this.oneButtonWithCd.UpdateButtonState(false);
			CommonUtility.UpdateGameObjectUiGray(this.oneButtonGray, true);
		}

		// Token: 0x0600CF5F RID: 53087 RVA: 0x00332E64 File Offset: 0x00331264
		private void UpdateSignUpCost()
		{
			if (this._championshipScheduleTable == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this._championshipScheduleTable.JoinCost))
			{
				return;
			}
			List<int> numberListBySplitStringWithLine = CommonUtility.GetNumberListBySplitStringWithLine(this._championshipScheduleTable.JoinCost);
			if (numberListBySplitStringWithLine == null || numberListBySplitStringWithLine.Count != 2)
			{
				return;
			}
			this._signUpCostItemId = numberListBySplitStringWithLine[0];
			this._signUpCostValue = numberListBySplitStringWithLine[1];
			if (this.costValueLabel != null)
			{
				this.costValueLabel.text = this._signUpCostValue.ToString();
			}
			this._signUpCostTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._signUpCostItemId, string.Empty, string.Empty);
			if (this.costIconImage != null && this._signUpCostTable != null)
			{
				ETCImageLoader.LoadSprite(ref this.costIconImage, this._signUpCostTable.Icon, true);
			}
		}

		// Token: 0x0400792D RID: 31021
		private const string SignUpImagePath = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Baoming";

		// Token: 0x0400792E RID: 31022
		private const string AlreadySignUpImagePath = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Yibaoming";

		// Token: 0x0400792F RID: 31023
		private const string NotSignUpImagePath = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Weibaoming";

		// Token: 0x04007930 RID: 31024
		private const string EnterInImagePath = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Jinrusaichang";

		// Token: 0x04007931 RID: 31025
		private const string NotOpenImagePath = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Weikaiqi";

		// Token: 0x04007932 RID: 31026
		private const string NotAdvanceImagePath = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Weijinji";

		// Token: 0x04007933 RID: 31027
		private const string FinishRaceImagePath = "UI/Image/Packed/p_UI_Championship.png:UI_Championship_Anniu_Yijieshu";

		// Token: 0x04007934 RID: 31028
		private bool _isChampionshipScheduleOpenInTime;

		// Token: 0x04007935 RID: 31029
		private bool _isChampionshipScheduleOpenToPlayer;

		// Token: 0x04007936 RID: 31030
		private bool _isChampionshipScheduleAlreadySignUp;

		// Token: 0x04007937 RID: 31031
		private ChampionshipScheduleTable.eScheduleType _scheduleType;

		// Token: 0x04007938 RID: 31032
		private ulong _alreadySignUpPlayerGuid;

		// Token: 0x04007939 RID: 31033
		private int _signUpCostItemId;

		// Token: 0x0400793A RID: 31034
		private int _signUpCostValue;

		// Token: 0x0400793B RID: 31035
		private ItemTable _signUpCostTable;

		// Token: 0x0400793C RID: 31036
		private ChampionshipScheduleTable _championshipScheduleTable;

		// Token: 0x0400793D RID: 31037
		[Space(10f)]
		[Header("OneButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject oneButtonRoot;

		// Token: 0x0400793E RID: 31038
		[SerializeField]
		private ComButtonWithCd oneButtonWithCd;

		// Token: 0x0400793F RID: 31039
		[SerializeField]
		private GameObject otherPlayerSignUpFlag;

		// Token: 0x04007940 RID: 31040
		[SerializeField]
		private UIGray oneButtonGray;

		// Token: 0x04007941 RID: 31041
		[SerializeField]
		private Image oneButtonImage;

		// Token: 0x04007942 RID: 31042
		[Space(10f)]
		[Header("CostContent")]
		[Space(10f)]
		[SerializeField]
		private GameObject costRoot;

		// Token: 0x04007943 RID: 31043
		[SerializeField]
		private Text costValueLabel;

		// Token: 0x04007944 RID: 31044
		[SerializeField]
		private Image costIconImage;

		// Token: 0x04007945 RID: 31045
		[Space(10f)]
		[Header("TwoButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject twoButtonRoot;

		// Token: 0x04007946 RID: 31046
		[SerializeField]
		private Button leftButton;

		// Token: 0x04007947 RID: 31047
		[SerializeField]
		private UIGray leftButtonGray;

		// Token: 0x04007948 RID: 31048
		[SerializeField]
		private ComButtonWithCd rightButtonWithCd;

		// Token: 0x04007949 RID: 31049
		[SerializeField]
		private UIGray rightButtonGray;

		// Token: 0x0400794A RID: 31050
		[SerializeField]
		private Image rightButtonImage;
	}
}
