using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017BE RID: 6078
	internal class ComFunctionItem : MonoBehaviour
	{
		// Token: 0x0600EFA7 RID: 61351 RVA: 0x0040786C File Offset: 0x00405C6C
		public bool IsExist()
		{
			return (this.iId < 10 && this.iId >= 0) || (this.value != null && this.value.missionItem != null && DataManager<MissionManager>.GetInstance().taskGroup.ContainsKey((uint)this.value.missionItem.ID) && DataManager<MissionManager>.GetInstance().taskGroup[(uint)this.value.missionItem.ID] != null);
		}

		// Token: 0x0600EFA8 RID: 61352 RVA: 0x00407900 File Offset: 0x00405D00
		public void PlayAnimation()
		{
			if (null != this.goFinishAnimation)
			{
				this.goFinishAnimation.CustomActive(true);
			}
		}

		// Token: 0x0600EFA9 RID: 61353 RVA: 0x0040791F File Offset: 0x00405D1F
		public void StopAnimation()
		{
			if (null != this.goFinishAnimation)
			{
				this.goFinishAnimation.CustomActive(false);
			}
		}

		// Token: 0x17001CE5 RID: 7397
		// (get) Token: 0x0600EFAA RID: 61354 RVA: 0x0040793E File Offset: 0x00405D3E
		// (set) Token: 0x0600EFAB RID: 61355 RVA: 0x00407946 File Offset: 0x00405D46
		private bool bSelected
		{
			get
			{
				return this.m_bSelected;
			}
			set
			{
				this.m_bSelected = value;
				this._UpdateBG();
			}
		}

		// Token: 0x17001CE6 RID: 7398
		// (get) Token: 0x0600EFAC RID: 61356 RVA: 0x00407955 File Offset: 0x00405D55
		public bool IsTaskGuiding
		{
			get
			{
				return Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl();
			}
		}

		// Token: 0x0600EFAD RID: 61357 RVA: 0x00407964 File Offset: 0x00405D64
		private void _UpdateBG()
		{
			if (null != this.bg)
			{
				this.bg.sprite = (Singleton<AssetLoader>.instance.LoadRes((!this.bSelected) ? TR.Value(ComFunctionItem.ms_normal_texture) : TR.Value(ComFunctionItem.ms_selected_texture), typeof(Sprite), true, 0U).obj as Sprite);
			}
		}

		// Token: 0x0600EFAE RID: 61358 RVA: 0x004079D4 File Offset: 0x00405DD4
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TraceBegin, new ClientEventSystem.UIEventHandler(this.OnTraceBegin));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TraceEnd, new ClientEventSystem.UIEventHandler(this.OnTraceEnd));
		}

		// Token: 0x0600EFAF RID: 61359 RVA: 0x00407A50 File Offset: 0x00405E50
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TraceBegin, new ClientEventSystem.UIEventHandler(this.OnTraceBegin));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TraceEnd, new ClientEventSystem.UIEventHandler(this.OnTraceEnd));
			if (null != this.link)
			{
				this.link.onClick.RemoveAllListeners();
				this.link = null;
			}
			if (null == this.comAward)
			{
				ComItemManager.Destroy(this.comAward);
				this.comAward = null;
			}
		}

		// Token: 0x0600EFB0 RID: 61360 RVA: 0x00407B14 File Offset: 0x00405F14
		private void OnNewbieGuideStart(UIEvent uiEvent)
		{
			if (this.iId != -1)
			{
				this.OnItemVisible(this.iId);
			}
		}

		// Token: 0x0600EFB1 RID: 61361 RVA: 0x00407B2E File Offset: 0x00405F2E
		private void OnNewbieGuideFinish(UIEvent uiEvent)
		{
			if (this.iId != -1)
			{
				this.OnItemVisible(this.iId);
			}
		}

		// Token: 0x0600EFB2 RID: 61362 RVA: 0x00407B48 File Offset: 0x00405F48
		private void OnTraceBegin(UIEvent uiEvent)
		{
			int num = (int)uiEvent.Param1;
			DataManager<MissionManager>.GetInstance().FunctionTraceID = num;
			if (this.iId == num)
			{
				this.bSelected = true;
			}
		}

		// Token: 0x0600EFB3 RID: 61363 RVA: 0x00407B80 File Offset: 0x00405F80
		private void OnTraceEnd(UIEvent uiEvent)
		{
			int num = (int)uiEvent.Param1;
			if (DataManager<MissionManager>.GetInstance().FunctionTraceID == num)
			{
				DataManager<MissionManager>.GetInstance().FunctionTraceID = -1;
			}
			if (this.iId == num)
			{
				this.bSelected = false;
			}
		}

		// Token: 0x0600EFB4 RID: 61364 RVA: 0x00407BC7 File Offset: 0x00405FC7
		private void OnClickLink(int iTaskID, UnityAction onBegin, UnityAction onEnd)
		{
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown)
			{
				if (onBegin != null)
				{
					onBegin.Invoke();
				}
				DataManager<MissionManager>.GetInstance().AutoTraceTask(iTaskID, onEnd, onEnd, false);
			}
		}

		// Token: 0x0600EFB5 RID: 61365 RVA: 0x00407BF8 File Offset: 0x00405FF8
		public void OnItemVisible(int iId)
		{
			this.iId = iId;
			if (null == this.comAward)
			{
				this.comAward = ComItemManager.Create(this.goItemParent);
			}
			base.gameObject.name = ComFunctionItem.ms_created;
			this._UpdateBG();
			if (null != this.comEffect)
			{
				this.comEffect.Stop("mainEffect");
				this.comEffect.Stop("attachEffect");
				this.comEffect.Stop("awakeEffect");
				this.comEffect.Stop("JinGuangEffect");
			}
			if (null != this.comAward)
			{
				this.comAward.CustomActive(false);
				this.comAward.Setup(null, null);
			}
			this.goAwake.CustomActive(false);
			int traceId = iId;
			if (iId != 0 && iId != 1 && iId != 2)
			{
				this.jumpHint.CustomActive(false);
				this.goJumpLink.CustomActive(false);
				this.missionItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iId, string.Empty, string.Empty);
				DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)iId, out this.value);
				if (this.value != null)
				{
					this.Name.text = DataManager<MissionManager>.GetInstance().GetMissionName((uint)this.missionItem.ID) + DataManager<MissionManager>.GetInstance().GetMissionNameAppendBystatus((int)this.value.status, this.value.missionItem.ID);
					if (this.content != null)
					{
						if (this.missionItem.SubType == MissionTable.eSubType.SummerNpc)
						{
							this.content.SetText(Utility.ParseMissionText(iId, true, false, false), true);
						}
						else
						{
							this.content.SetText(Utility.ParseMissionText(iId, true, false, false), true);
						}
					}
					if (this.link != null)
					{
						this.link.onClick.RemoveAllListeners();
						this.link.onClick.AddListener(delegate()
						{
							this.OnClickLink(iId, delegate
							{
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TraceBegin, traceId, null, null, null);
							}, delegate
							{
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TraceEnd, traceId, null, null, null);
							});
						});
					}
					if (this.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN)
					{
						if (DataManager<PlayerBaseData>.GetInstance().Level <= 15)
						{
							this.comEffect.Play("JinGuangEffect");
						}
						else
						{
							this.comEffect.Play("mainEffect");
						}
						if (this.missionItem.MinPlayerLv <= 10 && !this.IsTaskGuiding)
						{
							this.comEffect.Play("attachEffect");
						}
					}
					if (this.value.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE)
					{
						int finalTitleMission = DataManager<MissionManager>.GetInstance().GetFinalTitleMission(this.value.missionItem.ID);
						List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(finalTitleMission, DataManager<PlayerBaseData>.GetInstance().JobTableID);
						if (missionAwards != null && missionAwards.Count > 0)
						{
							AwardItemData awardItemData = missionAwards[missionAwards.Count - 1];
							ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(awardItemData.ID);
							if (commonItemTableDataByID != null)
							{
								this.comAward.Setup(commonItemTableDataByID, delegate(GameObject go, ItemData item)
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
								});
								this.comAward.CustomActive(true);
							}
						}
					}
					if (this.value.missionItem.TaskType == MissionTable.eTaskType.TT_AWAKEN)
					{
						this.comEffect.Play("awakeEffect");
						this.goAwake.CustomActive(true);
					}
				}
			}
			else
			{
				this.missionItem = null;
				this.value = null;
				if (iId == 1)
				{
					this.jumpHint.CustomActive(false);
					this.goJumpLink.CustomActive(false);
					this.Name.text = TR.Value("mission_has_no_mission");
					this.content.SetText(TR.Value("mission_finish_all"), false);
					if (this.link != null)
					{
						this.link.onClick.RemoveAllListeners();
					}
					return;
				}
				if (iId == 2)
				{
					this.jumpHint.CustomActive(false);
					this.goJumpLink.CustomActive(false);
					this.Name.text = TR.Value("mission_has_no_main");
					this.content.SetText(TR.Value("mission_finish_all_main"), false);
					if (this.link != null)
					{
						this.link.onClick.RemoveAllListeners();
					}
					return;
				}
				MissionTable nextMissionItem = DataManager<MissionManager>.GetInstance().GetNextMissionItem((int)DataManager<PlayerBaseData>.GetInstance().Level);
				if (nextMissionItem == null)
				{
					this.jumpHint.CustomActive(false);
					this.goJumpLink.CustomActive(false);
					this.Name.text = TR.Value("mission_has_no_main");
					this.content.SetText(TR.Value("mission_finish_all_main"), false);
					if (this.link != null)
					{
						this.link.onClick.RemoveAllListeners();
					}
				}
				else
				{
					if (DataManager<PlayerBaseData>.GetInstance().Level <= 15)
					{
						this.comEffect.Play("JinGuangEffect");
					}
					this.jumpHint.CustomActive(true);
					this.goJumpLink.CustomActive(true);
					this.Name.text = DataManager<MissionManager>.GetInstance().GetMissionName((uint)nextMissionItem.ID);
					int nextLevelMission = DataManager<MissionManager>.GetInstance().GetNextLevelMission((int)DataManager<PlayerBaseData>.GetInstance().Level);
					this.content.SetText(string.Empty, false);
					this.jumpHint.text = string.Format(TR.Value("mission_need_lv"), nextLevelMission);
					if (this.link != null)
					{
						this.link.onClick.RemoveAllListeners();
						this.link.onClick.AddListener(delegate()
						{
							if (this.willOpenDailyTodo && DataManager<DailyTodoDataManager>.GetInstance().BFuncOpen)
							{
								DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(DailyTodoFrame.OPEN_LINK_INFO, null, false);
							}
							else
							{
								DataManager<ActiveManager>.GetInstance().OnClickLinkInfo("<type=framename param=1 value=GameClient.DevelopGuidanceMainFrame>", null, false);
							}
						});
					}
				}
			}
		}

		// Token: 0x040092EF RID: 37615
		public LinkParse content;

		// Token: 0x040092F0 RID: 37616
		public Text Name;

		// Token: 0x040092F1 RID: 37617
		public Text jumpHint;

		// Token: 0x040092F2 RID: 37618
		public GameObject goJumpLink;

		// Token: 0x040092F3 RID: 37619
		public Button link;

		// Token: 0x040092F4 RID: 37620
		public GameObject goAwake;

		// Token: 0x040092F5 RID: 37621
		public ComEffect comEffect;

		// Token: 0x040092F6 RID: 37622
		public GameObject goItemParent;

		// Token: 0x040092F7 RID: 37623
		private ComItem comAward;

		// Token: 0x040092F8 RID: 37624
		public Image bg;

		// Token: 0x040092F9 RID: 37625
		public GameObject goFinishAnimation;

		// Token: 0x040092FA RID: 37626
		[SerializeField]
		private bool willOpenDailyTodo = true;

		// Token: 0x040092FB RID: 37627
		private static string ms_empty = "empty";

		// Token: 0x040092FC RID: 37628
		private static string ms_created = "alive";

		// Token: 0x040092FD RID: 37629
		private int iId = -1;

		// Token: 0x040092FE RID: 37630
		private MissionManager.SingleMissionInfo value;

		// Token: 0x040092FF RID: 37631
		private MissionTable missionItem;

		// Token: 0x04009300 RID: 37632
		private bool m_bSelected;

		// Token: 0x04009301 RID: 37633
		public static string ms_selected_texture = "task_trace_selected_texture";

		// Token: 0x04009302 RID: 37634
		public static string ms_normal_texture = "task_trace_normal_texture";
	}
}
