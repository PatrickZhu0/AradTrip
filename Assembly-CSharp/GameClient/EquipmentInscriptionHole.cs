using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B3F RID: 6975
	public class EquipmentInscriptionHole : MonoBehaviour
	{
		// Token: 0x060111CE RID: 70094 RVA: 0x004E8E73 File Offset: 0x004E7273
		private void OnDestroy()
		{
			this.mData = null;
			this.mState = InscriptionMosaicState.None;
		}

		// Token: 0x060111CF RID: 70095 RVA: 0x004E8E83 File Offset: 0x004E7283
		public void OnItemVisiable(InscriptionHoleData holeData)
		{
			this.mData = holeData;
			this.UpdateState();
			this.InitInterface();
		}

		// Token: 0x060111D0 RID: 70096 RVA: 0x004E8E98 File Offset: 0x004E7298
		private void UpdateState()
		{
			if (!this.mData.IsOpenHole)
			{
				this.mStateCotrol.Key = "CanOpenHole";
				this.mState = InscriptionMosaicState.CanOpenHole;
			}
			else if (this.mData.InscriptionId == 0)
			{
				this.mStateCotrol.Key = "CanBeSet";
				this.mState = InscriptionMosaicState.CanBeSet;
			}
			else if (this.mData.InscriptionId > 0)
			{
				this.mStateCotrol.Key = "HasBeenSet";
				this.mState = InscriptionMosaicState.HasBeenSet;
			}
		}

		// Token: 0x060111D1 RID: 70097 RVA: 0x004E8F28 File Offset: 0x004E7328
		private void InitInterface()
		{
			InscriptionHoleSetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionHoleSetTable>(this.mData.Type, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			switch (this.mState)
			{
			case InscriptionMosaicState.CanOpenHole:
				if (this.mCanOpenHoleBackGround != null)
				{
					ETCImageLoader.LoadSprite(ref this.mCanOpenHoleBackGround, tableItem.InscriptionHolePicture, true);
					this.mCanOpenHoleBackGround.SetNativeSize();
				}
				break;
			case InscriptionMosaicState.CanBeSet:
				if (tableItem != null)
				{
					if (tableItem.InscriptionHolePicture != string.Empty)
					{
						ETCImageLoader.LoadSprite(ref this.mHoleBackGround, tableItem.InscriptionHolePicture, true);
						this.mHoleBackGround.SetNativeSize();
					}
					if (this.mHoleName != null)
					{
						this.mHoleName.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionHoleName(this.mData.Type);
					}
				}
				break;
			case InscriptionMosaicState.HasBeenSet:
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mData.InscriptionId, 100, 0);
				if (itemData != null)
				{
					if (this.mHasBeenSetBackGround != null)
					{
						this.mHasBeenSetBackGround.color = itemData.GetQualityInfo().Col;
					}
					if (this.mHasBeenSetIncriptionIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.mHasBeenSetIncriptionIcon, itemData.Icon, true);
					}
					if (this.mIncriptionIconBtn != null)
					{
						this.mIncriptionIconBtn.onClick.RemoveAllListeners();
						this.mIncriptionIconBtn.onClick.AddListener(delegate()
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
						});
					}
				}
				if (this.mInscriptionArrt != null)
				{
					this.mInscriptionArrt.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(this.mData.InscriptionId, true);
				}
				break;
			}
			}
		}

		// Token: 0x0400B066 RID: 45158
		[SerializeField]
		private Image mHoleBackGround;

		// Token: 0x0400B067 RID: 45159
		[SerializeField]
		private Image mCanOpenHoleBackGround;

		// Token: 0x0400B068 RID: 45160
		[SerializeField]
		private Image mHasBeenSetBackGround;

		// Token: 0x0400B069 RID: 45161
		[SerializeField]
		private Image mHasBeenSetIncriptionIcon;

		// Token: 0x0400B06A RID: 45162
		[SerializeField]
		private Text mHoleName;

		// Token: 0x0400B06B RID: 45163
		[SerializeField]
		private Text mInscriptionArrt;

		// Token: 0x0400B06C RID: 45164
		[SerializeField]
		private StateController mStateCotrol;

		// Token: 0x0400B06D RID: 45165
		[SerializeField]
		private Button mIncriptionIconBtn;

		// Token: 0x0400B06E RID: 45166
		private InscriptionHoleData mData;

		// Token: 0x0400B06F RID: 45167
		private InscriptionMosaicState mState;
	}
}
