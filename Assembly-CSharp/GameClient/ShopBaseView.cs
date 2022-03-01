using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A6D RID: 6765
	public class ShopBaseView : MonoBehaviour
	{
		// Token: 0x060109BB RID: 68027 RVA: 0x004B26E3 File Offset: 0x004B0AE3
		protected virtual void _InitShopView()
		{
			this._InitShopTitle();
			this._InitShopMoneyView();
			this._InitShopTabList();
			this._PlayShopNpcSound(NpcVoiceComponent.SoundEffectType.SET_Start);
		}

		// Token: 0x060109BC RID: 68028 RVA: 0x004B26FE File Offset: 0x004B0AFE
		protected virtual void _InitShopTitle()
		{
		}

		// Token: 0x060109BD RID: 68029 RVA: 0x004B2700 File Offset: 0x004B0B00
		protected virtual void _InitShopMoneyView()
		{
		}

		// Token: 0x060109BE RID: 68030 RVA: 0x004B2702 File Offset: 0x004B0B02
		protected virtual void _InitShopTabList()
		{
		}

		// Token: 0x060109BF RID: 68031 RVA: 0x004B2704 File Offset: 0x004B0B04
		protected virtual void _PlayShopNpcSound(NpcVoiceComponent.SoundEffectType soundEffType)
		{
		}

		// Token: 0x060109C0 RID: 68032 RVA: 0x004B2706 File Offset: 0x004B0B06
		protected virtual void _InitData()
		{
		}

		// Token: 0x060109C1 RID: 68033 RVA: 0x004B2708 File Offset: 0x004B0B08
		protected virtual void _ClearData()
		{
		}
	}
}
