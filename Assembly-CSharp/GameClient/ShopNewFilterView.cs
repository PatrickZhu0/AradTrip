using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A7E RID: 6782
	public class ShopNewFilterView : MonoBehaviour
	{
		// Token: 0x06010A66 RID: 68198 RVA: 0x004B6EB0 File Offset: 0x004B52B0
		public void InitShopNewFilterView(ShopNewFilterData firstFilterData, OnShopNewFilterElementItemTabValueChanged firstFilterElementItemTabValueChanged, ShopNewFilterData secondFilterData, OnShopNewFilterElementItemTabValueChanged secondFilterElementItemTabValueChanged, bool isShowFilterTitle = false)
		{
			if (this.firstFilterControl != null)
			{
				if (firstFilterData != null && firstFilterData.FilterType != ShopTable.eFilter.SF_NONE && firstFilterData.FilterType != ShopTable.eFilter.SF_PLAY_OCCU)
				{
					this.firstFilterControl.gameObject.CustomActive(true);
					this.firstFilterControl.InitFilterControl(firstFilterData, firstFilterElementItemTabValueChanged, new Action(this.OnResetFilterListInFilterView), isShowFilterTitle);
				}
				else
				{
					this.firstFilterControl.gameObject.CustomActive(false);
				}
			}
			if (this.secondFilterControl != null)
			{
				if (secondFilterData != null && secondFilterData.FilterType != ShopTable.eFilter.SF_NONE && secondFilterData.FilterType != ShopTable.eFilter.SF_PLAY_OCCU)
				{
					this.secondFilterControl.gameObject.CustomActive(true);
					this.secondFilterControl.InitFilterControl(secondFilterData, secondFilterElementItemTabValueChanged, new Action(this.OnResetFilterListInFilterView), isShowFilterTitle);
				}
				else
				{
					this.secondFilterControl.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x06010A67 RID: 68199 RVA: 0x004B6F9E File Offset: 0x004B539E
		private void OnResetFilterListInFilterView()
		{
			if (this.firstFilterControl != null)
			{
				this.firstFilterControl.ResetFilterList();
			}
			if (this.secondFilterControl != null)
			{
				this.secondFilterControl.ResetFilterList();
			}
		}

		// Token: 0x0400AA16 RID: 43542
		[SerializeField]
		private ShopNewFilterControl firstFilterControl;

		// Token: 0x0400AA17 RID: 43543
		[SerializeField]
		private ShopNewFilterControl secondFilterControl;
	}
}
