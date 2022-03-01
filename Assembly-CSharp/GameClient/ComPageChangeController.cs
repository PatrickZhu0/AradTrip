using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EAA RID: 3754
	public class ComPageChangeController : MonoBehaviour
	{
		// Token: 0x0600943A RID: 37946 RVA: 0x001BC954 File Offset: 0x001BAD54
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600943B RID: 37947 RVA: 0x001BC95C File Offset: 0x001BAD5C
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600943C RID: 37948 RVA: 0x001BC96C File Offset: 0x001BAD6C
		private void BindUiEvents()
		{
			if (this.prePageButton != null)
			{
				this.prePageButton.onClick.RemoveAllListeners();
				this.prePageButton.onClick.AddListener(new UnityAction(this.OnPrePageButtonClick));
			}
			if (this.nextPageButton != null)
			{
				this.nextPageButton.onClick.RemoveAllListeners();
				this.nextPageButton.onClick.AddListener(new UnityAction(this.OnNextPageButtonClick));
			}
		}

		// Token: 0x0600943D RID: 37949 RVA: 0x001BC9F4 File Offset: 0x001BADF4
		private void UnBindUiEvents()
		{
			if (this.prePageButton != null)
			{
				this.prePageButton.onClick.RemoveAllListeners();
			}
			if (this.nextPageButton != null)
			{
				this.nextPageButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600943E RID: 37950 RVA: 0x001BCA43 File Offset: 0x001BAE43
		private void ClearData()
		{
			this._selectPageIndex = 0;
			this._maxPageNumber = 0;
			this._onPageChangeAction = null;
		}

		// Token: 0x0600943F RID: 37951 RVA: 0x001BCA5A File Offset: 0x001BAE5A
		public void InitPageChangeController(int selectPageIndex, int maxPageNumber, OnPageChangeAction onPageChangeAction)
		{
			this._selectPageIndex = selectPageIndex;
			this._maxPageNumber = maxPageNumber;
			this._onPageChangeAction = onPageChangeAction;
			this.UpdateButtonState();
		}

		// Token: 0x06009440 RID: 37952 RVA: 0x001BCA77 File Offset: 0x001BAE77
		public void UpdatePageChangeController(int selectPageIndex)
		{
			this._selectPageIndex = selectPageIndex;
			this.UpdateButtonState();
		}

		// Token: 0x06009441 RID: 37953 RVA: 0x001BCA86 File Offset: 0x001BAE86
		private void OnPrePageButtonClick()
		{
			if (this._selectPageIndex <= 1)
			{
				return;
			}
			this._selectPageIndex--;
			this.UpdateButtonState();
			if (this._onPageChangeAction != null)
			{
				this._onPageChangeAction(this._selectPageIndex);
			}
		}

		// Token: 0x06009442 RID: 37954 RVA: 0x001BCAC8 File Offset: 0x001BAEC8
		private void OnNextPageButtonClick()
		{
			if (this._selectPageIndex >= this._maxPageNumber)
			{
				return;
			}
			this._selectPageIndex++;
			this.UpdateButtonState();
			if (this._onPageChangeAction != null)
			{
				this._onPageChangeAction(this._selectPageIndex);
			}
		}

		// Token: 0x06009443 RID: 37955 RVA: 0x001BCB18 File Offset: 0x001BAF18
		private void UpdateButtonState()
		{
			if (this._selectPageIndex <= 1)
			{
				CommonUtility.UpdateButtonState(this.prePageButton, this.prePageButtonGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.prePageButton, this.prePageButtonGray, true);
			}
			if (this._selectPageIndex >= this._maxPageNumber)
			{
				CommonUtility.UpdateButtonState(this.nextPageButton, this.nextPageButtonGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.nextPageButton, this.nextPageButtonGray, true);
			}
		}

		// Token: 0x04004B09 RID: 19209
		private int _selectPageIndex;

		// Token: 0x04004B0A RID: 19210
		private int _maxPageNumber;

		// Token: 0x04004B0B RID: 19211
		private OnPageChangeAction _onPageChangeAction;

		// Token: 0x04004B0C RID: 19212
		[Space(10f)]
		[Header("PageChangeButton")]
		[Space(10f)]
		[SerializeField]
		private Button prePageButton;

		// Token: 0x04004B0D RID: 19213
		[SerializeField]
		private UIGray prePageButtonGray;

		// Token: 0x04004B0E RID: 19214
		[SerializeField]
		private Button nextPageButton;

		// Token: 0x04004B0F RID: 19215
		[SerializeField]
		private UIGray nextPageButtonGray;
	}
}
