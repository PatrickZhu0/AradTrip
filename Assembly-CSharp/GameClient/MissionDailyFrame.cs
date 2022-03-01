using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017AA RID: 6058
	internal class MissionDailyFrame : ClientFrame
	{
		// Token: 0x0600EED7 RID: 61143 RVA: 0x00402030 File Offset: 0x00400430
		public static bool IsOpened()
		{
			bool result = false;
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(10, string.Empty, string.Empty);
			if (tableItem == null || tableItem.FinishLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600EED8 RID: 61144 RVA: 0x00402074 File Offset: 0x00400474
		public static bool CheckRedPoint()
		{
			return DailyMissionList.HasFinishedDailyTask() || MissionDailyFrame.GetChestRedPoint() > 0;
		}

		// Token: 0x0600EED9 RID: 61145 RVA: 0x0040208B File Offset: 0x0040048B
		public static int GetRedPointCount()
		{
			return DailyMissionList.GetFinishedDailyTask() + MissionDailyFrame.GetChestRedPoint();
		}

		// Token: 0x0600EEDA RID: 61146 RVA: 0x00402098 File Offset: 0x00400498
		public static int GetChestRedPoint()
		{
			List<MissionManager.MissionScoreData> missionScoreDatas = DataManager<MissionManager>.GetInstance().MissionScoreDatas;
			int num = 0;
			for (int i = 0; i < missionScoreDatas.Count; i++)
			{
				if (missionScoreDatas[i].missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && !DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(missionScoreDatas[i].missionScoreItem.ID))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600EEDB RID: 61147 RVA: 0x00402113 File Offset: 0x00400513
		public static void BindGlobalListener()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			Delegate onLevelChanged = instance.onLevelChanged;
			if (MissionDailyFrame.<>f__mg$cache0 == null)
			{
				MissionDailyFrame.<>f__mg$cache0 = new PlayerBaseData.OnLevelChanged(MissionDailyFrame.LevelChanged);
			}
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(onLevelChanged, MissionDailyFrame.<>f__mg$cache0);
		}

		// Token: 0x0600EEDC RID: 61148 RVA: 0x0040214C File Offset: 0x0040054C
		public static void UnBindGlobalListener()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			Delegate onLevelChanged = instance.onLevelChanged;
			if (MissionDailyFrame.<>f__mg$cache1 == null)
			{
				MissionDailyFrame.<>f__mg$cache1 = new PlayerBaseData.OnLevelChanged(MissionDailyFrame.LevelChanged);
			}
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(onLevelChanged, MissionDailyFrame.<>f__mg$cache1);
		}

		// Token: 0x0600EEDD RID: 61149 RVA: 0x00402185 File Offset: 0x00400585
		public static void LevelChanged(int iPre, int iCur)
		{
			if (MissionDailyFrame.onVisibleChanged != null)
			{
				MissionDailyFrame.onVisibleChanged(MissionDailyFrame.IsOpened());
			}
		}

		// Token: 0x0600EEDE RID: 61150 RVA: 0x004021A0 File Offset: 0x004005A0
		public static MissionDailyFrame Open(MissionDailyFrame.OnRedPointChanged onRedPointChanged, GameObject goParent)
		{
			MissionDailyFrame result = null;
			MissionDailyFrameData userData = new MissionDailyFrameData
			{
				onRedPointChanged = onRedPointChanged
			};
			IClientFrame clientFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<MissionDailyFrame>(goParent, userData, string.Empty);
			if (clientFrame != null)
			{
				result = (clientFrame as MissionDailyFrame);
			}
			return result;
		}

		// Token: 0x0600EEDF RID: 61151 RVA: 0x004021DE File Offset: 0x004005DE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mission/MissionDailyFrame";
		}

		// Token: 0x0600EEE0 RID: 61152 RVA: 0x004021E5 File Offset: 0x004005E5
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<MissionDailyFrame>(this, false);
		}

		// Token: 0x0600EEE1 RID: 61153 RVA: 0x004021F4 File Offset: 0x004005F4
		protected override void _OnOpenFrame()
		{
			this.onRedPointChanged = (this.userData as MissionDailyFrameData).onRedPointChanged;
			this.m_kDailyMissionList.Initialize(this, Utility.FindChild(this.frame, "DailyContent"), new DailyMissionList.OnRedPointChanged(this._CheckDailyMission));
			this._LoadMissionScoreItems();
			this._UpdateMissionScore();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDailyScoreChanged = (MissionManager.OnDailyScoreChanged)Delegate.Combine(instance.onDailyScoreChanged, new MissionManager.OnDailyScoreChanged(this.OnDailyScoreChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Combine(instance2.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this.OnChestIdsChanged));
		}

		// Token: 0x0600EEE2 RID: 61154 RVA: 0x00402297 File Offset: 0x00400697
		private void _CheckDailyMission(bool bCheck)
		{
			if (this.onRedPointChanged != null)
			{
				this.onRedPointChanged(bCheck);
			}
		}

		// Token: 0x0600EEE3 RID: 61155 RVA: 0x004022B0 File Offset: 0x004006B0
		protected override void _OnCloseFrame()
		{
			this.onRedPointChanged = null;
			this.m_kDailyMissionList.UnInitialize();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDailyScoreChanged = (MissionManager.OnDailyScoreChanged)Delegate.Remove(instance.onDailyScoreChanged, new MissionManager.OnDailyScoreChanged(this.OnDailyScoreChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Remove(instance2.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this.OnChestIdsChanged));
			this.m_akMissionScoreItems.DestroyAllObjects();
			this.goMissionScoreItemParent = null;
		}

		// Token: 0x0600EEE4 RID: 61156 RVA: 0x00402330 File Offset: 0x00400730
		private int _SortedItem(MissionManager.SingleMissionInfo left, MissionManager.SingleMissionInfo right)
		{
			if (left.status != right.status)
			{
				if (left.status == 5)
				{
					return 1;
				}
				if (right.status == 5)
				{
					return -1;
				}
				return (int)(right.status - left.status);
			}
			else
			{
				if (left.missionItem.SortID != right.missionItem.SortID)
				{
					return left.missionItem.SortID - right.missionItem.SortID;
				}
				if (left.taskID != right.taskID)
				{
					return (left.taskID >= right.taskID) ? 1 : -1;
				}
				return 0;
			}
		}

		// Token: 0x0600EEE5 RID: 61157 RVA: 0x004023D8 File Offset: 0x004007D8
		private void _LoadMissionScoreItems()
		{
			if (this.goMissionScoreItemParent == null)
			{
				this.goMissionScoreItemParent = Utility.FindChild(this.frame, "ScoreBar");
			}
			this.m_akMissionScoreItems.RecycleAllObject();
			List<MissionManager.MissionScoreData> missionScoreDatas = DataManager<MissionManager>.GetInstance().MissionScoreDatas;
			for (int i = 0; i < missionScoreDatas.Count; i++)
			{
				GameObject gameObject = Utility.FindChild(this.frame, "ScoreBar/Item_" + i);
				MissionDailyFrame.MissionScoreItem missionScoreItem = this.m_akMissionScoreItems.Create(missionScoreDatas[i].missionScoreItem.ID, new object[]
				{
					this.goMissionScoreItemParent,
					gameObject,
					missionScoreDatas[i],
					this
				});
				if (missionScoreItem != null)
				{
					missionScoreItem.SetAsLastSibling();
				}
			}
		}

		// Token: 0x0600EEE6 RID: 61158 RVA: 0x004024A0 File Offset: 0x004008A0
		private void _UpdateMissionScore()
		{
			this.m_kScore.Value = DataManager<MissionManager>.GetInstance().Score;
			float num = (float)DataManager<MissionManager>.GetInstance().Score * 1f / (float)DataManager<MissionManager>.GetInstance().MaxScore;
			num = Mathf.Clamp01(num);
			this.m_kSlider.value = num;
		}

		// Token: 0x0600EEE7 RID: 61159 RVA: 0x004024F3 File Offset: 0x004008F3
		private void OnDailyScoreChanged(int score)
		{
			this._UpdateMissionScore();
			this.m_akMissionScoreItems.RefreshAllObjects(null);
			this._CheckDailyMission(this.m_kDailyMissionList.CheckRedPoint());
		}

		// Token: 0x0600EEE8 RID: 61160 RVA: 0x00402518 File Offset: 0x00400918
		private void OnChestIdsChanged()
		{
			this._UpdateMissionScore();
			this.m_akMissionScoreItems.RefreshAllObjects(null);
			this._CheckDailyMission(this.m_kDailyMissionList.CheckRedPoint());
		}

		// Token: 0x04009233 RID: 37427
		private MissionDailyFrame.OnRedPointChanged onRedPointChanged;

		// Token: 0x04009234 RID: 37428
		public static MissionDailyFrame.OnVisibleChanged onVisibleChanged;

		// Token: 0x04009235 RID: 37429
		private DailyMissionList m_kDailyMissionList = new DailyMissionList();

		// Token: 0x04009236 RID: 37430
		private CachedObjectDicManager<int, MissionDailyFrame.MissionScoreItem> m_akMissionScoreItems = new CachedObjectDicManager<int, MissionDailyFrame.MissionScoreItem>();

		// Token: 0x04009237 RID: 37431
		private GameObject goMissionScoreItemParent;

		// Token: 0x04009238 RID: 37432
		[UIControl("HYD/ImageNumber", typeof(UINumber), 0)]
		private UINumber m_kScore;

		// Token: 0x04009239 RID: 37433
		[UIControl("ScoreBar/Front", typeof(Slider), 0)]
		private Slider m_kSlider;

		// Token: 0x0400923A RID: 37434
		[CompilerGenerated]
		private static PlayerBaseData.OnLevelChanged <>f__mg$cache0;

		// Token: 0x0400923B RID: 37435
		[CompilerGenerated]
		private static PlayerBaseData.OnLevelChanged <>f__mg$cache1;

		// Token: 0x020017AB RID: 6059
		// (Invoke) Token: 0x0600EEEA RID: 61162
		public delegate void OnVisibleChanged(bool bNeedVisible);

		// Token: 0x020017AC RID: 6060
		// (Invoke) Token: 0x0600EEEE RID: 61166
		public delegate void OnRedPointChanged(bool bNeedRedPoint);

		// Token: 0x020017AD RID: 6061
		private class MissionScoreItem : CachedObject
		{
			// Token: 0x0600EEF2 RID: 61170 RVA: 0x00402548 File Offset: 0x00400948
			public override void OnDestroy()
			{
				this.goLocal = null;
				this.goPrefab = null;
				this.goParent = null;
				this.data = null;
				this.THIS = null;
				this.score = null;
				this.image = null;
				if (this.button != null)
				{
					this.button.onClick.RemoveAllListeners();
					this.button = null;
				}
				this.tween = null;
			}

			// Token: 0x0600EEF3 RID: 61171 RVA: 0x004025B8 File Offset: 0x004009B8
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.data = (param[2] as MissionManager.MissionScoreData);
				this.THIS = (param[3] as MissionFrameNew);
				if (this.goLocal == null)
				{
					this.goLocal = this.goPrefab;
					this.score = Utility.FindComponent<Text>(this.goLocal, "Label", true);
					this.image = Utility.FindComponent<Image>(this.goLocal, "Box", true);
					this.button = Utility.FindComponent<Button>(this.goLocal, "Box", true);
					this.goEffect = Utility.FindChild(this.goLocal, "Effect");
					this.tween = Utility.FindComponent<DOTweenAnimation>(this.goLocal, "Box", true);
					this.goCheck = Utility.FindChild(this.goLocal, "Check");
					this.button.onClick.RemoveAllListeners();
					this.button.onClick.AddListener(new UnityAction(this._OnOpenChest));
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x0600EEF4 RID: 61172 RVA: 0x004026DA File Offset: 0x00400ADA
			private void _OnOpenChest()
			{
				MissionScoreAwardFrame.Open(this.data.missionScoreItem.ID);
			}

			// Token: 0x0600EEF5 RID: 61173 RVA: 0x004026F1 File Offset: 0x00400AF1
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EEF6 RID: 61174 RVA: 0x00402710 File Offset: 0x00400B10
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600EEF7 RID: 61175 RVA: 0x00402719 File Offset: 0x00400B19
			public override void OnRefresh(object[] param)
			{
				if (param != null && param.Length > 0)
				{
					this.data = (param[0] as MissionManager.MissionScoreData);
				}
				this._Update();
			}

			// Token: 0x0600EEF8 RID: 61176 RVA: 0x0040273E File Offset: 0x00400B3E
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x0600EEF9 RID: 61177 RVA: 0x00402761 File Offset: 0x00400B61
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600EEFA RID: 61178 RVA: 0x00402780 File Offset: 0x00400B80
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EEFB RID: 61179 RVA: 0x0040279F File Offset: 0x00400B9F
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x17001CE2 RID: 7394
			// (get) Token: 0x0600EEFC RID: 61180 RVA: 0x004027A4 File Offset: 0x00400BA4
			public bool CanAcquire
			{
				get
				{
					return this.data.missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && !DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(this.data.missionScoreItem.ID);
				}
			}

			// Token: 0x0600EEFD RID: 61181 RVA: 0x004027F8 File Offset: 0x00400BF8
			private void _Update()
			{
				if (this.data != null)
				{
					this.score.text = this.data.missionScoreItem.Name;
					this.data.bOpen = (this.data.missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(this.data.missionScoreItem.ID));
					this.data.GetIcon(ref this.image);
					this.goEffect.CustomActive(this.data.missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && !DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(this.data.missionScoreItem.ID));
					this.goCheck.CustomActive(DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(this.data.missionScoreItem.ID));
					Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(this.goParent.transform);
					this.goLocal.transform.localPosition = new Vector3(1100f * this.data.fPostion - 4f, this.goLocal.transform.localPosition.y, 0f);
					if (this.goEffect.activeSelf)
					{
						this.tween.DOPlay();
					}
					else
					{
						this.tween.DOPause();
						this.tween.target.transform.localScale = Vector3.one;
					}
				}
			}

			// Token: 0x0400923C RID: 37436
			private GameObject goLocal;

			// Token: 0x0400923D RID: 37437
			private GameObject goPrefab;

			// Token: 0x0400923E RID: 37438
			private GameObject goParent;

			// Token: 0x0400923F RID: 37439
			private MissionManager.MissionScoreData data;

			// Token: 0x04009240 RID: 37440
			private MissionFrameNew THIS;

			// Token: 0x04009241 RID: 37441
			private DOTweenAnimation tween;

			// Token: 0x04009242 RID: 37442
			private Text score;

			// Token: 0x04009243 RID: 37443
			private Image image;

			// Token: 0x04009244 RID: 37444
			private GameObject goEffect;

			// Token: 0x04009245 RID: 37445
			private Button button;

			// Token: 0x04009246 RID: 37446
			private GameObject goCheck;
		}
	}
}
