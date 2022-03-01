using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000071 RID: 113
	internal class EnchantmentsRedBinder : MonoBehaviour
	{
		// Token: 0x0600026C RID: 620 RVA: 0x00012C94 File Offset: 0x00011094
		private void Start()
		{
			this._UpdateRedPoint();
			EnchantmentsCardManager instance = DataManager<EnchantmentsCardManager>.GetInstance();
			instance.onTabMarkChanged = (EnchantmentsCardManager.OnTabMarkChanged)Delegate.Combine(instance.onTabMarkChanged, new EnchantmentsCardManager.OnTabMarkChanged(this._OnTabMarkChanged));
			EnchantmentsCardManager instance2 = DataManager<EnchantmentsCardManager>.GetInstance();
			instance2.onUpdateCard = (EnchantmentsCardManager.OnUpdateCard)Delegate.Combine(instance2.onUpdateCard, new EnchantmentsCardManager.OnUpdateCard(this._OnUpdateCard));
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00012CF4 File Offset: 0x000110F4
		private void OnDestroy()
		{
			EnchantmentsCardManager instance = DataManager<EnchantmentsCardManager>.GetInstance();
			instance.onTabMarkChanged = (EnchantmentsCardManager.OnTabMarkChanged)Delegate.Remove(instance.onTabMarkChanged, new EnchantmentsCardManager.OnTabMarkChanged(this._OnTabMarkChanged));
			EnchantmentsCardManager instance2 = DataManager<EnchantmentsCardManager>.GetInstance();
			instance2.onUpdateCard = (EnchantmentsCardManager.OnUpdateCard)Delegate.Remove(instance2.onUpdateCard, new EnchantmentsCardManager.OnUpdateCard(this._OnUpdateCard));
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00012D4D File Offset: 0x0001114D
		private void _OnTabMarkChanged(ulong guid)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00012D55 File Offset: 0x00011155
		private void _OnUpdateCard(EnchantmentsCardData data)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00012D5D File Offset: 0x0001115D
		private void _UpdateRedPoint()
		{
			base.gameObject.CustomActive(DataManager<EnchantmentsCardManager>.GetInstance().HasNewCard());
		}
	}
}
