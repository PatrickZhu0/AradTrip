using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200198F RID: 6543
	public class PKSeasonDetaiFashionItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600FEA7 RID: 65191 RVA: 0x0046743C File Offset: 0x0046583C
		public void InitItem()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(560, string.Empty, string.Empty);
			int value = tableItem.Value;
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(value, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("[PKSeasonDetaiFashionItem]检查系统数值Id = {0}的Value = {1}是否异常", new object[]
				{
					tableItem.ID,
					tableItem.Value
				});
			}
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemRoot);
			}
			this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClick));
			this.mName.text = this.mDesc;
		}

		// Token: 0x0600FEA8 RID: 65192 RVA: 0x004674F1 File Offset: 0x004658F1
		private void OnItemClick(GameObject obj, ItemData item)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, item.TableID, string.Empty);
		}

		// Token: 0x0600FEA9 RID: 65193 RVA: 0x0046750F File Offset: 0x0046590F
		public void Dispose()
		{
			if (this.comItem != null)
			{
				this.comItem = null;
			}
		}

		// Token: 0x0600FEAA RID: 65194 RVA: 0x00467529 File Offset: 0x00465929
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x0400A09C RID: 41116
		[SerializeField]
		private Text mName;

		// Token: 0x0400A09D RID: 41117
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x0400A09E RID: 41118
		[SerializeField]
		private string mDesc = "至尊王者送时装";

		// Token: 0x0400A09F RID: 41119
		private ComItem comItem;
	}
}
