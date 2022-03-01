using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A6F RID: 6767
	public class CommonShopButtonControl : MonoBehaviour
	{
		// Token: 0x060109E0 RID: 68064 RVA: 0x004B344A File Offset: 0x004B184A
		private void Awake()
		{
			if (this.shopButton != null)
			{
				this.shopButton.onClick.RemoveAllListeners();
				this.shopButton.onClick.AddListener(new UnityAction(this.OnShopButtonClicked));
			}
		}

		// Token: 0x060109E1 RID: 68065 RVA: 0x004B3489 File Offset: 0x004B1889
		private void OnDestroy()
		{
			if (this.shopButton != null)
			{
				this.shopButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x060109E2 RID: 68066 RVA: 0x004B34AC File Offset: 0x004B18AC
		private void Start()
		{
			this.UpdateShopButtonControl();
		}

		// Token: 0x060109E3 RID: 68067 RVA: 0x004B34B4 File Offset: 0x004B18B4
		private void OnShopButtonClicked()
		{
			if (this.shopId <= 0)
			{
				return;
			}
			DataManager<ShopNewDataManager>.GetInstance().JumpToShopById(this.shopId);
		}

		// Token: 0x060109E4 RID: 68068 RVA: 0x004B34D4 File Offset: 0x004B18D4
		private void UpdateShopButtonControl()
		{
			if (this.shopId <= 0)
			{
				return;
			}
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this.shopId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.shopName != null)
			{
				this.shopName.text = tableItem.ShopName;
			}
		}

		// Token: 0x060109E5 RID: 68069 RVA: 0x004B3532 File Offset: 0x004B1932
		public void SetShopId(int id)
		{
			this.shopId = id;
			this.UpdateShopButtonControl();
		}

		// Token: 0x0400A993 RID: 43411
		[SerializeField]
		private int shopId;

		// Token: 0x0400A994 RID: 43412
		[Space(15f)]
		[Header("Control")]
		[Space(15f)]
		[SerializeField]
		private Button shopButton;

		// Token: 0x0400A995 RID: 43413
		[SerializeField]
		private Text shopName;

		// Token: 0x0400A996 RID: 43414
		[SerializeField]
		private Image shopImage;
	}
}
