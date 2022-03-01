using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001921 RID: 6433
	public class VanityBonusItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600FA6D RID: 64109 RVA: 0x00449617 File Offset: 0x00447A17
		public void Init(int id)
		{
			this.InitItemes(id);
		}

		// Token: 0x0600FA6E RID: 64110 RVA: 0x00449620 File Offset: 0x00447A20
		private void InitItemes(int id)
		{
			BuffRandomTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffRandomTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(tableItem.BuffId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.iconImage, tableItem2.Icon, true);
			this.des.text = tableItem2.Name;
		}

		// Token: 0x0600FA6F RID: 64111 RVA: 0x00449690 File Offset: 0x00447A90
		public void Dispose()
		{
		}

		// Token: 0x04009C6A RID: 40042
		[SerializeField]
		private Image iconImage;

		// Token: 0x04009C6B RID: 40043
		[SerializeField]
		private Text des;
	}
}
