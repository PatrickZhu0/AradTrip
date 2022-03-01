using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019CB RID: 6603
	public class ComRandomTreasureSelectMap : MonoBehaviour
	{
		// Token: 0x060102A0 RID: 66208 RVA: 0x00481954 File Offset: 0x0047FD54
		private void Start()
		{
			if (this.mFuncBtn)
			{
				this.mFuncBtn.onClick.AddListener(new UnityAction(this.OnSelectMapBtnClick));
			}
			if (this.mBgImg)
			{
				this.mBgImg.color = new Color(1f, 1f, 1f, 0f);
			}
		}

		// Token: 0x060102A1 RID: 66209 RVA: 0x004819C1 File Offset: 0x0047FDC1
		private void OnDestroy()
		{
			if (this.mFuncBtn)
			{
				this.mFuncBtn.onClick.RemoveListener(new UnityAction(this.OnSelectMapBtnClick));
			}
			this.mapModel = null;
			this.bSelected = false;
		}

		// Token: 0x060102A2 RID: 66210 RVA: 0x00481A00 File Offset: 0x0047FE00
		private void OnSelectMapBtnClick()
		{
			if (this.mapModel != null && !this.bSelected)
			{
				this.bSelected = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChangeTreasureDigSelectMap, this, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChangeTreasureDigMap, this.mapModel, null, null, null);
			}
		}

		// Token: 0x060102A3 RID: 66211 RVA: 0x00481A58 File Offset: 0x0047FE58
		private void SetBackground()
		{
			if (this.mapModel == null)
			{
				return;
			}
			DigMapTable localMapData = this.mapModel.localMapData;
			if (localMapData != null)
			{
				string atlasResPath = localMapData.AtlasResPath;
				ETCImageLoader.LoadSprite(ref this.mBgImg, atlasResPath, true);
			}
			if (this.mBgImg)
			{
				this.mBgImg.color = new Color(1f, 1f, 1f, 1f);
			}
		}

		// Token: 0x060102A4 RID: 66212 RVA: 0x00481ACC File Offset: 0x0047FECC
		private void SetTitleName()
		{
			if (this.mapModel == null)
			{
				return;
			}
			DigMapTable localMapData = this.mapModel.localMapData;
			if (localMapData != null && this.mTitleName)
			{
				this.mTitleName.text = localMapData.Name;
			}
		}

		// Token: 0x060102A5 RID: 66213 RVA: 0x00481B18 File Offset: 0x0047FF18
		private void SetGoldTreasureInfo()
		{
			if (this.mapModel == null)
			{
				return;
			}
			if (this.mGoldeninfo != null)
			{
				this.mGoldeninfo.SetInfoContent(this.mapModel.goldSiteNum.ToString());
			}
		}

		// Token: 0x060102A6 RID: 66214 RVA: 0x00481B58 File Offset: 0x0047FF58
		private void SetSilverTreasureInfo()
		{
			if (this.mapModel == null)
			{
				return;
			}
			if (this.mSilverinfo != null)
			{
				this.mSilverinfo.SetInfoContent(this.mapModel.silverSiteNum.ToString());
			}
		}

		// Token: 0x060102A7 RID: 66215 RVA: 0x00481B98 File Offset: 0x0047FF98
		public void RefreshView(RandomTreasureMapModel model)
		{
			this.mapModel = model;
			this.SetBackground();
			this.SetTitleName();
			this.SetGoldTreasureInfo();
			this.SetSilverTreasureInfo();
		}

		// Token: 0x060102A8 RID: 66216 RVA: 0x00481BB9 File Offset: 0x0047FFB9
		public RandomTreasureMapModel GetCurrMapModel()
		{
			return this.mapModel;
		}

		// Token: 0x060102A9 RID: 66217 RVA: 0x00481BC1 File Offset: 0x0047FFC1
		public bool IsSelected()
		{
			return this.bSelected;
		}

		// Token: 0x060102AA RID: 66218 RVA: 0x00481BC9 File Offset: 0x0047FFC9
		public void ReleaseThisMapSelect()
		{
			this.bSelected = false;
		}

		// Token: 0x0400A35F RID: 41823
		private RandomTreasureMapModel mapModel;

		// Token: 0x0400A360 RID: 41824
		private bool bSelected;

		// Token: 0x0400A361 RID: 41825
		[SerializeField]
		private Image mBgImg;

		// Token: 0x0400A362 RID: 41826
		[SerializeField]
		private Button mFuncBtn;

		// Token: 0x0400A363 RID: 41827
		[SerializeField]
		private Text mTitleName;

		// Token: 0x0400A364 RID: 41828
		[SerializeField]
		private RandomTreasureInfo mGoldeninfo;

		// Token: 0x0400A365 RID: 41829
		[SerializeField]
		private RandomTreasureInfo mSilverinfo;
	}
}
