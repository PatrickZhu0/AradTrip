using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200004C RID: 76
	public class ComPackagePetRedPoint : MonoBehaviour
	{
		// Token: 0x060001CF RID: 463 RVA: 0x0000FE8C File Offset: 0x0000E28C
		private void _onEventCom(UIEvent ui)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				return;
			}
			bool flag = DataManager<PetDataManager>.GetInstance().IsNeedShowOnUsePetsRedPoint() || DataManager<PetDataManager>.GetInstance().IsNeedShowPetEggRedPoint() || DataManager<PetDataManager>.GetInstance().IsNeedShowPetRedPoint();
			if (flag)
			{
				if (this.onTrue != null)
				{
					this.onTrue.Invoke();
				}
			}
			else if (this.onFalse != null)
			{
				this.onFalse.Invoke();
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000FF14 File Offset: 0x0000E314
		private void Awake()
		{
			this._onEventCom(null);
			for (int i = 0; i < this.waitOnEventList.Length; i++)
			{
				UIEventSystem.GetInstance().RegisterEventHandler(this.waitOnEventList[i], new ClientEventSystem.UIEventHandler(this._onEventCom));
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000FF60 File Offset: 0x0000E360
		private void OnDestroy()
		{
			for (int i = 0; i < this.waitOnEventList.Length; i++)
			{
				UIEventSystem.GetInstance().UnRegisterEventHandler(this.waitOnEventList[i], new ClientEventSystem.UIEventHandler(this._onEventCom));
			}
		}

		// Token: 0x040001C1 RID: 449
		public UnityEvent onTrue;

		// Token: 0x040001C2 RID: 450
		public UnityEvent onFalse;

		// Token: 0x040001C3 RID: 451
		private EUIEventID[] waitOnEventList = new EUIEventID[]
		{
			EUIEventID.ItemNotifyGet,
			EUIEventID.ItemNotifyRemoved,
			EUIEventID.ItemCountChanged,
			EUIEventID.ItemNewStateChanged,
			EUIEventID.ItemUseSuccess,
			EUIEventID.PetInfoInited,
			EUIEventID.PetSlotChanged,
			EUIEventID.PetFeedSuccess,
			EUIEventID.PetItemsInfoUpdate,
			EUIEventID.PetGoldFeedClick,
			EUIEventID.PetTabClick
		};
	}
}
