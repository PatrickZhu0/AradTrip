using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AD2 RID: 6866
	public class BeadUpgradeResultView : MonoBehaviour
	{
		// Token: 0x06010DA2 RID: 69026 RVA: 0x004CE2E0 File Offset: 0x004CC6E0
		public void InitView(ClientFrame clientFrame, BeadUpgradeResultData data)
		{
			this.clientFrame = clientFrame;
			ComItem comItem = ComItemManager.Create(this.mItemParent);
			ItemData itemData;
			if (data.mountedType == 1)
			{
				itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(data.mBeadID);
			}
			else
			{
				itemData = DataManager<ItemDataManager>.GetInstance().GetItem(data.mBeadGUID);
			}
			if (itemData != null)
			{
				ComItem comItem2 = comItem;
				ItemData item = itemData;
				if (BeadUpgradeResultView.<>f__mg$cache0 == null)
				{
					BeadUpgradeResultView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem2.Setup(item, BeadUpgradeResultView.<>f__mg$cache0);
			}
			this.mItemName.text = itemData.GetColorName(string.Empty, false);
			this.mItemArrt.text = string.Format("<color={0}>宝珠属性:</color>", "#0FCF6Aff");
			Text text = this.mItemArrt;
			text.text += DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(itemData.TableID, false);
			Text text2 = this.mItemArrt;
			text2.text += "\n";
			if (data.mBuffID > 0)
			{
				Text text3 = this.mItemArrt;
				text3.text += string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(data.mBuffID));
			}
			if (this.mOkBtn != null)
			{
				this.mOkBtn.onClick.RemoveAllListeners();
				this.mOkBtn.onClick.AddListener(delegate()
				{
					(clientFrame as BeadUpgradeResultFrame).Close(false);
				});
			}
		}

		// Token: 0x06010DA3 RID: 69027 RVA: 0x004CE45D File Offset: 0x004CC85D
		private void OnDestroy()
		{
			if (this.mOkBtn != null)
			{
				this.mOkBtn.onClick.RemoveAllListeners();
			}
			this.clientFrame = null;
		}

		// Token: 0x0400ACEA RID: 44266
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400ACEB RID: 44267
		[SerializeField]
		private Text mItemName;

		// Token: 0x0400ACEC RID: 44268
		[SerializeField]
		private Text mItemArrt;

		// Token: 0x0400ACED RID: 44269
		[SerializeField]
		private Button mOkBtn;

		// Token: 0x0400ACEE RID: 44270
		private ClientFrame clientFrame;

		// Token: 0x0400ACEF RID: 44271
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
