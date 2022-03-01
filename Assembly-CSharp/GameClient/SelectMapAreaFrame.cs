using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001130 RID: 4400
	public class SelectMapAreaFrame : ClientFrame
	{
		// Token: 0x0600A73D RID: 42813 RVA: 0x0022DF93 File Offset: 0x0022C393
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/SelectMapAreaFrame";
		}

		// Token: 0x0600A73E RID: 42814 RVA: 0x0022DF9C File Offset: 0x0022C39C
		protected sealed override void _OnOpenFrame()
		{
			if (this.mTime != null)
			{
				this.mTime.text = this.LeftTime.ToString();
			}
			for (int i = 0; i < this.tgArea.Length; i++)
			{
				this.tgArea[i].image.alphaHitTestMinimumThreshold = 1f;
			}
		}

		// Token: 0x0600A73F RID: 42815 RVA: 0x0022E006 File Offset: 0x0022C406
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
		}

		// Token: 0x0600A740 RID: 42816 RVA: 0x0022E00E File Offset: 0x0022C40E
		private void _ClearData()
		{
			this.LeftTime = 15;
			this.fTimeIntrval = 0f;
			this.AreaIndex = 0;
			this.iSliderTime = 15;
			this.fSliderTimer = 0f;
		}

		// Token: 0x0600A741 RID: 42817 RVA: 0x0022E03D File Offset: 0x0022C43D
		[UIEventHandle("Areas/Area_{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 0, 5)]
		private void OnSelectArea(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			this.AreaIndex = iIndex;
		}

		// Token: 0x0600A742 RID: 42818 RVA: 0x0022E054 File Offset: 0x0022C454
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A743 RID: 42819 RVA: 0x0022E058 File Offset: 0x0022C458
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeIntrval += timeElapsed;
			this.fSliderTimer += timeElapsed;
			if (this.fTimeIntrval >= 1f)
			{
				this.LeftTime -= (int)this.fTimeIntrval;
				if (this.mTime != null)
				{
					this.mTime.text = string.Format("{0}", this.LeftTime);
				}
				this.fTimeIntrval = 0f;
			}
			if (this.mSlider != null)
			{
				this.mSlider.value = 1f - this.fSliderTimer / (float)this.iSliderTime;
			}
			if (this.LeftTime <= 0)
			{
				DataManager<ChijiDataManager>.GetInstance().SendSelectAreaId(this.AreaIndex);
				this.frameMgr.CloseFrame<SelectMapAreaFrame>(this, false);
			}
		}

		// Token: 0x0600A744 RID: 42820 RVA: 0x0022E13C File Offset: 0x0022C53C
		protected override void _bindExUI()
		{
			this.mBtOK = this.mBind.GetCom<Button>("btOK");
			if (null != this.mBtOK)
			{
				this.mBtOK.onClick.AddListener(new UnityAction(this._onBtOKButtonClick));
			}
			this.mTime = this.mBind.GetCom<Text>("Time");
			this.mSlider = this.mBind.GetCom<Slider>("Slider");
		}

		// Token: 0x0600A745 RID: 42821 RVA: 0x0022E1B8 File Offset: 0x0022C5B8
		protected override void _unbindExUI()
		{
			if (null != this.mBtOK)
			{
				this.mBtOK.onClick.RemoveListener(new UnityAction(this._onBtOKButtonClick));
			}
			this.mBtOK = null;
			this.mTime = null;
			this.mSlider = null;
		}

		// Token: 0x0600A746 RID: 42822 RVA: 0x0022E207 File Offset: 0x0022C607
		private void _onBtOKButtonClick()
		{
			DataManager<ChijiDataManager>.GetInstance().SendSelectAreaId(this.AreaIndex + 1);
			this.frameMgr.CloseFrame<SelectMapAreaFrame>(this, false);
		}

		// Token: 0x04005D92 RID: 23954
		private const int AreaNum = 6;

		// Token: 0x04005D93 RID: 23955
		private int LeftTime = 15;

		// Token: 0x04005D94 RID: 23956
		private float fTimeIntrval;

		// Token: 0x04005D95 RID: 23957
		private int iSliderTime = 15;

		// Token: 0x04005D96 RID: 23958
		private float fSliderTimer;

		// Token: 0x04005D97 RID: 23959
		private int AreaIndex;

		// Token: 0x04005D98 RID: 23960
		[UIControl("Areas/Area_{0}", typeof(Toggle), 0)]
		private Toggle[] tgArea = new Toggle[6];

		// Token: 0x04005D99 RID: 23961
		private Button mBtOK;

		// Token: 0x04005D9A RID: 23962
		private Text mTime;

		// Token: 0x04005D9B RID: 23963
		private Slider mSlider;
	}
}
