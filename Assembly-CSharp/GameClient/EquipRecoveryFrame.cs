using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015CB RID: 5579
	internal class EquipRecoveryFrame : ClientFrame
	{
		// Token: 0x0600DA78 RID: 55928 RVA: 0x0036F08E File Offset: 0x0036D48E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipRecovery/EquipRecoveryFrame";
		}

		// Token: 0x0600DA79 RID: 55929 RVA: 0x0036F095 File Offset: 0x0036D495
		public static void OpenLinkFrame(string strParam)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<EquipRecoveryFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipRecoveryFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DA7A RID: 55930 RVA: 0x0036F0B5 File Offset: 0x0036D4B5
		protected sealed override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this._InitData();
			this._InitUI();
		}

		// Token: 0x0600DA7B RID: 55931 RVA: 0x0036F0CC File Offset: 0x0036D4CC
		private void _InitData()
		{
			DataManager<EquipRecoveryDataManager>.GetInstance().HaveWeekRedPoint = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.EquipRecovery, null, null, null);
			this.rewardJarList.Clear();
			this.setSliderValueHandler = null;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(372, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.maxjarScore = tableItem.Value;
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(374, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.maxjarCount = tableItem2.Value;
			}
			this._UpdateWeekCount();
			this.rewardScore = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_REWARD_SCORE);
		}

		// Token: 0x0600DA7C RID: 55932 RVA: 0x0036F182 File Offset: 0x0036D582
		private void _InitUI()
		{
			this._InitRecordList();
			this._ClearRecord();
			this._InitReward();
			this._UpdateJarRecord();
		}

		// Token: 0x0600DA7D RID: 55933 RVA: 0x0036F19C File Offset: 0x0036D59C
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DA7E RID: 55934 RVA: 0x0036F1B0 File Offset: 0x0036D5B0
		private void _ClearData()
		{
			this.maxjarScore = 0;
			this.maxjarCount = 0;
			this.rewardScore = 0;
			this.minScore = 0;
			this.maxScore = 100;
			this.setSliderValueHandler = null;
			this.rewardJarList.Clear();
		}

		// Token: 0x0600DA7F RID: 55935 RVA: 0x0036F1E8 File Offset: 0x0036D5E8
		private void _ClearUI()
		{
			this._ClearRecord();
		}

		// Token: 0x0600DA80 RID: 55936 RVA: 0x0036F1F0 File Offset: 0x0036D5F0
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipRecoveryPriceReqSuccess, new ClientEventSystem.UIEventHandler(this.OnEquipRecoveryPriceReqSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipSubmitSuccess, new ClientEventSystem.UIEventHandler(this.OnEquipSubmitSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipRedeemSuccess, new ClientEventSystem.UIEventHandler(this.OnUpdateJarStatic));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipUpgradeSuccess, new ClientEventSystem.UIEventHandler(this.OnUpdateJarStatic));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipJarListUpdate, new ClientEventSystem.UIEventHandler(this._OnEquipJarListUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnGetJarRecord));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipSubmitScore, new ClientEventSystem.UIEventHandler(this._EquipSubmitScore));
		}

		// Token: 0x0600DA81 RID: 55937 RVA: 0x0036F2D8 File Offset: 0x0036D6D8
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipRecoveryPriceReqSuccess, new ClientEventSystem.UIEventHandler(this.OnEquipRecoveryPriceReqSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipSubmitSuccess, new ClientEventSystem.UIEventHandler(this.OnEquipSubmitSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipRedeemSuccess, new ClientEventSystem.UIEventHandler(this.OnUpdateJarStatic));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipUpgradeSuccess, new ClientEventSystem.UIEventHandler(this.OnUpdateJarStatic));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipJarListUpdate, new ClientEventSystem.UIEventHandler(this._OnEquipJarListUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnGetJarRecord));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipSubmitScore, new ClientEventSystem.UIEventHandler(this._EquipSubmitScore));
		}

		// Token: 0x0600DA82 RID: 55938 RVA: 0x0036F3C0 File Offset: 0x0036D7C0
		private void OnEquipRecoveryPriceReqSuccess(UIEvent iEvent)
		{
			int num = (int)iEvent.Param1;
			int num2 = (int)iEvent.Param2;
		}

		// Token: 0x0600DA83 RID: 55939 RVA: 0x0036F3E8 File Offset: 0x0036D7E8
		private void OnEquipSubmitSuccess(UIEvent iEvent)
		{
			uint score = (uint)iEvent.Param1;
			this._TryPlayEffect((int)score);
			if (this.mEffect.activeSelf)
			{
				this.mEffect.CustomActive(false);
			}
			this.mEffect.CustomActive(true);
			base.StartCoroutine(this.DonateResult((int)score));
		}

		// Token: 0x0600DA84 RID: 55940 RVA: 0x0036F440 File Offset: 0x0036D840
		private IEnumerator DonateResult(int score)
		{
			yield return new WaitForSeconds(1f);
			this.mTextRoot.CustomActive(true);
			int count = 0;
			List<EqRecScoreItem> rewardList = DataManager<EquipRecoveryDataManager>.GetInstance().submitResult;
			for (int j = 0; j < rewardList.Count; j++)
			{
				count += (int)rewardList[j].score;
			}
			float time = 0.01f;
			for (int i = 0; i < 30; i++)
			{
				this.mDonateResult.text = Random.Range(this.minScore, this.maxScore + 1).ToString();
				yield return new WaitForSeconds(time);
				time += 0.005f;
			}
			this.mDonateResult.text = count.ToString();
			yield return null;
			yield return new WaitForSeconds(1.45f);
			this.mTextRoot.CustomActive(false);
			yield break;
		}

		// Token: 0x0600DA85 RID: 55941 RVA: 0x0036F45B File Offset: 0x0036D85B
		private void OnUpdateJarStatic(UIEvent iEvent)
		{
			this._UpdateReward();
		}

		// Token: 0x0600DA86 RID: 55942 RVA: 0x0036F463 File Offset: 0x0036D863
		private void _OnUpdateOpenRecord(UIEvent a_event)
		{
			this._ClearRecord();
			this.m_recordData = (a_event.Param1 as WorldEquipRecoOpenJarsRecordRes);
			this._UpdateRecord();
		}

		// Token: 0x0600DA87 RID: 55943 RVA: 0x0036F482 File Offset: 0x0036D882
		private void _OnEquipJarListUpdate(UIEvent iEvent)
		{
			this._ClearRecord();
			this.m_recordData = (iEvent.Param1 as WorldEquipRecoOpenJarsRecordRes);
			base.StartCoroutine(this._UpdateEquipRecord());
		}

		// Token: 0x0600DA88 RID: 55944 RVA: 0x0036F4A8 File Offset: 0x0036D8A8
		private IEnumerator _UpdateEquipRecord()
		{
			while (this.frameMgr.IsFrameOpen<ShowItemsFrame>(null))
			{
				yield return new WaitForEndOfFrame();
			}
			this._UpdateRecord();
			yield break;
		}

		// Token: 0x0600DA89 RID: 55945 RVA: 0x0036F4C3 File Offset: 0x0036D8C3
		private void _OnGetJarRecord(UIEvent iEvent)
		{
			this._UpdateJarRecord();
		}

		// Token: 0x0600DA8A RID: 55946 RVA: 0x0036F4CB File Offset: 0x0036D8CB
		private void _EquipSubmitScore(UIEvent iEvent)
		{
			this.minScore = (int)iEvent.Param1;
			this.maxScore = (int)iEvent.Param2;
		}

		// Token: 0x0600DA8B RID: 55947 RVA: 0x0036F4F0 File Offset: 0x0036D8F0
		private void _InitReward()
		{
			DataManager<EquipRecoveryDataManager>.GetInstance()._ClearJarKeyList();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipRecoveryRewardTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				if (num >= this.mRootList.Count)
				{
					break;
				}
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				EquipRecoveryRewardTable equipRecoveryRewardTable = keyValuePair.Value as EquipRecoveryRewardTable;
				RewardJarItem rewardJarItem = new RewardJarItem();
				rewardJarItem.CreateGo(this.mRootList[num], equipRecoveryRewardTable);
				this.rewardJarList.Add(rewardJarItem);
				DataManager<EquipRecoveryDataManager>.GetInstance()._AddJarKeyList(equipRecoveryRewardTable.Integral);
				num++;
			}
			this._UpdateReward();
		}

		// Token: 0x0600DA8C RID: 55948 RVA: 0x0036F59C File Offset: 0x0036D99C
		private void _UpdateJarRecord()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < this.rewardJarList.Count; i++)
			{
				list.Add(this.rewardJarList[i].GetJarID());
			}
			DataManager<EquipRecoveryDataManager>.GetInstance().RequestJarRecord(list);
		}

		// Token: 0x0600DA8D RID: 55949 RVA: 0x0036F5F0 File Offset: 0x0036D9F0
		private void _TryPlayEffect(int score)
		{
			this.rewardScore = score;
			float value = this.mGetAniValue.GetValue((float)this.rewardScore);
			float x = this.mBoxRoot.GetComponent<RectTransform>().sizeDelta.x;
			Vector2 beginPos;
			beginPos..ctor(x * this.mBoxSlider.value, 0f);
			Vector2 endPos;
			endPos..ctor(x * value, 0f);
			this.mSliderChange.CustomActive(true);
			this.mSliderChange.StartRemove(beginPos, endPos, new Action(this._UpdateRewardCallBack));
		}

		// Token: 0x0600DA8E RID: 55950 RVA: 0x0036F680 File Offset: 0x0036DA80
		private void _UpdateReward()
		{
			this.rewardScore = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_REWARD_SCORE);
			this.mHaveScore.text = this.rewardScore.ToString();
			this.mBoxSlider.value = this.mGetAniValue.GetValue((float)this.rewardScore);
			for (int i = 0; i < this.rewardJarList.Count; i++)
			{
				this.rewardJarList[i].UpdateRewardJar(i + 1);
			}
		}

		// Token: 0x0600DA8F RID: 55951 RVA: 0x0036F70C File Offset: 0x0036DB0C
		private void _UpdateRewardCallBack()
		{
			if (this.mBoxSlider == null || this.mGetAniValue == null || this.mSliderChange == null)
			{
				return;
			}
			this.mBoxSlider.value = this.mGetAniValue.GetValue((float)this.rewardScore);
			for (int i = 0; i < this.rewardJarList.Count; i++)
			{
				if (this.rewardJarList[i] != null)
				{
					this.rewardJarList[i].UpdateRewardJar(i + 1);
				}
			}
			this.mSliderChange.CustomActive(false);
		}

		// Token: 0x0600DA90 RID: 55952 RVA: 0x0036F7BC File Offset: 0x0036DBBC
		private void _UpdateWeekCount()
		{
			this.mContributeContent.text = string.Concat(new object[]
			{
				DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_WEEK_COUNT).ToString(),
				"/",
				this.maxjarCount,
				"次"
			});
		}

		// Token: 0x0600DA91 RID: 55953 RVA: 0x0036F81D File Offset: 0x0036DC1D
		private void _UpdateRecoveryCount()
		{
		}

		// Token: 0x0600DA92 RID: 55954 RVA: 0x0036F81F File Offset: 0x0036DC1F
		private void _OnPackageItemClicked(GameObject obj, ItemData item)
		{
			obj.GetComponent<ComItem>().SetShowSelectState(true);
		}

		// Token: 0x0600DA93 RID: 55955 RVA: 0x0036F82D File Offset: 0x0036DC2D
		private void OnCountValueChanged(UIEvent uiEvent)
		{
			this._UpdateReward();
			this._UpdateWeekCount();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.EquipRecovery, null, null, null);
		}

		// Token: 0x0600DA94 RID: 55956 RVA: 0x0036F854 File Offset: 0x0036DC54
		private void _InitRecordList()
		{
			this.mRecordUIList.Initialize();
			this.mRecordUIList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_recordData != null && var.m_index >= 0 && var.m_index < this.m_recordData.records.Length)
				{
					int num = this.m_recordData.records.Length - var.m_index - 1;
					OpenJarRecord openJarRecord = this.m_recordData.records[num];
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID((int)openJarRecord.itemId);
					if (commonItemTableDataByID != null)
					{
						string arg = string.Format(" {{I 0 {0} 0}}", openJarRecord.itemId);
						var.GetComponent<LinkParse>().SetText(TR.Value("jar_record", openJarRecord.name, arg, openJarRecord.num), true);
						return;
					}
				}
			};
		}

		// Token: 0x0600DA95 RID: 55957 RVA: 0x0036F878 File Offset: 0x0036DC78
		private void _UpdateRecord()
		{
			if (this.m_recordData != null)
			{
				this.mRecordUIList.SetElementAmount(this.m_recordData.records.Length);
				this.mRecordUIList.EnsureElementVisable(0);
				return;
			}
			this.mRecordUIList.SetElementAmount(0);
		}

		// Token: 0x0600DA96 RID: 55958 RVA: 0x0036F8B6 File Offset: 0x0036DCB6
		private void _ClearRecord()
		{
			this.mRecordUIList.SetElementAmount(0);
			this.m_recordData = null;
		}

		// Token: 0x0600DA97 RID: 55959 RVA: 0x0036F8CC File Offset: 0x0036DCCC
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mRecordUIList = this.mBind.GetCom<ComUIListScript>("recordUIList");
			this.mRecordUIListElement = this.mBind.GetCom<ComUIListElementScript>("recordUIListElement");
			this.mScoreBar = this.mBind.GetGameObject("scoreBar");
			this.mBoxSlider = this.mBind.GetCom<Slider>("boxSlider");
			this.mBoxRoot = this.mBind.GetGameObject("boxRoot");
			this.mContribute = this.mBind.GetCom<Button>("contribute");
			this.mContribute.onClick.AddListener(new UnityAction(this._onContributeButtonClick));
			this.mContributeRecord = this.mBind.GetCom<Button>("contributeRecord");
			this.mContributeRecord.onClick.AddListener(new UnityAction(this._onContributeRecordButtonClick));
			this.mEquipPromote = this.mBind.GetCom<Button>("equipPromote");
			this.mEquipPromote.onClick.AddListener(new UnityAction(this._onEquipPromoteButtonClick));
			this.mContributeContent = this.mBind.GetCom<Text>("contributeContent");
			this.mRootList.Add(this.mBind.GetGameObject("root1"));
			this.mRootList.Add(this.mBind.GetGameObject("root2"));
			this.mRootList.Add(this.mBind.GetGameObject("root3"));
			this.mRootList.Add(this.mBind.GetGameObject("root4"));
			this.mRootList.Add(this.mBind.GetGameObject("root5"));
			this.mRootList.Add(this.mBind.GetGameObject("root6"));
			this.mRootList.Add(this.mBind.GetGameObject("root7"));
			this.mRootList.Add(this.mBind.GetGameObject("root8"));
			this.mRootList.Add(this.mBind.GetGameObject("root9"));
			this.mRootList.Add(this.mBind.GetGameObject("root10"));
			this.mEffect = this.mBind.GetGameObject("Effect");
			this.mSliderChange = this.mBind.GetCom<SliderChange>("SliderChange");
			this.mRemoveEffect = this.mBind.GetGameObject("removeEffect");
			this.mDonateResult = this.mBind.GetCom<Text>("donateResult");
			this.mTextRoot = this.mBind.GetGameObject("textRoot");
			this.mGetAniValue = this.mBind.GetCom<GetAniValue>("GetAniValue");
			this.mHaveScore = this.mBind.GetCom<Text>("haveScore");
		}

		// Token: 0x0600DA98 RID: 55960 RVA: 0x0036FBD0 File Offset: 0x0036DFD0
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mRecordUIList = null;
			this.mRecordUIListElement = null;
			this.mScoreBar = null;
			this.mBoxSlider = null;
			this.mBoxRoot = null;
			this.mContribute.onClick.RemoveListener(new UnityAction(this._onContributeButtonClick));
			this.mContribute = null;
			this.mContributeRecord.onClick.RemoveListener(new UnityAction(this._onContributeRecordButtonClick));
			this.mContributeRecord = null;
			this.mEquipPromote.onClick.RemoveListener(new UnityAction(this._onEquipPromoteButtonClick));
			this.mEquipPromote = null;
			this.mContributeContent = null;
			this.mRootList.Clear();
			this.mEffect = null;
			this.mSliderChange = null;
			this.mRemoveEffect = null;
			this.mDonateResult = null;
			this.mTextRoot = null;
			this.mGetAniValue = null;
			this.mHaveScore = null;
		}

		// Token: 0x0600DA99 RID: 55961 RVA: 0x0036FCCF File Offset: 0x0036E0CF
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<EquipRecoveryFrame>(this, false);
		}

		// Token: 0x0600DA9A RID: 55962 RVA: 0x0036FCDE File Offset: 0x0036E0DE
		private void _onContributeButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipDonateFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DA9B RID: 55963 RVA: 0x0036FCF2 File Offset: 0x0036E0F2
		private void _onContributeRecordButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipReturnFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DA9C RID: 55964 RVA: 0x0036FD06 File Offset: 0x0036E106
		private void _onEquipPromoteButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipUpgradeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x04008083 RID: 32899
		public EquipRecoveryFrame.SetSliderValue setSliderValueHandler;

		// Token: 0x04008084 RID: 32900
		private int maxjarScore;

		// Token: 0x04008085 RID: 32901
		private int maxjarCount;

		// Token: 0x04008086 RID: 32902
		private int rewardScore;

		// Token: 0x04008087 RID: 32903
		private int minScore;

		// Token: 0x04008088 RID: 32904
		private int maxScore = 100;

		// Token: 0x04008089 RID: 32905
		private List<RewardJarItem> rewardJarList = new List<RewardJarItem>();

		// Token: 0x0400808A RID: 32906
		private WorldEquipRecoOpenJarsRecordRes m_recordData;

		// Token: 0x0400808B RID: 32907
		private Button mBtClose;

		// Token: 0x0400808C RID: 32908
		private ComUIListScript mRecordUIList;

		// Token: 0x0400808D RID: 32909
		private ComUIListElementScript mRecordUIListElement;

		// Token: 0x0400808E RID: 32910
		private GameObject mScoreBar;

		// Token: 0x0400808F RID: 32911
		private Slider mBoxSlider;

		// Token: 0x04008090 RID: 32912
		private GameObject mBoxRoot;

		// Token: 0x04008091 RID: 32913
		private Button mContribute;

		// Token: 0x04008092 RID: 32914
		private Button mContributeRecord;

		// Token: 0x04008093 RID: 32915
		private Button mEquipPromote;

		// Token: 0x04008094 RID: 32916
		private Text mContributeContent;

		// Token: 0x04008095 RID: 32917
		private List<GameObject> mRootList = new List<GameObject>();

		// Token: 0x04008096 RID: 32918
		private GameObject mEffect;

		// Token: 0x04008097 RID: 32919
		private SliderChange mSliderChange;

		// Token: 0x04008098 RID: 32920
		private GameObject mRemoveEffect;

		// Token: 0x04008099 RID: 32921
		private Text mDonateResult;

		// Token: 0x0400809A RID: 32922
		private GameObject mTextRoot;

		// Token: 0x0400809B RID: 32923
		private GetAniValue mGetAniValue;

		// Token: 0x0400809C RID: 32924
		private Text mHaveScore;

		// Token: 0x020015CC RID: 5580
		// (Invoke) Token: 0x0600DA9F RID: 55967
		public delegate void SetSliderValue(float fatigueCoinText);
	}
}
