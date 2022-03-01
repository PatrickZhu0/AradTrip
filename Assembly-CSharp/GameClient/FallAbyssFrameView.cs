using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015DB RID: 5595
	public class FallAbyssFrameView : MonoBehaviour
	{
		// Token: 0x0600DB2C RID: 56108 RVA: 0x00373993 File Offset: 0x00371D93
		private void Awake()
		{
			this.InitData();
			this.BindUiMessages();
		}

		// Token: 0x0600DB2D RID: 56109 RVA: 0x003739A1 File Offset: 0x00371DA1
		private void OnDestroy()
		{
			this.ClearData();
			this.UnBindUiMessages();
		}

		// Token: 0x0600DB2E RID: 56110 RVA: 0x003739AF File Offset: 0x00371DAF
		private void InitData()
		{
			if (this._chapterIdList == null)
			{
				this._chapterIdList = new List<int>();
			}
			if (this._mapItemList == null)
			{
				this._mapItemList = new List<ChallengeMapItem>();
			}
		}

		// Token: 0x0600DB2F RID: 56111 RVA: 0x003739E0 File Offset: 0x00371DE0
		private void ClearData()
		{
			this._chapterData = null;
			this._activityDungeonSubList = null;
			if (this._mapItemList != null)
			{
				this._mapItemList.Clear();
				this._mapItemList = null;
			}
			if (this._chapterIdList != null)
			{
				this._chapterIdList.Clear();
				this._chapterIdList = null;
			}
			this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnNone;
			this._delayOpenFrameCoroutine = null;
			this._chapterFrameCloseCoroutine = null;
			this._chapterFrameChangeCoroutine = null;
		}

		// Token: 0x0600DB30 RID: 56112 RVA: 0x00373A51 File Offset: 0x00371E51
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityDungeonUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityDungeonUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnChallengeChapterFrameClose, new ClientEventSystem.UIEventHandler(this.OnChallengeChapterFrameClose));
		}

		// Token: 0x0600DB31 RID: 56113 RVA: 0x00373A89 File Offset: 0x00371E89
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityDungeonUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityDungeonUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnChallengeChapterFrameClose, new ClientEventSystem.UIEventHandler(this.OnChallengeChapterFrameClose));
		}

		// Token: 0x0600DB32 RID: 56114 RVA: 0x00373AC4 File Offset: 0x00371EC4
		public void InitView()
		{
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(this.challengeSceneId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("CitySceneTable is null and challengeId is {0}", new object[]
				{
					this.challengeSceneId
				});
				return;
			}
			if (tableItem.ChapterData == null || tableItem.ChapterData.Count <= 0)
			{
				Logger.LogErrorFormat("CitySceneTable ChapterData is null or count is zero", new object[0]);
				return;
			}
			string text = tableItem.ChapterData[0];
			this._chapterData = (Singleton<AssetLoader>.instance.LoadRes(text, typeof(DChapterData), true, 0U).obj as DChapterData);
			if (this._chapterData == null)
			{
				Logger.LogErrorFormat("ChapterData is null and chapterDataPath is {0}", new object[]
				{
					text
				});
				return;
			}
			if (this._chapterData.chapterList == null || this._chapterData.chapterList.Length <= 0)
			{
				Logger.LogErrorFormat("ChapterList is null or count is zero", new object[0]);
				return;
			}
			this.UpdateChallengeNumber();
			this.SetDefaultChapterId();
			this._activityDungeonSubList = ChallengeUtility.GetDailyUnitActivitySubs(this._defaultChapterId);
			this.InitMapModelView();
		}

		// Token: 0x0600DB33 RID: 56115 RVA: 0x00373BF0 File Offset: 0x00371FF0
		private void UpdateChallengeNumber()
		{
			if (this._chapterData.chapterList != null && this._chapterData.chapterList.Length > 0)
			{
				int dungeonID = this._chapterData.chapterList[0].dungeonID;
				if (this.challengeNumInfo != null)
				{
					this.challengeNumInfo.text = TR.Value("resist_magic_challenge_times", DungeonUtility.GetDungeonDailyLeftTimes(dungeonID), DungeonUtility.GetDungeonDailyBaseTimes(dungeonID));
				}
			}
		}

		// Token: 0x0600DB34 RID: 56116 RVA: 0x00373C6F File Offset: 0x0037206F
		private void SetDefaultChapterId()
		{
			if (this._chapterData.chapterList[0] != null)
			{
				this._defaultChapterId = this._chapterData.chapterList[0].dungeonID;
			}
		}

		// Token: 0x0600DB35 RID: 56117 RVA: 0x00373C9C File Offset: 0x0037209C
		private void InitMapModelView()
		{
			if (this.backgroundImage != null)
			{
				this.backgroundImage.gameObject.CustomActive(true);
				ETCImageLoader.LoadSprite(ref this.backgroundImage, this._chapterData.backgroundPath, true);
			}
			this.InitChallengeMapItem();
		}

		// Token: 0x0600DB36 RID: 56118 RVA: 0x00373CEC File Offset: 0x003720EC
		private void InitChallengeMapItem()
		{
			if (this.mapItemPrefab == null || this.mapItemRoot == null)
			{
				Logger.LogErrorFormat("ChapterItemPrefab is null or ChapterItemRoot is null", new object[0]);
				return;
			}
			for (int i = 0; i < this._chapterData.chapterList.Length; i++)
			{
				ChaptertDungeonUnit chaptertDungeonUnit = this._chapterData.chapterList[i];
				if (chaptertDungeonUnit != null)
				{
					ActivityDungeonSub dungeonSubDataByDungeonId = ChallengeUtility.GetDungeonSubDataByDungeonId(chaptertDungeonUnit.dungeonID, this._activityDungeonSubList);
					if (dungeonSubDataByDungeonId == null)
					{
						Logger.LogErrorFormat("ActivityDungeonSub is null and dungeonId is {0}", new object[]
						{
							chaptertDungeonUnit.dungeonID
						});
					}
					else
					{
						if (DungeonUtility.IsLimitTimeHellDungeon(chaptertDungeonUnit.dungeonID))
						{
							if (dungeonSubDataByDungeonId.state == eActivityDungeonState.End || dungeonSubDataByDungeonId.state == eActivityDungeonState.None)
							{
								goto IL_16B;
							}
							if (DataManager<TimeManager>.GetInstance().GetServerTime() > dungeonSubDataByDungeonId.endtime)
							{
								goto IL_16B;
							}
						}
						GameObject gameObject = Object.Instantiate<GameObject>(this.mapItemPrefab);
						if (!(gameObject == null))
						{
							gameObject.CustomActive(true);
							Utility.AttachTo(gameObject, this.mapItemRoot, false);
							ChallengeMapItem component = gameObject.GetComponent<ChallengeMapItem>();
							if (component == null)
							{
								Logger.LogErrorFormat("ChallengeChapterItem is null", new object[0]);
								gameObject.CustomActive(false);
							}
							else
							{
								bool isDefaultSelected = chaptertDungeonUnit.dungeonID == this._defaultChapterId;
								component.InitItem(chaptertDungeonUnit, new OnChallengeMapItemClicked(this.OnChallengeMapItemClick), dungeonSubDataByDungeonId, isDefaultSelected);
								this._mapItemList.Add(component);
							}
						}
					}
				}
				IL_16B:;
			}
		}

		// Token: 0x0600DB37 RID: 56119 RVA: 0x00373E7B File Offset: 0x0037227B
		private void OnChallengeMapItemClick(int chapterId)
		{
			this.OnOpenChallengeDungeonFrame(chapterId, chapterId);
		}

		// Token: 0x0600DB38 RID: 56120 RVA: 0x00373E88 File Offset: 0x00372288
		private void OnOpenChallengeDungeonFrame(int baseDungeonId, int selectDungeonId)
		{
			if (this.comChapterSelectAnimate == null)
			{
				ChallengeUtility.OnOpenChallengeChapterFrame(DungeonModelTable.eType.DeepModel, baseDungeonId, selectDungeonId, this._chapterIdList);
				return;
			}
			if (this._eChapterSelectAnimateState == EChapterSelectAnimateState.OnSelectAnimate)
			{
				return;
			}
			if (this._delayOpenFrameCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this._delayOpenFrameCoroutine);
				this._delayOpenFrameCoroutine = null;
			}
			this._delayOpenFrameCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.DelayOpenFrame(baseDungeonId, selectDungeonId));
		}

		// Token: 0x0600DB39 RID: 56121 RVA: 0x00373EFC File Offset: 0x003722FC
		private IEnumerator DelayOpenFrame(int baseDungeonId, int selectDungeonId)
		{
			if (baseDungeonId > 0)
			{
				ChallengeMapItem chapterMapItem = this.GetChallengeMapItemByChapterId(baseDungeonId);
				if (chapterMapItem != null)
				{
					while (this._eChapterSelectAnimateState != EChapterSelectAnimateState.OnNone)
					{
						yield return null;
					}
					this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnSelectAnimate;
					yield return this.comChapterSelectAnimate.NormalAnimate(chapterMapItem.rectTransform());
					this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnNone;
				}
			}
			ChallengeUtility.OnOpenChallengeChapterFrame(DungeonModelTable.eType.DeepModel, baseDungeonId, selectDungeonId, this._chapterIdList);
			yield break;
		}

		// Token: 0x0600DB3A RID: 56122 RVA: 0x00373F28 File Offset: 0x00372328
		private ChallengeMapItem GetChallengeMapItemByChapterId(int chapterId)
		{
			if (this._mapItemList != null)
			{
				for (int i = 0; i < this._mapItemList.Count; i++)
				{
					ChallengeMapItem challengeMapItem = this._mapItemList[i];
					if (challengeMapItem != null && challengeMapItem.GetChapterDungeonId() == chapterId)
					{
						return challengeMapItem;
					}
				}
			}
			return null;
		}

		// Token: 0x0600DB3B RID: 56123 RVA: 0x00373F84 File Offset: 0x00372384
		private void OnActivityDungeonUpdate(UIEvent uiEvent)
		{
			this.UpdateActivityDungeonItemList();
		}

		// Token: 0x0600DB3C RID: 56124 RVA: 0x00373F8C File Offset: 0x0037238C
		private void UpdateActivityDungeonItemList()
		{
			if (this._mapItemList == null || this._mapItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._mapItemList.Count; i++)
			{
				ChallengeMapItem challengeMapItem = this._mapItemList[i];
				if (challengeMapItem != null)
				{
					challengeMapItem.UpdateDungeonItemContent();
				}
			}
		}

		// Token: 0x0600DB3D RID: 56125 RVA: 0x00373FF4 File Offset: 0x003723F4
		private void OnChallengeChapterFrameClose(UIEvent uiEvent)
		{
			this.UpdateActivityDungeonItemList();
			if (this.comChapterSelectAnimate == null)
			{
				return;
			}
			if (this._eChapterSelectAnimateState != EChapterSelectAnimateState.OnBackAnimate)
			{
				if (this._chapterFrameCloseCoroutine != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this._chapterFrameCloseCoroutine);
					this._chapterFrameCloseCoroutine = null;
				}
				this._chapterFrameCloseCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.RevertMapAnimate());
			}
		}

		// Token: 0x0600DB3E RID: 56126 RVA: 0x00374060 File Offset: 0x00372460
		private IEnumerator RevertMapAnimate()
		{
			while (this._eChapterSelectAnimateState != EChapterSelectAnimateState.OnNone)
			{
				yield return null;
			}
			this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnBackAnimate;
			yield return this.comChapterSelectAnimate.RevertAnimate();
			this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnNone;
			yield break;
		}

		// Token: 0x04008117 RID: 33047
		[SerializeField]
		private Image backgroundImage;

		// Token: 0x04008118 RID: 33048
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private GameObject contentRoot;

		// Token: 0x04008119 RID: 33049
		[SerializeField]
		private GameObject mapItemRoot;

		// Token: 0x0400811A RID: 33050
		[SerializeField]
		private GameObject mapItemPrefab;

		// Token: 0x0400811B RID: 33051
		[Space(10f)]
		[Header("Action")]
		[Space(10f)]
		[SerializeField]
		private ComChapterSelectAnimate comChapterSelectAnimate;

		// Token: 0x0400811C RID: 33052
		[SerializeField]
		private Text challengeNumInfo;

		// Token: 0x0400811D RID: 33053
		[SerializeField]
		private int challengeSceneId;

		// Token: 0x0400811E RID: 33054
		private List<ChallengeMapItem> _mapItemList;

		// Token: 0x0400811F RID: 33055
		private List<int> _chapterIdList;

		// Token: 0x04008120 RID: 33056
		private DChapterData _chapterData;

		// Token: 0x04008121 RID: 33057
		private int _defaultChapterId;

		// Token: 0x04008122 RID: 33058
		private List<ActivityDungeonSub> _activityDungeonSubList;

		// Token: 0x04008123 RID: 33059
		private EChapterSelectAnimateState _eChapterSelectAnimateState;

		// Token: 0x04008124 RID: 33060
		private Coroutine _delayOpenFrameCoroutine;

		// Token: 0x04008125 RID: 33061
		private Coroutine _chapterFrameCloseCoroutine;

		// Token: 0x04008126 RID: 33062
		private Coroutine _chapterFrameChangeCoroutine;
	}
}
