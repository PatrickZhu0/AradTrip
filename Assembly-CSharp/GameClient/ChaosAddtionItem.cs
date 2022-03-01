using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200181A RID: 6170
	public class ChaosAddtionItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F318 RID: 62232 RVA: 0x0041AF4B File Offset: 0x0041934B
		public void Init(int id)
		{
			this.InitItemes(id);
		}

		// Token: 0x0600F319 RID: 62233 RVA: 0x0041AF54 File Offset: 0x00419354
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
			this.des.SafeSetText(tableItem2.Name);
		}

		// Token: 0x0600F31A RID: 62234 RVA: 0x0041AFC4 File Offset: 0x004193C4
		public void Dispose()
		{
		}

		// Token: 0x04009594 RID: 38292
		[SerializeField]
		private Image iconImage;

		// Token: 0x04009595 RID: 38293
		[SerializeField]
		private Text des;
	}
}
