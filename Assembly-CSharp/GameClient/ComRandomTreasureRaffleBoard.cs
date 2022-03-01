using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020019CA RID: 6602
	public class ComRandomTreasureRaffleBoard : MonoBehaviour
	{
		// Token: 0x17001D2C RID: 7468
		// (get) Token: 0x06010288 RID: 66184 RVA: 0x004809B8 File Offset: 0x0047EDB8
		public float GridContentSizeX
		{
			get
			{
				return this.gridContentSizeX;
			}
		}

		// Token: 0x17001D2D RID: 7469
		// (get) Token: 0x06010289 RID: 66185 RVA: 0x004809C0 File Offset: 0x0047EDC0
		public float GridContentSizeY
		{
			get
			{
				return this.gridContentSizeX;
			}
		}

		// Token: 0x17001D2E RID: 7470
		// (get) Token: 0x0601028A RID: 66186 RVA: 0x004809C8 File Offset: 0x0047EDC8
		public bool GridSelectAnimPlaying
		{
			get
			{
				return this.gridSelectAnimPlaying;
			}
		}

		// Token: 0x0601028B RID: 66187 RVA: 0x004809D0 File Offset: 0x0047EDD0
		private void Awake()
		{
			this.gridContentSizeX = (float)this.mGridX * this.mGridSize + (float)(this.mGridX - 1) * this.mGridSpace;
			this.gridContentSizeY = (float)this.mGridY * this.mGridSize + (float)(this.mGridY - 1) * this.mGridSpace;
		}

		// Token: 0x0601028C RID: 66188 RVA: 0x00480A28 File Offset: 0x0047EE28
		private void OnDestroy()
		{
			this._ResetStepAnim();
			this._ResetMoveAnim();
			this.raffleAnimStart = null;
			this.raffleAnimEnd = null;
			this.mGridSelectRect = null;
			this.mSelectGridPosVec2 = default(Vector2);
			if (this.mGridPosList != null)
			{
				this.mGridPosList.Clear();
			}
			if (this.mGridGetItems != null)
			{
				for (int i = 0; i < this.mGridGetItems.Count; i++)
				{
					ComRandomTresureRaffleGetItem comRandomTresureRaffleGetItem = this.mGridGetItems[i];
					if (comRandomTresureRaffleGetItem != null)
					{
						comRandomTresureRaffleGetItem.getItemTargetPos = default(Vector2);
						comRandomTresureRaffleGetItem.getItemInitPos = default(Vector2);
						comRandomTresureRaffleGetItem.getItemRect = null;
						if (comRandomTresureRaffleGetItem.getItemIconTweens != null)
						{
							for (int j = 0; j < comRandomTresureRaffleGetItem.getItemIconTweens.Count; j++)
							{
								DOTweenAnimation dotweenAnimation = comRandomTresureRaffleGetItem.getItemIconTweens[j];
								if (!(dotweenAnimation == null))
								{
									dotweenAnimation.DOPause();
									dotweenAnimation.DOKill();
								}
							}
							comRandomTresureRaffleGetItem.getItemIconTweens = null;
						}
					}
				}
			}
			if (this.mMainGetItem != null)
			{
				ComItemManager.Destroy(this.mMainGetItem);
				this.mMainGetItem = null;
			}
			this.mMainGetItemData = null;
			if (this.mTotalGetItemDatas != null)
			{
				this.mTotalGetItemDatas.Clear();
			}
			if (this.mGetItemTweenQuene != null)
			{
				TweenExtensions.Pause<Sequence>(this.mGetItemTweenQuene);
				TweenExtensions.Kill(this.mGetItemTweenQuene, false);
				this.mGetItemTweenQuene = null;
			}
			this.bInited = false;
		}

		// Token: 0x0601028D RID: 66189 RVA: 0x00480BB8 File Offset: 0x0047EFB8
		private void _ResetStepAnim()
		{
			if (this.mGridSelectRect)
			{
				this.mGridSelectRect.anchoredPosition = this.mSelectGridPosVec2;
			}
			if (this.mGridSelect)
			{
				this.mGridSelect.CustomActive(false);
			}
			if (this.mStepGridDic != null)
			{
				this.mStepGridDic.Clear();
			}
			if (this.mWaitAnimCor != null)
			{
				base.StopCoroutine(this.mWaitAnimCor);
				this.mWaitAnimCor = null;
			}
			this.gridSelectAnimPlaying = false;
		}

		// Token: 0x0601028E RID: 66190 RVA: 0x00480C3D File Offset: 0x0047F03D
		private void _RestartStepAnim()
		{
			this._ResetStepAnim();
			if (this.mGridSelect)
			{
				this.mGridSelect.CustomActive(true);
			}
		}

		// Token: 0x0601028F RID: 66191 RVA: 0x00480C64 File Offset: 0x0047F064
		private void _ResetMoveAnim()
		{
			if (this.mGridGetItems != null)
			{
				for (int i = 0; i < this.mGridGetItems.Count; i++)
				{
					ComRandomTresureRaffleGetItem comRandomTresureRaffleGetItem = this.mGridGetItems[i];
					if (comRandomTresureRaffleGetItem != null)
					{
						comRandomTresureRaffleGetItem.getItemGo.CustomActive(false);
						comRandomTresureRaffleGetItem.getItemRect.anchoredPosition = comRandomTresureRaffleGetItem.getItemInitPos;
					}
				}
			}
		}

		// Token: 0x06010290 RID: 66192 RVA: 0x00480CD0 File Offset: 0x0047F0D0
		private void _RestartMoveAnim()
		{
			if (this.mGridGetItems != null)
			{
				for (int i = 0; i < this.mGridGetItems.Count; i++)
				{
					ComRandomTresureRaffleGetItem comRandomTresureRaffleGetItem = this.mGridGetItems[i];
					if (comRandomTresureRaffleGetItem != null)
					{
						comRandomTresureRaffleGetItem.getItemRect.anchoredPosition = comRandomTresureRaffleGetItem.getItemInitPos;
						if (comRandomTresureRaffleGetItem.getItemIconTweens != null)
						{
							for (int j = 0; j < comRandomTresureRaffleGetItem.getItemIconTweens.Count; j++)
							{
								DOTweenAnimation dotweenAnimation = comRandomTresureRaffleGetItem.getItemIconTweens[j];
								if (!(dotweenAnimation == null))
								{
									dotweenAnimation.DORestart(false);
								}
							}
							comRandomTresureRaffleGetItem.getItemGo.CustomActive(true);
						}
					}
				}
			}
		}

		// Token: 0x06010291 RID: 66193 RVA: 0x00480D8C File Offset: 0x0047F18C
		private int _CalAnimStepCount(int gridIndex)
		{
			if (this.mGridPosList == null)
			{
				return 0;
			}
			if (gridIndex > this.mGridPosList.Count)
			{
				Logger.LogErrorFormat("[ComRandomTreasureRaffleBoard] - _CalRanAnimStepCount outParam gridIndex:{0} > totalGridCount:{1}", new object[]
				{
					gridIndex,
					this.mGridPosList.Count
				});
				return 0;
			}
			return this.mGridPosList.Count + gridIndex + this._InitFirstAnimStepIndex();
		}

		// Token: 0x06010292 RID: 66194 RVA: 0x00480DFB File Offset: 0x0047F1FB
		private int _InitFirstAnimStepIndex()
		{
			return 1;
		}

		// Token: 0x06010293 RID: 66195 RVA: 0x00480DFE File Offset: 0x0047F1FE
		private int _InitOneBoardGridCount()
		{
			if (this.mGridPosList == null)
			{
				return 0;
			}
			return this.mGridPosList.Count;
		}

		// Token: 0x06010294 RID: 66196 RVA: 0x00480E18 File Offset: 0x0047F218
		private void _ExcuteStepAnimEnd()
		{
			this._ResetStepAnim();
			bool flag = true;
			if (this.mMainGetItemData != null)
			{
				flag = DataManager<RandomTreasureDataManager>.GetInstance().CheckGetItemDataNeedNotifyRecord(this.mMainGetItemData);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureRaffleEnd, true, flag, null, null);
			if (this.mTotalGetItemDatas != null)
			{
				for (int i = 0; i < this.mTotalGetItemDatas.Count; i++)
				{
					ItemSimpleData itemSimpleData = this.mTotalGetItemDatas[i];
					if (itemSimpleData != null)
					{
						DataManager<RandomTreasureDataManager>.GetInstance().SystemNotifyOnGetItem(itemSimpleData);
					}
				}
			}
		}

		// Token: 0x06010295 RID: 66197 RVA: 0x00480EB0 File Offset: 0x0047F2B0
		private void _ExcuteStepAnimStart()
		{
			this._RestartStepAnim();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureRaffleStart, null, null, null, null);
		}

		// Token: 0x06010296 RID: 66198 RVA: 0x00480ECB File Offset: 0x0047F2CB
		private void _ExcuteMoveAnimEnd()
		{
			this._ResetMoveAnim();
		}

		// Token: 0x06010297 RID: 66199 RVA: 0x00480ED3 File Offset: 0x0047F2D3
		private void _ExcuteMoveAnimStart()
		{
			this._RestartMoveAnim();
		}

		// Token: 0x06010298 RID: 66200 RVA: 0x00480EDB File Offset: 0x0047F2DB
		private void _ExcuteAllAnimEnd()
		{
			this._ExcuteStepAnimEnd();
			this._ExcuteMoveAnimEnd();
		}

		// Token: 0x06010299 RID: 66201 RVA: 0x00480EEC File Offset: 0x0047F2EC
		private void _InitGridStepInfo(int stepIndex, int firstStepIndex, float stepInterval)
		{
			if (this.mGridPosList == null || this.mStepGridDic == null)
			{
				return;
			}
			Vector2 anchorVec = default(Vector2);
			int num = stepIndex - firstStepIndex;
			if (num >= this.mGridPosList.Count)
			{
				num %= this.mGridPosList.Count;
			}
			anchorVec = this.mGridPosList[num];
			if (this.mStepGridDic.ContainsKey(stepIndex))
			{
				ComRandomTreasureRaffleGridStep comRandomTreasureRaffleGridStep = this.mStepGridDic[stepIndex];
				if (comRandomTreasureRaffleGridStep == null)
				{
					return;
				}
				comRandomTreasureRaffleGridStep.stepInterval = stepInterval;
				comRandomTreasureRaffleGridStep.stepIndex = stepIndex;
				comRandomTreasureRaffleGridStep.anchorVec2 = anchorVec;
			}
			else
			{
				ComRandomTreasureRaffleGridStep comRandomTreasureRaffleGridStep = new ComRandomTreasureRaffleGridStep();
				comRandomTreasureRaffleGridStep.stepInterval = stepInterval;
				comRandomTreasureRaffleGridStep.stepIndex = stepIndex;
				comRandomTreasureRaffleGridStep.anchorVec2 = anchorVec;
				this.mStepGridDic.Add(stepIndex, comRandomTreasureRaffleGridStep);
			}
		}

		// Token: 0x0601029A RID: 66202 RVA: 0x00480FB4 File Offset: 0x0047F3B4
		private void _ResetRaffleBoardData(int raffleItemId, int raffleItemCount, List<ItemSimpleData> otherShowItems)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(raffleItemId, 100, 0);
			itemData.Count = raffleItemCount;
			this.mMainGetItemData = itemData;
			ItemSimpleData itemSimpleData = new ItemSimpleData();
			itemSimpleData.ItemID = raffleItemId;
			itemSimpleData.Count = raffleItemCount;
			itemSimpleData.Name = itemData.Name;
			this.mTotalGetItemDatas = new List<ItemSimpleData>();
			this.mTotalGetItemDatas.Add(itemSimpleData);
			this.mTotalGetItemDatas.AddRange(otherShowItems);
		}

		// Token: 0x0601029B RID: 66203 RVA: 0x0048101C File Offset: 0x0047F41C
		private void _ResetRandomFinalStepCount()
		{
			this.mAnimStepCount_Final = Random.Range((int)this.mAnimStepCount_Final_Min, (int)this.mAnimStepCount_Final_Max);
		}

		// Token: 0x0601029C RID: 66204 RVA: 0x00481038 File Offset: 0x0047F438
		public void InitView()
		{
			if (this.bInited)
			{
				return;
			}
			if (this.mGridPosList != null)
			{
				this.mGridPosList.Clear();
				float num = this.mGridSize * 0.5f;
				Vector2 item = default(Vector2);
				for (int i = 1; i <= this.mGridY; i++)
				{
					for (int j = 1; j <= this.mGridX; j++)
					{
						item.y = -((float)(i - 1) * this.mGridSize + num + (float)(i - 1) * this.mGridSpace);
						item.x = (float)(j - 1) * this.mGridSize + num + (float)(j - 1) * this.mGridSpace;
						this.mGridPosList.Add(item);
					}
				}
			}
			if (this.mAnimCurve != null && this.mAnimCurve.length > 0)
			{
				this.mAnimCurveFirstKey = this.mAnimCurve[0];
				this.mAnimCurveLastKey = this.mAnimCurve[this.mAnimCurve.length - 1];
				this.mAnimTotalTime_Change = this.mAnimCurveLastKey.time;
			}
			int num2 = this._CalAnimStepCount(0);
			if (this.mAnimStepCount_Constant_Scale > 1f || this.mAnimStepCount_Constant_Scale <= 0f)
			{
				this.mAnimStepCount_Constant_Scale = 0.5f;
			}
			if (this.mAnimStepCount_Constant <= 0)
			{
				this.mAnimStepCount_Constant = (int)((float)num2 * this.mAnimStepCount_Constant_Scale);
			}
			if (this.mAnimStepCount_Final <= 0)
			{
				this.mAnimStepCount_Final = Random.Range((int)this.mAnimStepCount_Final_Min, (int)this.mAnimStepCount_Final_Max);
			}
			if (this.mGridSelect)
			{
				this.mGridSelectRect = this.mGridSelect.GetComponent<RectTransform>();
				if (this.mGridSelectRect)
				{
					this.mSelectGridPosVec2 = this.mGridSelectRect.anchoredPosition;
				}
			}
			if (this.mGridGetItems != null)
			{
				for (int k = 0; k < this.mGridGetItems.Count; k++)
				{
					ComRandomTresureRaffleGetItem comRandomTresureRaffleGetItem = this.mGridGetItems[k];
					if (comRandomTresureRaffleGetItem != null)
					{
						comRandomTresureRaffleGetItem.getItemInitPos = comRandomTresureRaffleGetItem.getItemRect.anchoredPosition;
						comRandomTresureRaffleGetItem.getItemGo.CustomActive(false);
					}
				}
			}
			if (this.mGetItemTweenQuene != null)
			{
				TweenExtensions.Kill(this.mGetItemTweenQuene, false);
			}
			this.mGetItemTweenQuene = DOTween.Sequence();
			this._ResetMoveAnim();
			this._ResetStepAnim();
			this.bInited = true;
		}

		// Token: 0x0601029D RID: 66205 RVA: 0x004812A8 File Offset: 0x0047F6A8
		public void StartSelectAnim(int raffleIndex, int raffleItemId, int raffleItemCount, List<ItemSimpleData> otherShowItems, bool bSkipAnim = false)
		{
			this._ResetRandomFinalStepCount();
			this._ResetRaffleBoardData(raffleItemId, raffleItemCount, otherShowItems);
			this._ExcuteStepAnimStart();
			this._ExcuteMoveAnimEnd();
			if (this.mAnimCurve == null)
			{
				this._ExcuteStepAnimEnd();
				return;
			}
			int num = this._CalAnimStepCount(raffleIndex);
			int num2 = this._InitFirstAnimStepIndex();
			this.mAnimStepCount_Constant = (int)((float)(num - this.mAnimStepCount_Final) * this.mAnimStepCount_Constant_Scale);
			if (num <= 0)
			{
				return;
			}
			if (this.mAnimStepCount_Constant + this.mAnimStepCount_Final >= num)
			{
				return;
			}
			float value = this.mAnimCurveFirstKey.value;
			float value2 = this.mAnimCurveLastKey.value;
			float num3 = this.mAnimTotalTime_Change / (float)(num - this.mAnimStepCount_Constant - this.mAnimStepCount_Final);
			for (int i = num2; i <= num; i++)
			{
				float stepInterval;
				if (i <= this.mAnimStepCount_Constant)
				{
					stepInterval = value * this.mAnimSlowSpeed;
				}
				else if (i > num - this.mAnimStepCount_Final)
				{
					stepInterval = value2 * this.mAnimSlowSpeed;
				}
				else
				{
					float num4 = num3 * (float)(i - this.mAnimStepCount_Constant);
					stepInterval = this.mAnimCurve.Evaluate(num4 / this.mAnimTotalTime_Change) * this.mAnimSlowSpeed;
				}
				this._InitGridStepInfo(i, num2, stepInterval);
			}
			if (this.mWaitAnimCor != null)
			{
				base.StopCoroutine(this.mWaitAnimCor);
			}
			this.mWaitAnimCor = base.StartCoroutine(this._WaitToMoveSelectGrid(bSkipAnim));
		}

		// Token: 0x0601029E RID: 66206 RVA: 0x00481414 File Offset: 0x0047F814
		private IEnumerator _WaitToMoveSelectGrid(bool bDirectSelect = false)
		{
			if (this.mStepGridDic == null)
			{
				this._ExcuteStepAnimEnd();
				yield break;
			}
			this.gridSelectAnimPlaying = true;
			if (!bDirectSelect)
			{
				int mCurrStepIndex = this._InitFirstAnimStepIndex();
				while (this.mStepGridDic.ContainsKey(mCurrStepIndex))
				{
					ComRandomTreasureRaffleGridStep gridStep = this.mStepGridDic[mCurrStepIndex];
					if (gridStep == null)
					{
						this._ExcuteStepAnimEnd();
						yield break;
					}
					if (gridStep.stepIndex != mCurrStepIndex)
					{
						this._ExcuteStepAnimEnd();
						yield break;
					}
					float currStepInterval = gridStep.stepInterval;
					if (currStepInterval <= 0f)
					{
						this._ExcuteStepAnimEnd();
						yield break;
					}
					yield return new WaitForSecondsRealtime(currStepInterval);
					if (this.mGridSelectRect)
					{
						this.mGridSelectRect.anchoredPosition = gridStep.anchorVec2;
					}
					mCurrStepIndex++;
					yield return null;
				}
				yield return new WaitForSecondsRealtime(this.mTwoAnimInterval);
			}
			else
			{
				int count = this.mStepGridDic.Count;
				if (!this.mStepGridDic.ContainsKey(count))
				{
					Logger.LogErrorFormat("[ComRandomTreasureRaffleBoard] - _WaitToMoveSelectGrid skipSelectAnim is true, but mStepGridDic not contain the key {0}", new object[]
					{
						count
					});
				}
				ComRandomTreasureRaffleGridStep comRandomTreasureRaffleGridStep = this.mStepGridDic[count];
				if (comRandomTreasureRaffleGridStep != null && this.mGridSelectRect)
				{
					this.mGridSelectRect.anchoredPosition = comRandomTreasureRaffleGridStep.anchorVec2;
				}
			}
			if (this.mTotalGetItemDatas == null)
			{
				this._ExcuteStepAnimEnd();
				yield break;
			}
			if (this.mGridGetItems == null)
			{
				this._ExcuteStepAnimEnd();
				yield break;
			}
			if (this.mGridGetItems.Count != this.mTotalGetItemDatas.Count)
			{
				Logger.LogError("[ComRandomTreasureRaffleBoard] - _WaitToMoveSelectGrid : mGridGetItems.Length != mTotalGetItemDatas.Count");
				this._ExcuteStepAnimEnd();
				yield break;
			}
			if (this.mGetItemTweenQuene == null)
			{
				this._ExcuteStepAnimEnd();
				yield break;
			}
			for (int i = 0; i < this.mGridGetItems.Count; i++)
			{
				ComRandomTresureRaffleGetItem comRandomTresureRaffleGetItem = this.mGridGetItems[i];
				if (comRandomTresureRaffleGetItem == null || comRandomTresureRaffleGetItem.getItemGo == null || comRandomTresureRaffleGetItem.getItemRect == null)
				{
					this._ExcuteStepAnimEnd();
					yield break;
				}
				ItemSimpleData itemSimpleData = this.mTotalGetItemDatas[i];
				if (itemSimpleData == null)
				{
					this._ExcuteStepAnimEnd();
					yield break;
				}
				RandomTreasureInfo component = comRandomTresureRaffleGetItem.getItemGo.GetComponent<RandomTreasureInfo>();
				if (component == null)
				{
					this._ExcuteStepAnimEnd();
					yield break;
				}
				component.SetInfoTitleImg(DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(itemSimpleData.ItemID));
				if (i == this.mGridGetItems.Count - 1)
				{
					TweenSettingsExtensions.SetAutoKill<Sequence>(TweenSettingsExtensions.Insert(this.mGetItemTweenQuene, (float)i, TweenSettingsExtensions.OnComplete<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetDelay<Tweener>(ShortcutExtensions46.DOAnchorPos(comRandomTresureRaffleGetItem.getItemRect, comRandomTresureRaffleGetItem.getItemTargetPos, comRandomTresureRaffleGetItem.getItemTweenDuration, false), comRandomTresureRaffleGetItem.getItemTweenDelay), comRandomTresureRaffleGetItem.getItemPosTweenEase), new TweenCallback(this._ExcuteAllAnimEnd))));
				}
				else
				{
					TweenSettingsExtensions.SetAutoKill<Sequence>(TweenSettingsExtensions.Insert(this.mGetItemTweenQuene, (float)i, TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetDelay<Tweener>(ShortcutExtensions46.DOAnchorPos(comRandomTresureRaffleGetItem.getItemRect, comRandomTresureRaffleGetItem.getItemTargetPos, comRandomTresureRaffleGetItem.getItemTweenDuration, false), comRandomTresureRaffleGetItem.getItemTweenDelay), comRandomTresureRaffleGetItem.getItemPosTweenEase)));
				}
			}
			this._ExcuteMoveAnimStart();
			TweenExtensions.Restart(this.mGetItemTweenQuene, true);
			yield return null;
			yield break;
		}

		// Token: 0x0400A33E RID: 41790
		private UnityAction raffleAnimStart;

		// Token: 0x0400A33F RID: 41791
		private UnityAction raffleAnimEnd;

		// Token: 0x0400A340 RID: 41792
		private bool bInited;

		// Token: 0x0400A341 RID: 41793
		public int mGridX = 5;

		// Token: 0x0400A342 RID: 41794
		public int mGridY = 5;

		// Token: 0x0400A343 RID: 41795
		public float mGridSize = 100f;

		// Token: 0x0400A344 RID: 41796
		public float mGridSpace = 20f;

		// Token: 0x0400A345 RID: 41797
		public GameObject mGridContent;

		// Token: 0x0400A346 RID: 41798
		private List<Vector2> mGridPosList = new List<Vector2>();

		// Token: 0x0400A347 RID: 41799
		public GameObject mGridSelect;

		// Token: 0x0400A348 RID: 41800
		private RectTransform mGridSelectRect;

		// Token: 0x0400A349 RID: 41801
		private Vector2 mSelectGridPosVec2 = default(Vector2);

		// Token: 0x0400A34A RID: 41802
		private float gridContentSizeX;

		// Token: 0x0400A34B RID: 41803
		private float gridContentSizeY;

		// Token: 0x0400A34C RID: 41804
		public List<ComRandomTresureRaffleGetItem> mGridGetItems;

		// Token: 0x0400A34D RID: 41805
		private ComItem mMainGetItem;

		// Token: 0x0400A34E RID: 41806
		private ItemData mMainGetItemData;

		// Token: 0x0400A34F RID: 41807
		private List<ItemSimpleData> mTotalGetItemDatas = new List<ItemSimpleData>();

		// Token: 0x0400A350 RID: 41808
		private Sequence mGetItemTweenQuene;

		// Token: 0x0400A351 RID: 41809
		[Header("变速动画")]
		[SerializeField]
		private AnimationCurve mAnimCurve;

		// Token: 0x0400A352 RID: 41810
		[Header("这个速度用于增加动画时长，越大则动画越慢")]
		[SerializeField]
		private float mAnimSlowSpeed = 1f;

		// Token: 0x0400A353 RID: 41811
		[Header("快结束的慢速点数量固定值")]
		[SerializeField]
		private int mAnimStepCount_Final;

		// Token: 0x0400A354 RID: 41812
		[Header("快结束的慢速点数量，固定值<=0，则使用随机值，该值为随机的最小值")]
		[SerializeField]
		private uint mAnimStepCount_Final_Min = 2U;

		// Token: 0x0400A355 RID: 41813
		[Header("快结束的慢速点数量，固定值<=0，则使用随机值，该值为随机的最大值")]
		[SerializeField]
		private uint mAnimStepCount_Final_Max = 5U;

		// Token: 0x0400A356 RID: 41814
		[Header("一开始的匀速点数量占出去最后慢速点后的占比")]
		[SerializeField]
		private float mAnimStepCount_Constant_Scale = 0.5f;

		// Token: 0x0400A357 RID: 41815
		private int mAnimStepCount_Constant;

		// Token: 0x0400A358 RID: 41816
		[Header("不同动画间的间隔时间")]
		[SerializeField]
		private float mTwoAnimInterval = 0.5f;

		// Token: 0x0400A359 RID: 41817
		private float mAnimTotalTime_Change;

		// Token: 0x0400A35A RID: 41818
		private Keyframe mAnimCurveFirstKey = default(Keyframe);

		// Token: 0x0400A35B RID: 41819
		private Keyframe mAnimCurveLastKey = default(Keyframe);

		// Token: 0x0400A35C RID: 41820
		private Dictionary<int, ComRandomTreasureRaffleGridStep> mStepGridDic = new Dictionary<int, ComRandomTreasureRaffleGridStep>();

		// Token: 0x0400A35D RID: 41821
		private Coroutine mWaitAnimCor;

		// Token: 0x0400A35E RID: 41822
		private bool gridSelectAnimPlaying;
	}
}
