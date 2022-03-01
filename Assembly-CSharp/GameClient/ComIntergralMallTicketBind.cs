using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200178C RID: 6028
	public class ComIntergralMallTicketBind : MonoBehaviour
	{
		// Token: 0x0600EE0D RID: 60941 RVA: 0x003FE1CD File Offset: 0x003FC5CD
		private void Awake()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x0600EE0E RID: 60942 RVA: 0x003FE1F5 File Offset: 0x003FC5F5
		private void Start()
		{
			this.SetAddBtn();
			this.InitIntergralIcon();
			this.UpdateTicketCount();
		}

		// Token: 0x0600EE0F RID: 60943 RVA: 0x003FE20C File Offset: 0x003FC60C
		private void InitIntergralIcon()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mIntergralItemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.mIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mIcon, tableItem.Icon, true);
			}
		}

		// Token: 0x0600EE10 RID: 60944 RVA: 0x003FE25F File Offset: 0x003FC65F
		private void UpdateTicketCount()
		{
			if (this.mCount != null)
			{
				this.mCount.text = Utility.ToThousandsSeparator(DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket);
			}
		}

		// Token: 0x0600EE11 RID: 60945 RVA: 0x003FE28C File Offset: 0x003FC68C
		private void SetAddBtn()
		{
			if (this.mAddBtn != null)
			{
				this.mAddBtn.onClick.AddListener(new UnityAction(this.OnAddBtnClick));
			}
		}

		// Token: 0x0600EE12 RID: 60946 RVA: 0x003FE2BC File Offset: 0x003FC6BC
		private void OnAddBtnClick()
		{
			ItemComeLink.OnLink(this.mIntergralItemId, 0, false, null, false, false, false, null, string.Empty);
		}

		// Token: 0x0600EE13 RID: 60947 RVA: 0x003FE2E0 File Offset: 0x003FC6E0
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			if (eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_INTERGRALMALL_TICKET)
			{
				this.UpdateTicketCount();
			}
		}

		// Token: 0x0600EE14 RID: 60948 RVA: 0x003FE2F0 File Offset: 0x003FC6F0
		private void OnDestroy()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x04009174 RID: 37236
		[SerializeField]
		private Image mIcon;

		// Token: 0x04009175 RID: 37237
		[SerializeField]
		private Text mCount;

		// Token: 0x04009176 RID: 37238
		[SerializeField]
		private Button mAddBtn;

		// Token: 0x04009177 RID: 37239
		[SerializeField]
		private int mIntergralItemId;
	}
}
