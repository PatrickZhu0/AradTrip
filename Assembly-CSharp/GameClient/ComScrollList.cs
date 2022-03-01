using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F11 RID: 3857
	public class ComScrollList : ScrollRect
	{
		// Token: 0x06009694 RID: 38548 RVA: 0x001C9BD7 File Offset: 0x001C7FD7
		public override void OnBeginDrag(PointerEventData eventData)
		{
			this.m_bDragging = true;
			base.OnBeginDrag(eventData);
		}

		// Token: 0x06009695 RID: 38549 RVA: 0x001C9BE8 File Offset: 0x001C7FE8
		public override void OnDrag(PointerEventData data)
		{
			if (this.m_eState == ComScrollList.EState.Normal)
			{
				if (base.verticalNormalizedPosition <= 0f && data.delta.y > 0f)
				{
					if (this.m_arrScrollItems.Count > 0)
					{
						int num = this.dynamicMainScrollItemCount * this.subScrollItemCount;
						int num2 = 0;
						for (int i = this.m_arrScrollItems.Count - 1; i >= 0; i--)
						{
							if (this.m_arrScrollItems[i].IsActive())
							{
								num2 = this.m_arrScrollItems[i].GetDataID();
								break;
							}
						}
						if (num2 + num > this.m_nMaxDataID)
						{
							num = this.m_nMaxDataID - num2;
						}
						if (num > 0)
						{
							this.m_eState = ComScrollList.EState.PrepareLoadingDown;
						}
						else
						{
							this.m_eState = ComScrollList.EState.FouceBottom;
						}
					}
					else
					{
						this.m_eState = ComScrollList.EState.FouceBottom;
					}
				}
				else if (base.verticalNormalizedPosition >= 1f && data.delta.y < 0f && this.m_arrScrollItems.Count > 0)
				{
					int num3 = this.dynamicMainScrollItemCount * this.subScrollItemCount;
					int num4 = 0;
					for (int j = 0; j < this.m_arrScrollItems.Count; j++)
					{
						if (this.m_arrScrollItems[j].IsActive())
						{
							num4 = this.m_arrScrollItems[j].GetDataID();
							break;
						}
					}
					if (num4 - num3 < this.m_nMinDataID)
					{
						num3 = num4 - this.m_nMinDataID;
					}
					if (num3 > 0)
					{
						this.m_eState = ComScrollList.EState.PrepareLoadingUp;
					}
				}
			}
			else if (this.m_eState == ComScrollList.EState.FouceBottom && base.verticalNormalizedPosition > 0f && data.delta.y < 0f)
			{
				this.m_eState = ComScrollList.EState.Normal;
			}
			base.OnDrag(data);
		}

		// Token: 0x06009696 RID: 38550 RVA: 0x001C9DE8 File Offset: 0x001C81E8
		public override void OnEndDrag(PointerEventData eventData)
		{
			this.m_bDragging = false;
			if (this.m_eState == ComScrollList.EState.PrepareLoadingDown)
			{
				if (this.m_arrScrollItems.Count > 0)
				{
					int num = this.dynamicMainScrollItemCount * this.subScrollItemCount;
					int num2 = 0;
					for (int i = this.m_arrScrollItems.Count - 1; i >= 0; i--)
					{
						if (this.m_arrScrollItems[i].IsActive())
						{
							num2 = this.m_arrScrollItems[i].GetDataID();
							break;
						}
					}
					if (num2 + num > this.m_nMaxDataID)
					{
						num = this.m_nMaxDataID - num2;
					}
					if (num > 0)
					{
						this.m_eState = ComScrollList.EState.LoadingDown;
						base.StartCoroutine(this._LoadScrollItemsDownDynamic(num2, num, false));
					}
				}
			}
			else if (this.m_eState == ComScrollList.EState.PrepareLoadingUp && this.m_arrScrollItems.Count > 0)
			{
				int num3 = this.dynamicMainScrollItemCount * this.subScrollItemCount;
				int num4 = 0;
				for (int j = 0; j < this.m_arrScrollItems.Count; j++)
				{
					if (this.m_arrScrollItems[j].IsActive())
					{
						num4 = this.m_arrScrollItems[j].GetDataID();
						break;
					}
				}
				if (num4 - num3 < this.m_nMinDataID)
				{
					num3 = num4 - this.m_nMinDataID;
				}
				if (num3 > 0)
				{
					this.m_eState = ComScrollList.EState.LoadingUp;
					base.StartCoroutine(this._LoadScrollItemsUpDynamic(num4, num3));
				}
			}
			base.OnEndDrag(eventData);
		}

		// Token: 0x06009697 RID: 38551 RVA: 0x001C9F6C File Offset: 0x001C836C
		public void SetTemplate(ScrollItem a_template)
		{
			if (this.m_template != a_template)
			{
				if (this.m_template != null)
				{
					this.m_template.Destroy();
					this.m_template = null;
				}
				this.ClearScrollItems(true);
				this.m_template = a_template;
				this.m_template.SetActive(false);
			}
		}

		// Token: 0x06009698 RID: 38552 RVA: 0x001C9FBC File Offset: 0x001C83BC
		public void SetDataRange(int a_nMinDataID, int a_nMaxDataID)
		{
			this.m_nMinDataID = a_nMinDataID;
			this.m_nMaxDataID = a_nMaxDataID;
			this._TryForceBottom();
		}

		// Token: 0x06009699 RID: 38553 RVA: 0x001C9FD4 File Offset: 0x001C83D4
		private void _TryForceBottom()
		{
			if (this.m_eState == ComScrollList.EState.FouceBottom)
			{
				int num = 0;
				for (int i = this.m_arrScrollItems.Count - 1; i >= 0; i--)
				{
					if (this.m_arrScrollItems[i].IsActive())
					{
						num = this.m_arrScrollItems[i].GetDataID();
						break;
					}
				}
				int num2 = this.m_nMaxDataID - num;
				if (num2 > 0)
				{
					this.m_eState = ComScrollList.EState.LoadingDown;
					base.StartCoroutine(this._LoadScrollItemsDownDynamic(num, num2, true));
				}
			}
		}

		// Token: 0x0600969A RID: 38554 RVA: 0x001CA061 File Offset: 0x001C8461
		public void Clear()
		{
			this.m_template = null;
			this.m_nMinDataID = -1;
			this.m_nMaxDataID = -2;
			this.ClearScrollItems(true);
		}

		// Token: 0x0600969B RID: 38555 RVA: 0x001CA080 File Offset: 0x001C8480
		public void ClearScrollItems(bool a_bDestroy = false)
		{
			this.m_eState = ComScrollList.EState.Invalid;
			for (int i = 0; i < this.m_arrScrollItems.Count; i++)
			{
				this.m_arrScrollItems[i].Destroy();
			}
			this.m_arrScrollItems.Clear();
			base.StopAllCoroutines();
		}

		// Token: 0x0600969C RID: 38556 RVA: 0x001CA0D2 File Offset: 0x001C84D2
		public void InitScrollItems()
		{
			base.StartCoroutine(this._InitScrollItems());
		}

		// Token: 0x0600969D RID: 38557 RVA: 0x001CA0E4 File Offset: 0x001C84E4
		private IEnumerator _InitScrollItems()
		{
			if (this.m_eState == ComScrollList.EState.Invalid)
			{
				if (this.dynamicMainScrollItemCount <= 0)
				{
					yield break;
				}
				if (this.subScrollItemCount <= 0)
				{
					yield break;
				}
				if (this.m_template == null)
				{
					yield break;
				}
				this.m_eState = ComScrollList.EState.Normal;
				if (this.startFouce == ComScrollList.EStartFouce.Top)
				{
					int nCount = this.dynamicMainScrollItemCount * this.subScrollItemCount;
					int nCurrentDataID = this.m_nMinDataID;
					if (nCurrentDataID + nCount - 1 > this.m_nMaxDataID)
					{
						nCount = this.m_nMaxDataID - nCurrentDataID + 1;
					}
					int nRealCount = nCount;
					if (nCount % this.subScrollItemCount != 0)
					{
						nCount += this.subScrollItemCount - nCount % this.subScrollItemCount;
					}
					if (nCount <= 0)
					{
						yield break;
					}
					for (int k = 0; k < this.m_arrScrollItems.Count; k++)
					{
						this.m_arrScrollItems[k].SetActive(false);
					}
					yield return Yielders.EndOfFrame;
					for (int i = 0; i < nCount; i++)
					{
						ScrollItem scrollItem;
						if (i < this.m_arrScrollItems.Count)
						{
							scrollItem = this.m_arrScrollItems[i];
						}
						else
						{
							scrollItem = this.m_template.Clone();
							scrollItem.SetActive(false);
							scrollItem.SetAsLastSibling();
							this.m_arrScrollItems.Add(scrollItem);
						}
						scrollItem.Setup(nCurrentDataID);
						nCurrentDataID++;
						yield return Yielders.EndOfFrame;
					}
					int num = 0;
					while (num < this.m_arrScrollItems.Count && num < nRealCount)
					{
						this.m_arrScrollItems[num].SetActive(true);
						num++;
					}
					base.verticalNormalizedPosition = 1f;
				}
				else
				{
					int nCount2 = this.dynamicMainScrollItemCount * this.subScrollItemCount;
					int nCurrentDataID2 = this.m_nMaxDataID;
					if (nCurrentDataID2 - nCount2 + 1 < this.m_nMinDataID)
					{
						nCount2 = nCurrentDataID2 - this.m_nMinDataID + 1;
					}
					int nRealCount2 = nCount2;
					if (nCount2 % this.subScrollItemCount != 0)
					{
						nCount2 += this.subScrollItemCount - nCount2 % this.subScrollItemCount;
					}
					if (nCount2 <= 0)
					{
						yield break;
					}
					for (int l = 0; l < this.m_arrScrollItems.Count; l++)
					{
						this.m_arrScrollItems[l].SetActive(false);
					}
					yield return Yielders.EndOfFrame;
					int nIndex = this.m_arrScrollItems.Count - 1;
					for (int j = 0; j < nCount2; j++)
					{
						ScrollItem scrollItem2;
						if (nIndex >= 0)
						{
							scrollItem2 = this.m_arrScrollItems[nIndex];
							nIndex--;
						}
						else
						{
							scrollItem2 = this.m_template.Clone();
							scrollItem2.SetActive(false);
							scrollItem2.SetAsFirstSibling();
							this.m_arrScrollItems.Insert(0, scrollItem2);
						}
						scrollItem2.Setup(nCurrentDataID2);
						nCurrentDataID2--;
						yield return Yielders.EndOfFrame;
					}
					int num2 = 0;
					while (num2 < this.m_arrScrollItems.Count && num2 < nRealCount2)
					{
						this.m_arrScrollItems[num2].SetActive(true);
						num2++;
					}
					base.verticalNormalizedPosition = 0f;
					this.m_eState = ComScrollList.EState.FouceBottom;
				}
			}
			yield break;
		}

		// Token: 0x0600969E RID: 38558 RVA: 0x001CA100 File Offset: 0x001C8500
		private IEnumerator _LoadScrollItemsDownDynamic(int a_nCurrentMaxDataID, int a_nCount, bool a_bForceBottom = false)
		{
			if (this.m_eState == ComScrollList.EState.LoadingDown)
			{
				int nMainScrollItemCount = a_nCount / this.subScrollItemCount;
				if (a_nCount % this.subScrollItemCount != 0)
				{
					nMainScrollItemCount++;
				}
				for (int i = 0; i < nMainScrollItemCount; i++)
				{
					if (this.m_arrScrollItems.Count / this.subScrollItemCount >= this.mainScrollItemCount)
					{
						for (int m = 0; m < this.subScrollItemCount; m++)
						{
							ScrollItem scrollItem = this.m_arrScrollItems[0];
							this.m_arrScrollItems.RemoveAt(0);
							this.m_arrScrollItems.Add(scrollItem);
							scrollItem.SetActive(false);
							scrollItem.SetAsLastSibling();
						}
					}
					else
					{
						for (int j = 0; j < this.subScrollItemCount; j++)
						{
							ScrollItem scrollItem = this.m_template.Clone();
							this.m_arrScrollItems.Add(scrollItem);
							scrollItem.SetActive(false);
							scrollItem.SetAsLastSibling();
							if (j % 2 == 0)
							{
								yield return Yielders.EndOfFrame;
							}
						}
					}
				}
				yield return Yielders.EndOfFrame;
				int nStartIndex = this.m_arrScrollItems.Count / this.subScrollItemCount - nMainScrollItemCount;
				int nDataID = a_nCurrentMaxDataID;
				int nCount = 0;
				for (int k = 0; k < nMainScrollItemCount; k++)
				{
					for (int l = 0; l < this.subScrollItemCount; l++)
					{
						ScrollItem scrollItem = this.m_arrScrollItems[(nStartIndex + k) * this.subScrollItemCount + l];
						nDataID++;
						nCount++;
						if (nCount <= a_nCount)
						{
							scrollItem.Setup(nDataID);
							if (l % 2 == 0)
							{
								yield return Yielders.EndOfFrame;
							}
						}
					}
				}
				yield return Yielders.EndOfFrame;
				int nStartIndex2 = this.m_arrScrollItems.Count / this.subScrollItemCount - nMainScrollItemCount;
				int nCount2 = 0;
				for (int n = 0; n < nMainScrollItemCount; n++)
				{
					for (int num = 0; num < this.subScrollItemCount; num++)
					{
						ScrollItem scrollItem = this.m_arrScrollItems[(nStartIndex2 + n) * this.subScrollItemCount + num];
						nCount2++;
						if (nCount2 <= a_nCount)
						{
							scrollItem.SetActive(true);
						}
					}
				}
				yield return Yielders.EndOfFrame;
				if (a_bForceBottom)
				{
					this.m_eState = ComScrollList.EState.FouceBottom;
				}
				else
				{
					this.m_eState = ComScrollList.EState.Normal;
				}
			}
			yield break;
		}

		// Token: 0x0600969F RID: 38559 RVA: 0x001CA130 File Offset: 0x001C8530
		private IEnumerator _LoadScrollItemsUpDynamic(int a_nCurrentMinDataID, int a_nCount)
		{
			if (this.m_eState == ComScrollList.EState.LoadingUp)
			{
				int nMainScrollItemCount = a_nCount / this.subScrollItemCount;
				if (a_nCount % this.subScrollItemCount != 0)
				{
					nMainScrollItemCount++;
				}
				for (int i = 0; i < nMainScrollItemCount; i++)
				{
					if (this.m_arrScrollItems.Count / this.subScrollItemCount >= this.mainScrollItemCount)
					{
						for (int m = 0; m < this.subScrollItemCount; m++)
						{
							ScrollItem scrollItem = this.m_arrScrollItems[this.m_arrScrollItems.Count - 1];
							this.m_arrScrollItems.RemoveAt(this.m_arrScrollItems.Count - 1);
							this.m_arrScrollItems.Insert(0, scrollItem);
							scrollItem.SetActive(false);
							scrollItem.SetAsFirstSibling();
						}
					}
					else
					{
						for (int j = 0; j < this.subScrollItemCount; j++)
						{
							ScrollItem scrollItem = this.m_template.Clone();
							this.m_arrScrollItems.Insert(0, scrollItem);
							scrollItem.SetActive(false);
							scrollItem.SetAsFirstSibling();
							if (j % 2 == 0)
							{
								yield return Yielders.EndOfFrame;
							}
						}
					}
				}
				yield return Yielders.EndOfFrame;
				int nDataID = a_nCurrentMinDataID;
				int nCount = 0;
				for (int k = nMainScrollItemCount - 1; k >= 0; k--)
				{
					for (int l = this.subScrollItemCount - 1; l >= 0; l--)
					{
						ScrollItem scrollItem = this.m_arrScrollItems[k * this.subScrollItemCount + l];
						nDataID--;
						nCount++;
						if (nCount <= a_nCount)
						{
							scrollItem.Setup(nDataID);
							if (l % 2 == 0)
							{
								yield return Yielders.EndOfFrame;
							}
						}
					}
				}
				yield return Yielders.EndOfFrame;
				float fOldPos = 0f;
				ScrollItem forceScrollItem = this._GetScrollItem(a_nCurrentMinDataID);
				if (forceScrollItem != null)
				{
					fOldPos = forceScrollItem.GetPosInContent().y;
				}
				int nCount2 = 0;
				for (int n = nMainScrollItemCount - 1; n >= 0; n--)
				{
					for (int num = this.subScrollItemCount - 1; num >= 0; num--)
					{
						ScrollItem scrollItem = this.m_arrScrollItems[n * this.subScrollItemCount + num];
						nCount2++;
						if (nCount2 <= a_nCount)
						{
							scrollItem.SetActive(true);
						}
					}
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(base.content);
				if (forceScrollItem != null)
				{
					float num2 = Mathf.Abs(forceScrollItem.GetPosInContent().y - fOldPos);
					base.verticalNormalizedPosition = 1f - num2 / (base.content.rect.height - base.viewport.rect.height);
				}
				else
				{
					base.verticalNormalizedPosition = 0f;
				}
				yield return Yielders.EndOfFrame;
				this.m_eState = ComScrollList.EState.Normal;
			}
			yield break;
		}

		// Token: 0x060096A0 RID: 38560 RVA: 0x001CA15C File Offset: 0x001C855C
		private ScrollItem _GetScrollItem(int a_nID)
		{
			for (int i = 0; i < this.m_arrScrollItems.Count; i++)
			{
				if (this.m_arrScrollItems[i].GetDataID() == a_nID)
				{
					return this.m_arrScrollItems[i];
				}
			}
			return null;
		}

		// Token: 0x04004D60 RID: 19808
		public int mainScrollItemCount = 5;

		// Token: 0x04004D61 RID: 19809
		public int dynamicMainScrollItemCount = 2;

		// Token: 0x04004D62 RID: 19810
		public int subScrollItemCount = 4;

		// Token: 0x04004D63 RID: 19811
		public ComScrollList.EStartFouce startFouce;

		// Token: 0x04004D64 RID: 19812
		private ComScrollList.EState m_eState;

		// Token: 0x04004D65 RID: 19813
		private ScrollItem m_template;

		// Token: 0x04004D66 RID: 19814
		private int m_nMinDataID = -1;

		// Token: 0x04004D67 RID: 19815
		private int m_nMaxDataID = -1;

		// Token: 0x04004D68 RID: 19816
		private List<ScrollItem> m_arrScrollItems = new List<ScrollItem>();

		// Token: 0x04004D69 RID: 19817
		private bool m_bDragging;

		// Token: 0x02000F12 RID: 3858
		public enum EStartFouce
		{
			// Token: 0x04004D6B RID: 19819
			Top,
			// Token: 0x04004D6C RID: 19820
			Bottom
		}

		// Token: 0x02000F13 RID: 3859
		private enum EState
		{
			// Token: 0x04004D6E RID: 19822
			Invalid,
			// Token: 0x04004D6F RID: 19823
			LoadingUp,
			// Token: 0x04004D70 RID: 19824
			Normal,
			// Token: 0x04004D71 RID: 19825
			FouceBottom,
			// Token: 0x04004D72 RID: 19826
			LoadingDown,
			// Token: 0x04004D73 RID: 19827
			PrepareLoadingDown,
			// Token: 0x04004D74 RID: 19828
			PrepareLoadingUp
		}
	}
}
