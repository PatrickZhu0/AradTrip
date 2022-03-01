using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B23 RID: 6947
	internal class ComFashionMergeResultDataBinder : MonoBehaviour
	{
		// Token: 0x0601110C RID: 69900 RVA: 0x004E410B File Offset: 0x004E250B
		public Vector3 GetSkyWorldPosition()
		{
			if (null != this.goSpecialParent)
			{
				return this.goSpecialParent.transform.position;
			}
			return Vector3.zero;
		}

		// Token: 0x0601110D RID: 69901 RVA: 0x004E4134 File Offset: 0x004E2534
		public void SetValue(FashionResultData result)
		{
			if (null != this.mState)
			{
				FashionMergeResultType eFashionMergeResultType = result.eFashionMergeResultType;
				if (eFashionMergeResultType != FashionMergeResultType.FMRT_NORMAL)
				{
					if (eFashionMergeResultType == FashionMergeResultType.FMRT_SPECIAL)
					{
						if (null == this.comNormalItem)
						{
							this.comNormalItem = ComItemManager.Create(this.goNormalItemParent);
						}
						if (null != this.comNormalItem)
						{
							ItemData item = (result.datas != null && result.datas.Count >= 1) ? result.datas[0] : null;
							this.comNormalItem.Setup(item, null);
						}
						if (null != this.normalName && result.datas != null && result.datas.Count > 0)
						{
							this.normalName.text = result.datas[0].GetColorName(string.Empty, false);
						}
						if (null == this.comSpecialItem)
						{
							this.comSpecialItem = ComItemManager.Create(this.goSpecialParent);
						}
						if (null != this.comSpecialItem)
						{
							ItemData item2 = (result.datas != null && result.datas.Count >= 2) ? result.datas[1] : null;
							this.comSpecialItem.Setup(item2, null);
						}
						if (null != this.specialName && result.datas != null && result.datas.Count > 1)
						{
							this.specialName.text = result.datas[1].GetColorName(string.Empty, false);
						}
						this.mState.Key = "special";
						if (null != this.title)
						{
							string arg = string.Empty;
							if (result.datas != null && result.datas.Count > 1)
							{
								arg = result.datas[1].GetColorName(string.Empty, false);
							}
							if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
							{
								this.title.text = string.Format(this.specialExpress, arg);
							}
							else
							{
								this.title.text = string.Format(this.activityFashionSpecialExpress, arg);
							}
						}
					}
				}
				else
				{
					if (null == this.comNormalItem)
					{
						this.comNormalItem = ComItemManager.Create(this.goNormalItemParent);
					}
					if (null != this.comNormalItem)
					{
						ItemData item3 = (result.datas != null && result.datas.Count >= 1) ? result.datas[0] : null;
						this.comNormalItem.Setup(item3, null);
					}
					if (null != this.normalName && result.datas != null && result.datas.Count > 0)
					{
						this.normalName.text = result.datas[0].GetColorName(string.Empty, false);
					}
					this.mState.Key = "normal";
					if (null != this.title)
					{
						if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
						{
							this.title.text = this.normalExpress;
						}
						else
						{
							this.title.text = this.activityFashionNormalExpress;
						}
					}
				}
			}
		}

		// Token: 0x0601110E RID: 69902 RVA: 0x004E44BC File Offset: 0x004E28BC
		private void OnDestroy()
		{
			if (null != this.comNormalItem)
			{
				ComItemManager.Destroy(this.comNormalItem);
				this.comNormalItem = null;
			}
			if (null != this.comSpecialItem)
			{
				ComItemManager.Destroy(this.comSpecialItem);
				this.comSpecialItem = null;
			}
		}

		// Token: 0x0400AFC6 RID: 44998
		public StateController mState;

		// Token: 0x0400AFC7 RID: 44999
		public GameObject goNormalItemParent;

		// Token: 0x0400AFC8 RID: 45000
		public Text normalName;

		// Token: 0x0400AFC9 RID: 45001
		public GameObject goSpecialParent;

		// Token: 0x0400AFCA RID: 45002
		public Text specialName;

		// Token: 0x0400AFCB RID: 45003
		public string normalExpress = string.Empty;

		// Token: 0x0400AFCC RID: 45004
		public string specialExpress = string.Empty;

		// Token: 0x0400AFCD RID: 45005
		public string activityFashionNormalExpress = string.Empty;

		// Token: 0x0400AFCE RID: 45006
		public string activityFashionSpecialExpress = string.Empty;

		// Token: 0x0400AFCF RID: 45007
		public Text title;

		// Token: 0x0400AFD0 RID: 45008
		public float lockTime = 1f;

		// Token: 0x0400AFD1 RID: 45009
		private ComItem comNormalItem;

		// Token: 0x0400AFD2 RID: 45010
		private ComItem comSpecialItem;
	}
}
