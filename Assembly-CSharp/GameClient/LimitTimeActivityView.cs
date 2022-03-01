using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001915 RID: 6421
	[RequireComponent(typeof(ComTwoLevelToggleGroup))]
	public sealed class LimitTimeActivityView : MonoBehaviour, IDisposable
	{
		// Token: 0x17001D08 RID: 7432
		// (get) Token: 0x0600FA01 RID: 64001 RVA: 0x00446EFB File Offset: 0x004452FB
		public RectTransform FrameRoot
		{
			get
			{
				return this.mFrameRoot;
			}
		}

		// Token: 0x17001D09 RID: 7433
		// (set) Token: 0x0600FA02 RID: 64002 RVA: 0x00446F03 File Offset: 0x00445303
		public UnityAction OnButtonCloseClick
		{
			set
			{
				this.mButtonClose.SafeRemoveAllListener();
				this.mButtonClose.SafeAddOnClickListener(value);
			}
		}

		// Token: 0x0600FA03 RID: 64003 RVA: 0x00446F1C File Offset: 0x0044531C
		public void Init(List<ITwoLevelToggleData> parentToggleDatas, List<List<ITwoLevelToggleData>> subToggleDatas, ComTwoLevelToggleGroup.OnValueChanged onParentValueChanged, ComTwoLevelToggleGroup.OnValueChanged onSubValueChanged)
		{
			if (this.mToggleGroup == null)
			{
				return;
			}
			this.mToggleGroup.Init(parentToggleDatas, subToggleDatas, onParentValueChanged, onSubValueChanged, 0U, 0U);
			this.mToggleGroup.SetSubGroupCanScroll(false, true, 1);
			if (parentToggleDatas.Count >= this.mCanScrollCount)
			{
				this.mToggleGroup.SetParentGroupCanScroll(true, false, 1);
				this.mIsParentToggleGroupScrolled = true;
			}
		}

		// Token: 0x0600FA04 RID: 64004 RVA: 0x00446F84 File Offset: 0x00445384
		public void AddTopToggle(List<ITwoLevelToggleData> subToggleDatas, ITwoLevelToggleData data, int insertPosition = -1)
		{
			if (this.mToggleGroup == null)
			{
				return;
			}
			this.mToggleGroup.AddParentToggle(subToggleDatas, data, insertPosition);
			if (!this.mIsParentToggleGroupScrolled && this.mToggleGroup.GetParentToggleCount() > this.mCanScrollCount)
			{
				this.mToggleGroup.SetParentGroupCanScroll(true, false, 1);
				this.mIsParentToggleGroupScrolled = true;
			}
		}

		// Token: 0x0600FA05 RID: 64005 RVA: 0x00446FE7 File Offset: 0x004453E7
		public void AddSubToggle(uint parentId, ITwoLevelToggleData data, int insertPosition = -1)
		{
			if (this.mToggleGroup == null)
			{
				return;
			}
			this.mToggleGroup.AddSubToggle(parentId, data, insertPosition);
		}

		// Token: 0x0600FA06 RID: 64006 RVA: 0x00447009 File Offset: 0x00445409
		public void SetSubRedPoint(int parentId, int id, bool value)
		{
			if (this.mToggleGroup == null)
			{
				return;
			}
			this.mToggleGroup.SetSubRedPoint(parentId, id, value);
		}

		// Token: 0x0600FA07 RID: 64007 RVA: 0x0044702B File Offset: 0x0044542B
		public void SetParentRedPoint(int id, bool value)
		{
			if (this.mToggleGroup == null)
			{
				return;
			}
			this.mToggleGroup.SetParentRedPoint(id, value);
		}

		// Token: 0x0600FA08 RID: 64008 RVA: 0x0044704C File Offset: 0x0044544C
		public void GoToToggleFromID(int parentId, int subId)
		{
			if (this.mToggleGroup == null)
			{
				return;
			}
			this.mToggleGroup.SelectToggle(parentId, subId);
		}

		// Token: 0x0600FA09 RID: 64009 RVA: 0x0044706D File Offset: 0x0044546D
		public void RemoveParentToggle(int id)
		{
			if (this.mToggleGroup == null)
			{
				return;
			}
			this.mToggleGroup.RemoveParentToggle(id);
		}

		// Token: 0x0600FA0A RID: 64010 RVA: 0x0044708D File Offset: 0x0044548D
		public void RemoveSubToggle(uint parentId, uint id)
		{
			if (this.mToggleGroup == null)
			{
				return;
			}
			this.mToggleGroup.RemoveSubToggle(parentId, id);
		}

		// Token: 0x0600FA0B RID: 64011 RVA: 0x004470AE File Offset: 0x004454AE
		public void Dispose()
		{
			if (this.mToggleGroup != null)
			{
				this.mToggleGroup.Dispose();
			}
			this.mIsParentToggleGroupScrolled = false;
		}

		// Token: 0x04009C1E RID: 39966
		[SerializeField]
		private ComTwoLevelToggleGroup mToggleGroup;

		// Token: 0x04009C1F RID: 39967
		[SerializeField]
		private RectTransform mFrameRoot;

		// Token: 0x04009C20 RID: 39968
		[SerializeField]
		private Button mButtonClose;

		// Token: 0x04009C21 RID: 39969
		[Header("大页签数量大于多少时可以滑动")]
		[SerializeField]
		private int mCanScrollCount = 3;

		// Token: 0x04009C22 RID: 39970
		private bool mIsParentToggleGroupScrolled;
	}
}
