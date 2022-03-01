using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000EF0 RID: 3824
[RequireComponent(typeof(Button))]
public class ComGoToShopButton : MonoBehaviour
{
	// Token: 0x060095B3 RID: 38323 RVA: 0x001C423C File Offset: 0x001C263C
	private void Awake()
	{
		this.mButton = base.GetComponent<Button>();
		this.mButton.onClick.AddListener(new UnityAction(this.OnButtonClick));
	}

	// Token: 0x060095B4 RID: 38324 RVA: 0x001C4266 File Offset: 0x001C2666
	private void OnDestroy()
	{
		this.mButton.onClick.RemoveListener(new UnityAction(this.OnButtonClick));
	}

	// Token: 0x060095B5 RID: 38325 RVA: 0x001C4284 File Offset: 0x001C2684
	private void OnButtonClick()
	{
		DataManager<ShopDataManager>.GetInstance().OpenShop(this.mShopId, this.mShopLinkID, this.mShopTabID, null, null, ShopFrame.ShopFrameMode.SFM_MAIN_FRAME, 0, -1);
	}

	// Token: 0x04004C9A RID: 19610
	[SerializeField]
	private int mShopId;

	// Token: 0x04004C9B RID: 19611
	[SerializeField]
	private int mShopLinkID;

	// Token: 0x04004C9C RID: 19612
	[SerializeField]
	private int mShopTabID;

	// Token: 0x04004C9D RID: 19613
	private Button mButton;
}
