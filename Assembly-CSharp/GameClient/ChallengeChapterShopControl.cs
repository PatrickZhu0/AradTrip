using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014BF RID: 5311
	public class ChallengeChapterShopControl : MonoBehaviour
	{
		// Token: 0x0600CDED RID: 52717 RVA: 0x0032BB7A File Offset: 0x00329F7A
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CDEE RID: 52718 RVA: 0x0032BB82 File Offset: 0x00329F82
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CDEF RID: 52719 RVA: 0x0032BB90 File Offset: 0x00329F90
		private void BindEvents()
		{
			if (this.shopButton != null)
			{
				this.shopButton.onClick.RemoveAllListeners();
				this.shopButton.onClick.AddListener(new UnityAction(this.OnShopButtonClick));
			}
		}

		// Token: 0x0600CDF0 RID: 52720 RVA: 0x0032BBCF File Offset: 0x00329FCF
		private void UnBindEvents()
		{
			if (this.shopButton != null)
			{
				this.shopButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CDF1 RID: 52721 RVA: 0x0032BBF2 File Offset: 0x00329FF2
		private void ClearData()
		{
			this._dungeonId = 0;
			this._chapterShopId = 0;
		}

		// Token: 0x0600CDF2 RID: 52722 RVA: 0x0032BC02 File Offset: 0x0032A002
		public void InitShopControl(int dungeonId)
		{
			this._dungeonId = dungeonId;
			this.UpdateChapterExtraContent();
		}

		// Token: 0x0600CDF3 RID: 52723 RVA: 0x0032BC14 File Offset: 0x0032A014
		private void UpdateChapterExtraContent()
		{
			base.gameObject.CustomActive(false);
			this._chapterShopId = 0;
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._dungeonId, string.Empty, string.Empty);
			if (tableItem == null || string.IsNullOrEmpty(tableItem.ExchangeStoreEntrance))
			{
				return;
			}
			string[] array = tableItem.ExchangeStoreEntrance.Split(new char[]
			{
				'|'
			});
			if (array.Length == 2)
			{
				this._chapterShopId = int.Parse(array[0]);
				string path = array[1];
				if (this.shopIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.shopIcon, path, true);
				}
				if (this.shopName != null)
				{
					ShopTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this._chapterShopId, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						this.shopName.text = tableItem2.ShopName;
					}
				}
				base.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600CDF4 RID: 52724 RVA: 0x0032BD06 File Offset: 0x0032A106
		private void OnShopButtonClick()
		{
			if (this._chapterShopId <= 0)
			{
				Logger.LogErrorFormat("ChapterShopId is less zero and shopId is {0}", new object[]
				{
					this._chapterShopId
				});
				return;
			}
			DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(this._chapterShopId, 0, 0, -1);
		}

		// Token: 0x0400783D RID: 30781
		private int _dungeonId;

		// Token: 0x0400783E RID: 30782
		private int _chapterShopId;

		// Token: 0x0400783F RID: 30783
		[Space(20f)]
		[Header("ShopRoot")]
		[Space(10f)]
		[SerializeField]
		private Button shopButton;

		// Token: 0x04007840 RID: 30784
		[SerializeField]
		private Image shopIcon;

		// Token: 0x04007841 RID: 30785
		[SerializeField]
		private Text shopName;
	}
}
