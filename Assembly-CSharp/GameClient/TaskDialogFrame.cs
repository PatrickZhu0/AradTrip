using System;
using System.Reflection;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BFC RID: 7164
	public class TaskDialogFrame : ClientFrame
	{
		// Token: 0x17001DB7 RID: 7607
		// (get) Token: 0x060118E0 RID: 71904 RVA: 0x0051BEF4 File Offset: 0x0051A2F4
		private float RaycastInterval
		{
			get
			{
				float result = 0f;
				float.TryParse(TR.Value("task_dlg_jump_interval"), out result);
				return result;
			}
		}

		// Token: 0x060118E1 RID: 71905 RVA: 0x0051BF1A File Offset: 0x0051A31A
		public string GetObjectName()
		{
			return this.talkItem.ObjectName;
		}

		// Token: 0x060118E2 RID: 71906 RVA: 0x0051BF28 File Offset: 0x0051A328
		private void OnReset()
		{
			this.dlgId = 0;
			this.imgNpcIcon = null;
			this.talkItem = null;
			this.talkContent = null;
			this.iCurTaskId = 0;
			if (this.comSpecialFrameCreate != null)
			{
				this.comSpecialFrameCreate.OnClose();
			}
			this.bInteractable = false;
			InvokeMethod.RemoveInvokeCall(this);
			InvokeMethod.Invoke(this, this.RaycastInterval, delegate()
			{
				this.bInteractable = true;
			});
		}

		// Token: 0x060118E3 RID: 71907 RVA: 0x0051BF9C File Offset: 0x0051A39C
		public override string GetPrefabPath()
		{
			this.dlgId = DataManager<MissionManager>.GetInstance().AddKeyDlg2Frame(this);
			this.talkItem = Singleton<TableManager>.instance.GetTableItem<TalkTable>(this.dlgId, string.Empty, string.Empty);
			if (this.talkItem != null)
			{
				return this.talkItem.ObjectName;
			}
			DataManager<MissionManager>.GetInstance().RemoveDlgFrame(this.dlgId);
			Logger.LogError(string.Format("dlgId = {0} can not be found in table TalkTable!", this.dlgId));
			this.dlgId = 0;
			return string.Empty;
		}

		// Token: 0x060118E4 RID: 71908 RVA: 0x0051C028 File Offset: 0x0051A428
		protected override void _OnOpenFrame()
		{
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.TaskDialogFrameOpen, null, null, null, null);
			this.bInteractable = false;
			InvokeMethod.Invoke(this, this.RaycastInterval, delegate()
			{
				this.bInteractable = true;
			});
			if (!Singleton<NewbieGuideManager>.GetInstance().IsGuiding() || Singleton<NewbieGuideManager>.GetInstance().GetCurGuideType() == NewbieGuideComType.TALK_DIALOG)
			{
				base.SetVisible(true);
			}
			this.BindUIEvent();
			this.AttachUIObject();
			this.SetDialogUIData();
			this.onDialogOver = new TaskDialogFrame.OnDialogOver();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Dlg2TaskId, new ClientEventSystem.UIEventHandler(this.OnTaskIdChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DlgCallBack, new ClientEventSystem.UIEventHandler(this.OnAddCallBack));
		}

		// Token: 0x060118E5 RID: 71909 RVA: 0x0051C0E5 File Offset: 0x0051A4E5
		private void OnTaskIdChanged(UIEvent uiEvent)
		{
			this.iCurTaskId = uiEvent.EventParams.taskData.taskID;
			this.SetDialogUIData();
		}

		// Token: 0x060118E6 RID: 71910 RVA: 0x0051C104 File Offset: 0x0051A504
		private void OnAddCallBack(UIEvent uiEvent)
		{
			UIEventDialogCallBack uieventDialogCallBack = uiEvent as UIEventDialogCallBack;
			if (uieventDialogCallBack != null)
			{
				this.onDialogOver = uieventDialogCallBack.callback;
			}
		}

		// Token: 0x060118E7 RID: 71911 RVA: 0x0051C12C File Offset: 0x0051A52C
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			InvokeMethod.RemoveInvokeCall(this);
			DataManager<MissionManager>.GetInstance().RemoveDlgFrame(this.dlgId);
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Dlg2TaskId, new ClientEventSystem.UIEventHandler(this.OnTaskIdChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DlgCallBack, new ClientEventSystem.UIEventHandler(this.OnAddCallBack));
			if (this.goAnimation != null)
			{
				Object.Destroy(this.goAnimation);
				this.goAnimation = null;
			}
			this.comAnimation = null;
			if (this.onDialogOver != null)
			{
				this.onDialogOver = null;
			}
			if (this.comSpecialFrameCreate != null)
			{
				this.comSpecialFrameCreate.OnClose();
				this.comSpecialFrameCreate = null;
			}
		}

		// Token: 0x060118E8 RID: 71912 RVA: 0x0051C1EA File Offset: 0x0051A5EA
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
		}

		// Token: 0x060118E9 RID: 71913 RVA: 0x0051C222 File Offset: 0x0051A622
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideFinish));
		}

		// Token: 0x060118EA RID: 71914 RVA: 0x0051C25A File Offset: 0x0051A65A
		private void OnNewbieGuideStart(UIEvent uiEvent)
		{
			if (Singleton<NewbieGuideManager>.GetInstance().IsGuiding() && Singleton<NewbieGuideManager>.GetInstance().GetCurGuideType() != NewbieGuideComType.TALK_DIALOG)
			{
				base.SetVisible(false);
			}
		}

		// Token: 0x060118EB RID: 71915 RVA: 0x0051C282 File Offset: 0x0051A682
		private void OnNewbieGuideFinish(UIEvent uiEvent)
		{
			base.SetVisible(true);
		}

		// Token: 0x060118EC RID: 71916 RVA: 0x0051C28C File Offset: 0x0051A68C
		private void AttachUIObject()
		{
			this.npcName = this.frame.transform.Find("BackGround").transform.Find("NpcName").GetComponent<Text>();
			this.talkContent = this.frame.transform.Find("BackGround").transform.Find("Talk").GetComponent<Text>();
			this.imgNpcIcon = this.frame.transform.Find("BackGround").transform.Find("NpcPic").GetComponent<Image>();
			this.goNpcAnimationParent = Utility.FindChild(this.frame, "NpcAnimation");
			this.taskName = Utility.FindComponent<Text>(this.frame, "TaskName", true);
			this.comSpecialFrameCreate = Utility.FindComponent<UISpecialFrameCreate>(this.frame, "SpecialFrameRoot", true);
		}

		// Token: 0x060118ED RID: 71917 RVA: 0x0051C36C File Offset: 0x0051A76C
		private void SetDialogUIData()
		{
			NpcTable tableItem = Singleton<TableManager>.instance.GetTableItem<NpcTable>(this.talkItem.NpcID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.imgNpcIcon.sprite = null;
				ETCImageLoader.LoadSprite(ref this.imgNpcIcon, tableItem.NpcBody, true);
				this.imgNpcIcon.SetNativeSize();
				this.imgNpcIcon.gameObject.CustomActive(this.imgNpcIcon.sprite != null);
			}
			if (this.goAnimation != null)
			{
				Object.Destroy(this.goAnimation);
				this.goAnimation = null;
			}
			this.comAnimation = null;
			if (this.imgNpcIcon.sprite == null)
			{
				this.imgNpcIcon.gameObject.CustomActive(false);
				this.goAnimation = Singleton<AssetLoader>.instance.LoadResAsGameObject(tableItem.NpcBody, true, 0U);
				if (this.goAnimation != null)
				{
					Utility.AttachTo(this.goAnimation, this.goNpcAnimationParent, false);
					if (this.goAnimation.transform.childCount > 0)
					{
						this.comAnimation = this.goAnimation.transform.GetChild(0).GetComponent<Animation>();
						if (this.comAnimation != null && !this.comAnimation.isPlaying)
						{
							this.comAnimation.Play();
						}
					}
				}
			}
			if (this.taskName != null)
			{
				this.taskName.gameObject.CustomActive(false);
			}
			MissionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.iCurTaskId, string.Empty, string.Empty);
			if (Singleton<TableManager>.instance.GetTableItem<TalkTable>(this.talkItem.NextID, string.Empty, string.Empty) == null && this.taskName != null && tableItem2 != null)
			{
				this.taskName.text = tableItem2.TaskName;
				this.taskName.gameObject.CustomActive(true);
			}
			if (this.talkItem != null && this.comSpecialFrameCreate != null && tableItem2 != null)
			{
				this.comSpecialFrameCreate.Param0 = tableItem2.ID.ToString();
				this.comSpecialFrameCreate.ClsName = this.talkItem.AttachClassName;
			}
			if (this.npcName != null && tableItem != null)
			{
				this.npcName.text = tableItem.NpcName.Replace("[UserName]", DataManager<PlayerBaseData>.GetInstance().Name);
			}
			if (this.talkContent != null)
			{
				this.talkContent.text = this.talkItem.TalkText.Replace("[UserName]", DataManager<PlayerBaseData>.GetInstance().Name);
			}
			if (this.talkItem != null && this.talkItem.NpcID == 2056 && this.imgNpcIcon != null)
			{
				JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
				this.imgNpcIcon.sprite = null;
				if (tableItem3 != null)
				{
					ResTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem3.Mode, string.Empty, string.Empty);
					if (tableItem4 != null)
					{
						ETCImageLoader.LoadSprite(ref this.imgNpcIcon, tableItem3.JobHalfBody, true);
					}
				}
				this.imgNpcIcon.SetNativeSize();
				this.imgNpcIcon.gameObject.CustomActive(this.imgNpcIcon.sprite != null);
			}
			int num = this._CheckNextStepCount(this.talkItem.NextID);
			if (num > 0)
			{
				this.frame.transform.Find("BtnNext").gameObject.SetActive(true);
				this.frame.transform.Find("BtnComplete").gameObject.SetActive(false);
				this.frame.transform.Find("BtnStepOver").gameObject.SetActive(num > 1);
			}
			else
			{
				this.frame.transform.Find("BtnNext").gameObject.SetActive(false);
				GameObject gameObject = this.frame.transform.Find("BtnComplete").gameObject;
				gameObject.SetActive(true);
				bool flag = this.talkItem.TakeFinish == 0;
				if (flag)
				{
					Utility.SetChildTextContent(gameObject.transform, "Text", "接受", true);
				}
				else
				{
					Utility.SetChildTextContent(gameObject.transform, "Text", "完成", true);
				}
				this.frame.transform.Find("BtnStepOver").gameObject.SetActive(false);
			}
		}

		// Token: 0x060118EE RID: 71918 RVA: 0x0051C83C File Offset: 0x0051AC3C
		[UIEventHandle("BtnNext")]
		private void OnClickNext()
		{
			if (!this.bInteractable)
			{
				return;
			}
			if (this.talkItem != null)
			{
				if (this.talkItem.ID == this.talkItem.NextID)
				{
					Singleton<GameStatisticManager>.GetInstance().DoStatDialog(this.talkItem.ID, this.talkItem.NextID, GameStatisticManager.DialogOperateType.DOT_NEXT, GameStatisticManager.DialogFinishType.DFT_FINISH);
					this.OnStepOver(this.talkItem);
					this.frameMgr.CloseFrame<TaskDialogFrame>(this, false);
					Logger.LogError("talkItem.ID == talkItem.NextID ?");
					return;
				}
				TalkTable tableItem = Singleton<TableManager>.instance.GetTableItem<TalkTable>(this.talkItem.NextID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					TaskDialogFrame dlgFrameByName = DataManager<MissionManager>.GetInstance().GetDlgFrameByName(tableItem.ObjectName);
					if (dlgFrameByName != null)
					{
						Singleton<GameStatisticManager>.GetInstance().DoStatDialog(this.talkItem.ID, this.talkItem.NextID, GameStatisticManager.DialogOperateType.DOT_NEXT, GameStatisticManager.DialogFinishType.DFT_RESTAR);
						dlgFrameByName.OnRestart(tableItem, this.iCurTaskId);
					}
					else
					{
						Singleton<GameStatisticManager>.GetInstance().DoStatDialog(this.talkItem.ID, this.talkItem.NextID, GameStatisticManager.DialogOperateType.DOT_NEXT, GameStatisticManager.DialogFinishType.DFT_NEWCREATE);
						DataManager<MissionManager>.GetInstance().CreateDialogFrame(this.talkItem.NextID, this.iCurTaskId, this.onDialogOver);
					}
				}
				else
				{
					Singleton<GameStatisticManager>.GetInstance().DoStatDialog(this.talkItem.ID, this.talkItem.NextID, GameStatisticManager.DialogOperateType.DOT_NEXT, GameStatisticManager.DialogFinishType.DFT_FINISH);
					this.OnStepOver(this.talkItem);
					GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.FinishTalkDialog, this.dlgId, null, null, null);
					this.frameMgr.CloseFrame<TaskDialogFrame>(this, false);
				}
			}
			else
			{
				Logger.LogError("talkItem == null ? how this happened?");
			}
		}

		// Token: 0x060118EF RID: 71919 RVA: 0x0051C9E2 File Offset: 0x0051ADE2
		public void OnClose()
		{
			this.frameMgr.CloseFrame<TaskDialogFrame>(this, false);
		}

		// Token: 0x060118F0 RID: 71920 RVA: 0x0051C9F1 File Offset: 0x0051ADF1
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060118F1 RID: 71921 RVA: 0x0051C9F4 File Offset: 0x0051ADF4
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.comAnimation != null && !this.comAnimation.isPlaying)
			{
				this.comAnimation.Play();
			}
		}

		// Token: 0x060118F2 RID: 71922 RVA: 0x0051CA24 File Offset: 0x0051AE24
		private void OnStepOver(TalkTable item)
		{
			if (this.onDialogOver != null)
			{
				this.onDialogOver.Invoke();
				this.onDialogOver.RemoveAllListeners();
				this.onDialogOver = null;
			}
			if (!string.IsNullOrEmpty(item.FrameClassName))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = string.Format("GameClient.{0}", item.FrameClassName);
				Type type = executingAssembly.GetType(name);
				if (type != null)
				{
					MethodInfo method = type.GetMethod("Open", BindingFlags.Static | BindingFlags.Public);
					if (method != null)
					{
						method.Invoke(null, null);
					}
				}
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.iCurTaskId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.iCurTaskId != item.MissionID)
			{
			}
			bool flag = item.TakeFinish == 0;
			if (flag)
			{
				DataManager<MissionManager>.GetInstance().OnExecuteAcceptTask(this.iCurTaskId, false, null, null, false);
			}
			else if (Utility.IsNormalMission((uint)this.iCurTaskId))
			{
				MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)this.iCurTaskId);
				if (mission != null)
				{
					if (mission.status == 2)
					{
						DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.iCurTaskId, (TaskSubmitType)tableItem.FinishType, (uint)tableItem.MissionFinishNpc);
					}
					else if (mission.status == 0)
					{
						DataManager<MissionManager>.GetInstance().OnExecuteAcceptTask(this.iCurTaskId, false, null, null, false);
					}
				}
			}
		}

		// Token: 0x060118F3 RID: 71923 RVA: 0x0051CB84 File Offset: 0x0051AF84
		[UIEventHandle("BtnStepOver")]
		private void OnClickStepOver()
		{
			if (!this.bInteractable)
			{
				return;
			}
			Singleton<GameStatisticManager>.GetInstance().DoStatDialog(this.talkItem.ID, 0, GameStatisticManager.DialogOperateType.DOT_JUMPOVER, GameStatisticManager.DialogFinishType.DFT_FINISH);
			this.OnStepOver(this.talkItem);
			this.frameMgr.CloseFrame<TaskDialogFrame>(this, false);
		}

		// Token: 0x060118F4 RID: 71924 RVA: 0x0051CBC3 File Offset: 0x0051AFC3
		[UIEventHandle("BtnComplete")]
		private void OnClickComplete()
		{
			Singleton<GameStatisticManager>.GetInstance().DoStatDialog(this.talkItem.ID, 0, GameStatisticManager.DialogOperateType.DOT_COMPLETE, GameStatisticManager.DialogFinishType.DFT_FINISH);
			this.OnClickNext();
		}

		// Token: 0x060118F5 RID: 71925 RVA: 0x0051CBE4 File Offset: 0x0051AFE4
		private int _CheckNextStepCount(int iNextTalkID)
		{
			int num = 0;
			TalkTable tableItem = Singleton<TableManager>.instance.GetTableItem<TalkTable>(iNextTalkID, string.Empty, string.Empty);
			while (tableItem != null)
			{
				num++;
				tableItem = Singleton<TableManager>.instance.GetTableItem<TalkTable>(tableItem.NextID, string.Empty, string.Empty);
				if (num > 100000)
				{
					Logger.LogErrorFormat("[TalkTable]填表错误，NextID与ID填写重复，造成死循环。让孙茂园检查！对话起始id:{0},that is to say a->next is b b->next is c then c->next is a death loop!", new object[]
					{
						iNextTalkID
					});
					num = 1;
					break;
				}
			}
			return num;
		}

		// Token: 0x060118F6 RID: 71926 RVA: 0x0051CC60 File Offset: 0x0051B060
		private void _GoNextNStep(int iGoTimes)
		{
			TalkTable talkTable = this.talkItem;
			TalkTable tableItem = this.talkItem;
			while (iGoTimes > 0)
			{
				if (this.talkItem == null)
				{
					break;
				}
				if (this.talkItem.ID == this.talkItem.NextID)
				{
					Logger.LogError("talkItem.ID == talkItem.NextID ?");
					break;
				}
				talkTable = tableItem;
				tableItem = Singleton<TableManager>.instance.GetTableItem<TalkTable>(tableItem.NextID, string.Empty, string.Empty);
				iGoTimes--;
			}
			if (tableItem.ObjectName != talkTable.ObjectName)
			{
				TaskDialogFrame dlgFrameByName = DataManager<MissionManager>.GetInstance().GetDlgFrameByName(talkTable.ObjectName);
				if (dlgFrameByName != null)
				{
					dlgFrameByName.OnRestart(talkTable, this.iCurTaskId);
				}
				else
				{
					DataManager<MissionManager>.GetInstance().CreateDialogFrame(talkTable.ID, this.iCurTaskId, this.onDialogOver);
				}
			}
			TaskDialogFrame dlgFrameByName2 = DataManager<MissionManager>.GetInstance().GetDlgFrameByName(tableItem.ObjectName);
			if (dlgFrameByName2 != null)
			{
				dlgFrameByName2.OnRestart(tableItem, this.iCurTaskId);
			}
			else
			{
				DataManager<MissionManager>.GetInstance().CreateDialogFrame(tableItem.ID, this.iCurTaskId, this.onDialogOver);
			}
		}

		// Token: 0x060118F7 RID: 71927 RVA: 0x0051CD8A File Offset: 0x0051B18A
		public void OnRestart(TalkTable talkItem, int iCurTaskId)
		{
			this.OnReset();
			this.iCurTaskId = iCurTaskId;
			this.dlgId = talkItem.ID;
			this.talkItem = talkItem;
			this.AttachUIObject();
			this.SetDialogUIData();
		}

		// Token: 0x0400B6A4 RID: 46756
		private int dlgId;

		// Token: 0x0400B6A5 RID: 46757
		private Image imgNpcIcon;

		// Token: 0x0400B6A6 RID: 46758
		private GameObject goNpcAnimationParent;

		// Token: 0x0400B6A7 RID: 46759
		private GameObject goAnimation;

		// Token: 0x0400B6A8 RID: 46760
		private Animation comAnimation;

		// Token: 0x0400B6A9 RID: 46761
		private TalkTable talkItem;

		// Token: 0x0400B6AA RID: 46762
		private Text npcName;

		// Token: 0x0400B6AB RID: 46763
		private Text talkContent;

		// Token: 0x0400B6AC RID: 46764
		private int iCurTaskId;

		// Token: 0x0400B6AD RID: 46765
		private Text taskName;

		// Token: 0x0400B6AE RID: 46766
		private UISpecialFrameCreate comSpecialFrameCreate;

		// Token: 0x0400B6AF RID: 46767
		private TaskDialogFrame.OnDialogOver onDialogOver;

		// Token: 0x0400B6B0 RID: 46768
		private bool bInteractable;

		// Token: 0x02001BFD RID: 7165
		public class OnDialogOver : UnityEvent
		{
			// Token: 0x060118FB RID: 71931 RVA: 0x0051CDD2 File Offset: 0x0051B1D2
			public TaskDialogFrame.OnDialogOver AddListener(UnityAction callback)
			{
				base.AddListener(callback);
				return this;
			}
		}
	}
}
