using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000EFB RID: 3835
	public class ComItemGrid : MonoBehaviour
	{
		// Token: 0x0600960B RID: 38411 RVA: 0x001C605C File Offset: 0x001C445C
		private void Awake()
		{
			this.InitGrid();
		}

		// Token: 0x0600960C RID: 38412 RVA: 0x001C6064 File Offset: 0x001C4464
		private void OnDestroy()
		{
			this.UnInitGrid();
		}

		// Token: 0x0600960D RID: 38413 RVA: 0x001C606C File Offset: 0x001C446C
		public void InitGrid()
		{
			if (null == this.gridParentGo)
			{
				return;
			}
			this.comItemGrid = ComItemManager.Create(this.gridParentGo);
			this.SetGridActive(false);
			this.highestGradeTag.CustomActive(false);
		}

		// Token: 0x0600960E RID: 38414 RVA: 0x001C60A4 File Offset: 0x001C44A4
		public void UnInitGrid()
		{
			if (null != this.comItemGrid)
			{
				ComItemManager.Destroy(this.comItemGrid);
				this.comItemGrid = null;
			}
		}

		// Token: 0x0600960F RID: 38415 RVA: 0x001C60C9 File Offset: 0x001C44C9
		public void SetGridActive(bool bActive)
		{
			if (null != this.gridParentGo)
			{
				this.gridParentGo.CustomActive(bActive);
			}
			if (!bActive)
			{
				this.highestGradeTag.CustomActive(false);
			}
		}

		// Token: 0x06009610 RID: 38416 RVA: 0x001C60FC File Offset: 0x001C44FC
		public void SetGridItemData(ItemData itemData, bool needClickEnabled = true, bool isHighestGradeItem = false)
		{
			if (null != this.comItemGrid && itemData != null)
			{
				if (needClickEnabled)
				{
					ComItem comItem = this.comItemGrid;
					if (ComItemGrid.<>f__mg$cache0 == null)
					{
						ComItemGrid.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem.Setup(itemData, ComItemGrid.<>f__mg$cache0);
				}
				else
				{
					this.comItemGrid.Setup(itemData, null);
				}
				this.highestGradeTag.CustomActive(isHighestGradeItem);
			}
		}

		// Token: 0x04004CE6 RID: 19686
		public GameObject gridParentGo;

		// Token: 0x04004CE7 RID: 19687
		public GameObject highestGradeTag;

		// Token: 0x04004CE8 RID: 19688
		private ComItem comItemGrid;

		// Token: 0x04004CE9 RID: 19689
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
