using System;
using DG.Tweening;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F50 RID: 3920
public class ComboCount : MonoBehaviour
{
	// Token: 0x0600985E RID: 39006 RVA: 0x001D5175 File Offset: 0x001D3575
	private void Awake()
	{
		if (null != this.mRootRect)
		{
			this.offsetMin = this.mRootRect.offsetMin;
			this.offsetMax = this.mRootRect.offsetMax;
		}
	}

	// Token: 0x0600985F RID: 39007 RVA: 0x001D51B4 File Offset: 0x001D35B4
	private void _resetCombo()
	{
		this.imageNumber.enabled = false;
		this.timeSlider.enabled = false;
		this.imgCount.enabled = false;
		if (null != this.mRootRect)
		{
			this.mRootRect.offsetMin = this.offsetMin;
			this.mRootRect.offsetMax = this.offsetMax;
		}
	}

	// Token: 0x06009860 RID: 39008 RVA: 0x001D5224 File Offset: 0x001D3624
	private void _playerAnimate()
	{
		for (int i = 0; i < this.allAnimate.Length; i++)
		{
			if (null != this.allAnimate[i] && this.allAnimate[i].isActive)
			{
				this.allAnimate[i].DORestart(false);
			}
		}
	}

	// Token: 0x06009861 RID: 39009 RVA: 0x001D527D File Offset: 0x001D367D
	private void Start()
	{
		this._resetCombo();
	}

	// Token: 0x06009862 RID: 39010 RVA: 0x001D5288 File Offset: 0x001D3688
	public void Feed(int combo)
	{
		this.fDeltaTime = this.ComboDeltaTime;
		if (combo > 1)
		{
			if (!this.imageNumber.enabled)
			{
				this._playerAnimate();
			}
			this.imageNumber.enabled = true;
			this.imgCount.enabled = true;
			this.imageNumber.SetTextNumber(combo);
			if (combo > DataManager<BattleDataManager>.GetInstance().BattleInfo.maxComboCount)
			{
				DataManager<BattleDataManager>.GetInstance().BattleInfo.maxComboCount = combo;
			}
		}
		this.timeSlider.enabled = false;
	}

	// Token: 0x06009863 RID: 39011 RVA: 0x001D5313 File Offset: 0x001D3713
	public void StopFeed()
	{
		this.fDeltaTime = 0f;
		this._resetCombo();
	}

	// Token: 0x06009864 RID: 39012 RVA: 0x001D5328 File Offset: 0x001D3728
	private void Update()
	{
		if (this.fDeltaTime > 0f)
		{
			this.fDeltaTime -= Time.deltaTime;
			if (this.fDeltaTime > 0f)
			{
				this.timeSlider.enabled = true;
				this.timeSlider.value = this.fDeltaTime / this.ComboDeltaTime;
			}
		}
	}

	// Token: 0x04004EA3 RID: 20131
	public Slider timeSlider;

	// Token: 0x04004EA4 RID: 20132
	public Image imgCount;

	// Token: 0x04004EA5 RID: 20133
	public ImageNumber imageNumber;

	// Token: 0x04004EA6 RID: 20134
	public RectTransform mRootRect;

	// Token: 0x04004EA7 RID: 20135
	public DOTweenAnimation[] allAnimate = new DOTweenAnimation[0];

	// Token: 0x04004EA8 RID: 20136
	private Vector3 offsetMin;

	// Token: 0x04004EA9 RID: 20137
	private Vector3 offsetMax;

	// Token: 0x04004EAA RID: 20138
	private float ComboDeltaTime = 1.25f;

	// Token: 0x04004EAB RID: 20139
	private float fDeltaTime;
}
