using System;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017AE RID: 6062
	internal class MissionDungenFrame : ClientFrame
	{
		// Token: 0x0600EEFF RID: 61183 RVA: 0x004029B4 File Offset: 0x00400DB4
		protected override void _bindExUI()
		{
			this.mBtn_Open = this.mBind.GetCom<Button>("Btn_Open");
			if (null != this.mBtn_Open)
			{
				this.mBtn_Open.onClick.AddListener(new UnityAction(this._onBtn_OpenButtonClick));
			}
			this.mDoTween = this.mBind.GetCom<DOTweenAnimation>("DoTween");
			this.mGo_Mask = this.mBind.GetGameObject("Go_Mask");
		}

		// Token: 0x0600EF00 RID: 61184 RVA: 0x00402A30 File Offset: 0x00400E30
		protected override void _unbindExUI()
		{
			if (null != this.mBtn_Open)
			{
				this.mBtn_Open.onClick.RemoveListener(new UnityAction(this._onBtn_OpenButtonClick));
			}
			this.mBtn_Open = null;
			this.mDoTween = null;
			this.mGo_Mask = null;
		}

		// Token: 0x0600EF01 RID: 61185 RVA: 0x00402A7F File Offset: 0x00400E7F
		private void _onBtn_OpenButtonClick()
		{
			this._Move(!this.isOpen);
		}

		// Token: 0x0600EF02 RID: 61186 RVA: 0x00402A90 File Offset: 0x00400E90
		public static void Open()
		{
			if (ClientSystem.IsTargetSystem<ClientSystemBattle>() && !Singleton<ClientSystemManager>.instance.IsFrameOpen<MissionDungenFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<MissionDungenFrame>(FrameLayer.Bottom, null, string.Empty);
			}
		}

		// Token: 0x0600EF03 RID: 61187 RVA: 0x00402ABE File Offset: 0x00400EBE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mission/MissionDungenTrace";
		}

		// Token: 0x0600EF04 RID: 61188 RVA: 0x00402AC8 File Offset: 0x00400EC8
		protected override void _OnOpenFrame()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
			this._InitMissionTraceObjects();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ClientBattleMainFadeInFadeOut, new ClientEventSystem.UIEventHandler(this._onFadeInFadeOut));
			this.m_bStatus = false;
			this.m_bStateIsIn = false;
			this._RecreateAllTraceObjects();
		}

		// Token: 0x0600EF05 RID: 61189 RVA: 0x00402B7C File Offset: 0x00400F7C
		private void _onFadeInFadeOut(UIEvent ui)
		{
			bool bIn = (bool)ui.Param1;
			this._Move(bIn);
		}

		// Token: 0x0600EF06 RID: 61190 RVA: 0x00402B9C File Offset: 0x00400F9C
		public void Move(bool isOpen)
		{
			this._Move(isOpen);
		}

		// Token: 0x0600EF07 RID: 61191 RVA: 0x00402BA8 File Offset: 0x00400FA8
		private void _Move(bool bIn)
		{
			if (this.m_bStateIsIn == bIn)
			{
				return;
			}
			this.m_bStateIsIn = bIn;
			if (this.mGo_Mask != null)
			{
				this.mGo_Mask.CustomActive(true);
			}
			if (!bIn)
			{
				if (this.mDoTween != null)
				{
					this.mDoTween.DOPlayById("MoveOut");
				}
			}
			else if (this.mDoTween != null)
			{
				this.mDoTween.DORewind();
				this.mDoTween.DOPlayById("MoveIn");
			}
			this.isOpen = bIn;
			List<int> missionDungenTraceList = DataManager<MissionManager>.GetInstance().GetMissionDungenTraceList();
			bool flag = missionDungenTraceList != null && missionDungenTraceList.Count > 0;
			this.m_bStatus = bIn;
			InvokeMethod.Invoke(this, 0.5f, delegate()
			{
				if (this.mGo_Mask != null)
				{
					this.mGo_Mask.CustomActive(false);
				}
				this.m_bStatus = !bIn;
			});
		}

		// Token: 0x0600EF08 RID: 61192 RVA: 0x00402CB0 File Offset: 0x004010B0
		protected override void _OnCloseFrame()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ClientBattleMainFadeInFadeOut, new ClientEventSystem.UIEventHandler(this._onFadeInFadeOut));
			this.m_akMissionTraceObjects.Clear();
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x0600EF09 RID: 61193 RVA: 0x00402D5B File Offset: 0x0040115B
		private void _InitMissionTraceObjects()
		{
			this.m_goMissionParent = Utility.FindChild(this.frame, "MissionDungenTrace/ScrollView/ViewPort/Content");
			this.m_goMissionPrefab = Utility.FindChild(this.m_goMissionParent, "Prefab");
			this.m_goMissionPrefab.CustomActive(false);
		}

		// Token: 0x0600EF0A RID: 61194 RVA: 0x00402D95 File Offset: 0x00401195
		private void OnAddNewMission(uint iTaskID)
		{
			this._OnUpdateMission(iTaskID);
		}

		// Token: 0x0600EF0B RID: 61195 RVA: 0x00402D9E File Offset: 0x0040119E
		private void OnUpdateMission(uint iTaskID)
		{
			this._OnUpdateMission(iTaskID);
		}

		// Token: 0x0600EF0C RID: 61196 RVA: 0x00402DA7 File Offset: 0x004011A7
		private void OnDeleteMission(uint iTaskID)
		{
			this._OnUpdateMission(iTaskID);
		}

		// Token: 0x0600EF0D RID: 61197 RVA: 0x00402DB0 File Offset: 0x004011B0
		private void _OnUpdateMission(uint iTaskID)
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iTaskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.TaskType != MissionTable.eTaskType.TT_MAIN && tableItem.TaskType != MissionTable.eTaskType.TT_BRANCH && tableItem.TaskType != MissionTable.eTaskType.TT_CYCLE && tableItem.TaskType != MissionTable.eTaskType.TT_CHANGEJOB && tableItem.TaskType != MissionTable.eTaskType.TT_AWAKEN && tableItem.TaskType != MissionTable.eTaskType.TT_TITLE)
			{
				return;
			}
			this._RecreateAllTraceObjects();
		}

		// Token: 0x0600EF0E RID: 61198 RVA: 0x00402E2C File Offset: 0x0040122C
		private void _RecreateAllTraceObjects()
		{
			this.m_akMissionTraceObjects.RecycleAllObject();
			List<int> missionDungenTraceList = DataManager<MissionManager>.GetInstance().GetMissionDungenTraceList();
			if (missionDungenTraceList != null && missionDungenTraceList.Count > 0)
			{
				for (int i = 0; i < missionDungenTraceList.Count; i++)
				{
					this.m_akMissionTraceObjects.Create(new object[]
					{
						this.m_goMissionParent,
						this.m_goMissionPrefab,
						missionDungenTraceList[i],
						this
					});
				}
			}
		}

		// Token: 0x04009247 RID: 37447
		private Button mBtn_Open;

		// Token: 0x04009248 RID: 37448
		private DOTweenAnimation mDoTween;

		// Token: 0x04009249 RID: 37449
		private GameObject mGo_Mask;

		// Token: 0x0400924A RID: 37450
		private bool isOpen;

		// Token: 0x0400924B RID: 37451
		private bool m_bStateIsIn;

		// Token: 0x0400924C RID: 37452
		private bool m_bStatus;

		// Token: 0x0400924D RID: 37453
		private GameObject m_goMissionParent;

		// Token: 0x0400924E RID: 37454
		private GameObject m_goMissionPrefab;

		// Token: 0x0400924F RID: 37455
		private CachedObjectListManager<MissionDungenFrame.MissionTraceObject> m_akMissionTraceObjects = new CachedObjectListManager<MissionDungenFrame.MissionTraceObject>();

		// Token: 0x020017AF RID: 6063
		private class MissionTraceObject : CachedObject
		{
			// Token: 0x0600EF10 RID: 61200 RVA: 0x00402EBC File Offset: 0x004012BC
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.iId = (int)param[2];
				this.THIS = (param[3] as MissionDungenFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.content = Utility.FindComponent<LinkParse>(this.goLocal, "ScrollView/ViewPort/Content", true);
					this.name = Utility.FindComponent<Text>(this.goLocal, "Horizen/Name", true);
					this.icon = Utility.FindComponent<Image>(this.goLocal, "Horizen/Icon", true);
					this.link = this.goLocal.GetComponent<Button>();
				}
				this.Enable();
				this.SetAsLastSibling();
				this._Update();
			}

			// Token: 0x0600EF11 RID: 61201 RVA: 0x00402F9D File Offset: 0x0040139D
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EF12 RID: 61202 RVA: 0x00402FBC File Offset: 0x004013BC
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600EF13 RID: 61203 RVA: 0x00402FC5 File Offset: 0x004013C5
			public override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x0600EF14 RID: 61204 RVA: 0x00402FCD File Offset: 0x004013CD
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsFirstSibling();
				}
			}

			// Token: 0x0600EF15 RID: 61205 RVA: 0x00402FF0 File Offset: 0x004013F0
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600EF16 RID: 61206 RVA: 0x0040300F File Offset: 0x0040140F
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EF17 RID: 61207 RVA: 0x0040302E File Offset: 0x0040142E
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600EF18 RID: 61208 RVA: 0x00403034 File Offset: 0x00401434
			private void _Update()
			{
				if (this.iId != 0)
				{
					this.missionItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.iId, string.Empty, string.Empty);
					DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)this.iId, out this.value);
					if (this.value != null)
					{
						ETCImageLoader.LoadSprite(ref this.icon, Utility.GetMissionIcon(this.value.missionItem.TaskType), true);
						this.name.text = DataManager<MissionManager>.GetInstance().GetMissionName((uint)this.missionItem.ID) + DataManager<MissionManager>.GetInstance().GetMissionNameAppendBystatus((int)this.value.status, this.value.missionItem.ID);
						if (this.content != null)
						{
							this.content.SetText(Utility.ParseMissionText(this.iId, true, false, false), true);
						}
						if (this.link != null)
						{
							this.link.onClick.RemoveAllListeners();
						}
					}
				}
			}

			// Token: 0x04009250 RID: 37456
			private GameObject goLocal;

			// Token: 0x04009251 RID: 37457
			private GameObject goPrefab;

			// Token: 0x04009252 RID: 37458
			private GameObject goParent;

			// Token: 0x04009253 RID: 37459
			private int iId;

			// Token: 0x04009254 RID: 37460
			private MissionDungenFrame THIS;

			// Token: 0x04009255 RID: 37461
			private LinkParse content;

			// Token: 0x04009256 RID: 37462
			private Text name;

			// Token: 0x04009257 RID: 37463
			private Image icon;

			// Token: 0x04009258 RID: 37464
			private Button link;

			// Token: 0x04009259 RID: 37465
			private MissionManager.SingleMissionInfo value;

			// Token: 0x0400925A RID: 37466
			private MissionTable missionItem;
		}
	}
}
