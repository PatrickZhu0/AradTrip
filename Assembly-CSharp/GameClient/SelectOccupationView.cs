using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001132 RID: 4402
	public class SelectOccupationView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600A753 RID: 42835 RVA: 0x0022E55C File Offset: 0x0022C95C
		private void Awake()
		{
			if (this.mRolesUIList != null)
			{
				this.mRolesUIList.Initialize();
				ComUIListScript comUIListScript = this.mRolesUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mRolesUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600A754 RID: 42836 RVA: 0x0022E5D4 File Offset: 0x0022C9D4
		private void Update()
		{
			if (this.isInitialize)
			{
				this.timer += Time.deltaTime;
				if (this.timer >= 1f)
				{
					this.mDuration -= (int)this.timer;
					this.UpdateTimer();
					this.timer = 0f;
				}
				this.sliderTimer += Time.deltaTime;
				if (this.mSlider != null)
				{
					this.mSlider.value = 1f - this.sliderTimer / (float)this.fSliderTime;
				}
				if (this.mDuration <= 0)
				{
					if (this.mOnSelectJobClick != null && this.mJobsList.Count > 0)
					{
						this.mOnSelectJobClick(this.mJobsList[0]);
					}
					this.isInitialize = false;
				}
			}
		}

		// Token: 0x0600A755 RID: 42837 RVA: 0x0022E6BB File Offset: 0x0022CABB
		private RoleItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<RoleItem>();
		}

		// Token: 0x0600A756 RID: 42838 RVA: 0x0022E6C4 File Offset: 0x0022CAC4
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			RoleItem roleItem = item.gameObjectBindScript as RoleItem;
			if (roleItem == null)
			{
				return;
			}
			if (item.m_index >= 0 && item.m_index < this.mJobsList.Count)
			{
				roleItem.OnItemVisiable(this.mJobsList[item.m_index], this.mOnSelectJobClick, item.m_index);
			}
		}

		// Token: 0x0600A757 RID: 42839 RVA: 0x0022E72F File Offset: 0x0022CB2F
		public void InitView(List<int> jobList, OnSelectJobClick onSelectJobClick)
		{
			this.isInitialize = true;
			this.mJobsList = new List<int>();
			this.mJobsList = jobList;
			this.mOnSelectJobClick = onSelectJobClick;
			this.UpdateTimer();
			this.mRolesUIList.SetElementAmount(this.mJobsList.Count);
		}

		// Token: 0x0600A758 RID: 42840 RVA: 0x0022E76D File Offset: 0x0022CB6D
		private void UpdateTimer()
		{
			if (this.mTimer != null)
			{
				this.mTimer.text = string.Format(this.mTimerDesc, this.mDuration);
			}
		}

		// Token: 0x0600A759 RID: 42841 RVA: 0x0022E7A4 File Offset: 0x0022CBA4
		public void Dispose()
		{
			if (this.mRolesUIList != null)
			{
				ComUIListScript comUIListScript = this.mRolesUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mRolesUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.mRolesUIList = null;
			this.mJobsList.Clear();
			this.mOnSelectJobClick = null;
			this.isInitialize = false;
			this.timer = 0f;
			this.sliderTimer = 0f;
		}

		// Token: 0x0600A75A RID: 42842 RVA: 0x0022E846 File Offset: 0x0022CC46
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x04005D9E RID: 23966
		[SerializeField]
		private ComUIListScript mRolesUIList;

		// Token: 0x04005D9F RID: 23967
		[SerializeField]
		private Text mTimer;

		// Token: 0x04005DA0 RID: 23968
		[SerializeField]
		private string mTimerDesc = "{0}s";

		// Token: 0x04005DA1 RID: 23969
		[SerializeField]
		private Slider mSlider;

		// Token: 0x04005DA2 RID: 23970
		[Space(5f)]
		[Header("倒计时长")]
		[SerializeField]
		private int mDuration = 15;

		// Token: 0x04005DA3 RID: 23971
		[SerializeField]
		private int fSliderTime = 15;

		// Token: 0x04005DA4 RID: 23972
		private List<int> mJobsList;

		// Token: 0x04005DA5 RID: 23973
		private OnSelectJobClick mOnSelectJobClick;

		// Token: 0x04005DA6 RID: 23974
		private bool isInitialize;

		// Token: 0x04005DA7 RID: 23975
		private float timer;

		// Token: 0x04005DA8 RID: 23976
		private float sliderTimer;
	}
}
