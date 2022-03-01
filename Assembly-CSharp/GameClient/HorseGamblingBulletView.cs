using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001680 RID: 5760
	public class HorseGamblingBulletView : MonoBehaviour
	{
		// Token: 0x0600E278 RID: 57976 RVA: 0x003A2CF4 File Offset: 0x003A10F4
		private void Awake()
		{
			this.mButtonAdd.SafeAddOnClickListener(new UnityAction(this.OnAddClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this.OnChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this.OnChange));
			this.mTextCount.SafeSetText(Utility.ToThousandsSeparator((ulong)((long)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mBulletItemId, false))));
		}

		// Token: 0x0600E279 RID: 57977 RVA: 0x003A2D70 File Offset: 0x003A1170
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this.OnChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this.OnChange));
		}

		// Token: 0x0600E27A RID: 57978 RVA: 0x003A2DA8 File Offset: 0x003A11A8
		private void OnChange(UIEvent uiEvent)
		{
			this.mTextCount.SafeSetText(Utility.ToThousandsSeparator((ulong)((long)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mBulletItemId, false))));
		}

		// Token: 0x0600E27B RID: 57979 RVA: 0x003A2DCC File Offset: 0x003A11CC
		private void OnAddClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<HorseGamblingSupplyFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HorseGamblingExchangeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x04008782 RID: 34690
		[SerializeField]
		private int mBulletItemId;

		// Token: 0x04008783 RID: 34691
		[SerializeField]
		private Text mTextCount;

		// Token: 0x04008784 RID: 34692
		[SerializeField]
		private Button mButtonAdd;
	}
}
