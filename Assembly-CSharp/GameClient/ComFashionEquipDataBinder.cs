using System;
using System.Collections.Generic;
using DG.Tweening;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001ADE RID: 6878
	internal class ComFashionEquipDataBinder : MonoBehaviour
	{
		// Token: 0x06010E2F RID: 69167 RVA: 0x004D239C File Offset: 0x004D079C
		public void SetSuit(FashionType eFashionType, int occu, int suitId)
		{
			this.mFashionType = eFashionType;
			if (eFashionType != FashionType.FT_NATIONALDAY)
			{
				this.SetSuit(eFashionType, occu, suitId, this.mItemParents, this.mComItems, this.mItemNames);
			}
			else
			{
				this.SetSuit(eFashionType, occu, suitId, this.mActivityFashionItemParents, this.mActivityFashionComItems, this.mActivityFashionItemNames);
			}
		}

		// Token: 0x06010E30 RID: 69168 RVA: 0x004D23F8 File Offset: 0x004D07F8
		private void SetSuit(FashionType eFashionType, int occu, int suitId, GameObject[] mItemParents, ComItem[] mComItems, Text[] mItemNames)
		{
			List<int> list = ListPool<int>.Get();
			DataManager<FashionMergeManager>.GetInstance().GetFashionItemsByTypeAndOccu(eFashionType, occu, suitId, ref list);
			for (int i = 0; i < list.Count; i++)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(list[i]);
				if (commonItemTableDataByID != null)
				{
					if (mComItems[i] == null)
					{
						mComItems[i] = ComItemManager.Create(mItemParents[i]);
					}
					if (null != mComItems[i])
					{
						mComItems[i].Setup(commonItemTableDataByID, null);
					}
					if (null != mItemNames[i])
					{
						mItemNames[i].text = commonItemTableDataByID.GetColorName(string.Empty, false);
					}
					int suitID = commonItemTableDataByID.SuitID;
				}
			}
			ListPool<int>.Release(list);
			if (null != this.suitName)
			{
				int fashionByKey = DataManager<FashionMergeManager>.GetInstance().GetFashionByKey(eFashionType, occu, suitId, ItemTable.eSubType.FASHION_HEAD);
				FashionComposeSkyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(fashionByKey, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.suitName.text = string.Format(this.suitFormatString, tableItem.SuitName);
				}
			}
		}

		// Token: 0x06010E31 RID: 69169 RVA: 0x004D2518 File Offset: 0x004D0918
		public void Play()
		{
			if (null != this.dotween)
			{
				for (int i = 0; i < this.mItemParents.Length; i++)
				{
					float fDelyTime = this.mDelays[i];
					int k = i;
					InvokeMethod.Invoke(this, fDelyTime, delegate()
					{
						this.mRoots[k].CustomActive(true);
						this.dotween.DOPlayAllById(k.ToString());
					});
				}
			}
			InvokeMethod.Invoke(this, this.mShakeDelay, delegate()
			{
				this.dotween.DOPlayAllById("8");
			});
			if (null != this.comEffectProcess)
			{
				this.comEffectProcess.Play();
			}
		}

		// Token: 0x06010E32 RID: 69170 RVA: 0x004D25B4 File Offset: 0x004D09B4
		private void ActivityFashionPlay()
		{
			if (null != this.mActivityFashionDotween)
			{
				for (int i = 0; i < this.mActivityFashionItemParents.Length; i++)
				{
					float fDelyTime = this.mDelays[i];
					int k = i;
					InvokeMethod.Invoke(this, fDelyTime, delegate()
					{
						this.mActivityFashionRoots[k].CustomActive(true);
						this.mActivityFashionDotween.DOPlayAllById(k.ToString());
					});
				}
			}
			InvokeMethod.Invoke(this, this.mShakeDelay, delegate()
			{
				this.dotween.DOPlayAllById("8");
			});
			if (null != this.mActivityFashionComEffectProcess)
			{
				this.mActivityFashionComEffectProcess.Play();
			}
		}

		// Token: 0x06010E33 RID: 69171 RVA: 0x004D2650 File Offset: 0x004D0A50
		private void ItemParentDoPlay(int count)
		{
			for (int i = 0; i < this.mItemParents.Length; i++)
			{
				float fDelyTime = this.mDelays[i];
				int k = i;
				InvokeMethod.Invoke(this, fDelyTime, delegate()
				{
					this.mRoots[k].CustomActive(true);
					this.dotween.DOPlayAllById(k.ToString());
				});
			}
		}

		// Token: 0x06010E34 RID: 69172 RVA: 0x004D26A6 File Offset: 0x004D0AA6
		private void Start()
		{
			if (this.mFashionType != FashionType.FT_NATIONALDAY)
			{
				this.Play();
			}
			else
			{
				this.ActivityFashionPlay();
			}
		}

		// Token: 0x06010E35 RID: 69173 RVA: 0x004D26C9 File Offset: 0x004D0AC9
		private void OnDestroy()
		{
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x0400AD67 RID: 44391
		public Text suitName;

		// Token: 0x0400AD68 RID: 44392
		public GameObject[] mRoots = new GameObject[6];

		// Token: 0x0400AD69 RID: 44393
		public GameObject[] mItemParents = new GameObject[6];

		// Token: 0x0400AD6A RID: 44394
		public Text[] mItemNames = new Text[6];

		// Token: 0x0400AD6B RID: 44395
		private ComItem[] mComItems = new ComItem[6];

		// Token: 0x0400AD6C RID: 44396
		public DOTweenAnimation dotween;

		// Token: 0x0400AD6D RID: 44397
		public float[] mDelays = new float[6];

		// Token: 0x0400AD6E RID: 44398
		public ComEffectPrcess comEffectProcess;

		// Token: 0x0400AD6F RID: 44399
		public float mShakeDelay = 3f;

		// Token: 0x0400AD70 RID: 44400
		public ComScreenShake comScreenShake;

		// Token: 0x0400AD71 RID: 44401
		public string suitFormatString = string.Empty;

		// Token: 0x0400AD72 RID: 44402
		public GameObject[] mActivityFashionRoots = new GameObject[5];

		// Token: 0x0400AD73 RID: 44403
		public GameObject[] mActivityFashionItemParents = new GameObject[5];

		// Token: 0x0400AD74 RID: 44404
		public Text[] mActivityFashionItemNames = new Text[5];

		// Token: 0x0400AD75 RID: 44405
		private ComItem[] mActivityFashionComItems = new ComItem[5];

		// Token: 0x0400AD76 RID: 44406
		public ComEffectPrcess mActivityFashionComEffectProcess;

		// Token: 0x0400AD77 RID: 44407
		public DOTweenAnimation mActivityFashionDotween;

		// Token: 0x0400AD78 RID: 44408
		private FashionType mFashionType;
	}
}
