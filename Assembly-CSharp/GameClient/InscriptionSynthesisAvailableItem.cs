using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B60 RID: 7008
	public class InscriptionSynthesisAvailableItem : MonoBehaviour
	{
		// Token: 0x060112CD RID: 70349 RVA: 0x004EFB80 File Offset: 0x004EDF80
		private void OnDestroy()
		{
			this.mComItem = null;
		}

		// Token: 0x060112CE RID: 70350 RVA: 0x004EFB8C File Offset: 0x004EDF8C
		public void OnItemVisiable(CanBeObtainedInscriptionItemData data)
		{
			if (data == null)
			{
				return;
			}
			if (data.inscriptionItemData == null)
			{
				return;
			}
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			ItemData inscriptionItemData = data.inscriptionItemData;
			if (InscriptionSynthesisAvailableItem.<>f__mg$cache0 == null)
			{
				InscriptionSynthesisAvailableItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(inscriptionItemData, InscriptionSynthesisAvailableItem.<>f__mg$cache0);
			this.mInscriptionName.text = data.inscriptionItemData.GetColorName(string.Empty, false);
			this.mProbability.text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionExtractSuccessRateDesc(data.probability);
		}

		// Token: 0x0400B14F RID: 45391
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B150 RID: 45392
		[SerializeField]
		private Text mInscriptionName;

		// Token: 0x0400B151 RID: 45393
		[SerializeField]
		private Text mProbability;

		// Token: 0x0400B152 RID: 45394
		private ComItem mComItem;

		// Token: 0x0400B153 RID: 45395
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
