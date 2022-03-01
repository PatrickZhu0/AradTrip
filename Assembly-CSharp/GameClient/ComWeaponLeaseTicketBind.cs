using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A62 RID: 6754
	public class ComWeaponLeaseTicketBind : MonoBehaviour
	{
		// Token: 0x06010941 RID: 67905 RVA: 0x004AFAD2 File Offset: 0x004ADED2
		private void Awake()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010942 RID: 67906 RVA: 0x004AFAFA File Offset: 0x004ADEFA
		private void Start()
		{
			this.SetTicketIcon();
			this.SetOnAddClick();
			this.UpdateTicketCount();
		}

		// Token: 0x06010943 RID: 67907 RVA: 0x004AFB10 File Offset: 0x004ADF10
		private void SetTicketIcon()
		{
			if (this.mIcon)
			{
				string ownedItemIconPath = DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(this.mWeaponLeaseTicketItemId);
				ETCImageLoader.LoadSprite(ref this.mIcon, ownedItemIconPath, true);
			}
		}

		// Token: 0x06010944 RID: 67908 RVA: 0x004AFB4C File Offset: 0x004ADF4C
		private void UpdateTicketCount()
		{
			if (this.mCount)
			{
				this.mCount.text = DataManager<PlayerBaseData>.GetInstance().WeaponLeaseTicket.ToString() + "/" + this.mWeaponLeaseTicketTatleCount.ToString();
			}
		}

		// Token: 0x06010945 RID: 67909 RVA: 0x004AFBA7 File Offset: 0x004ADFA7
		private void SetOnAddClick()
		{
			if (this.mAddBtn)
			{
				this.mAddBtn.onClick.RemoveAllListeners();
				this.mAddBtn.onClick.AddListener(new UnityAction(this.OnAddBtnClick));
			}
		}

		// Token: 0x06010946 RID: 67910 RVA: 0x004AFBE8 File Offset: 0x004ADFE8
		private void OnAddBtnClick()
		{
			ItemComeLink.OnLink(this.mWeaponLeaseTicketItemId, 0, false, null, false, false, false, null, string.Empty);
		}

		// Token: 0x06010947 RID: 67911 RVA: 0x004AFC0C File Offset: 0x004AE00C
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			if (eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_WEAPON_LEASE_TICKET)
			{
				this.UpdateTicketCount();
			}
		}

		// Token: 0x06010948 RID: 67912 RVA: 0x004AFC1C File Offset: 0x004AE01C
		private void OnDestroy()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x0400A90E RID: 43278
		[SerializeField]
		private Button mAddBtn;

		// Token: 0x0400A90F RID: 43279
		[SerializeField]
		private Image mIcon;

		// Token: 0x0400A910 RID: 43280
		[SerializeField]
		private Text mCount;

		// Token: 0x0400A911 RID: 43281
		[SerializeField]
		private int mWeaponLeaseTicketItemId;

		// Token: 0x0400A912 RID: 43282
		[SerializeField]
		private int mWeaponLeaseTicketTatleCount;
	}
}
