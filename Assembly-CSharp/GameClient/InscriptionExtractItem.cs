using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B46 RID: 6982
	public class InscriptionExtractItem : MonoBehaviour
	{
		// Token: 0x06011221 RID: 70177 RVA: 0x004EAE49 File Offset: 0x004E9249
		private void Awake()
		{
			if (this.mItemTog != null)
			{
				this.mItemTog.onValueChanged.RemoveAllListeners();
				this.mItemTog.onValueChanged.AddListener(new UnityAction<bool>(this.OnInscriptionItemClick));
			}
		}

		// Token: 0x06011222 RID: 70178 RVA: 0x004EAE88 File Offset: 0x004E9288
		private void OnDestroy()
		{
			this.mInscriptionExtractData = null;
			this.mOnClick = null;
		}

		// Token: 0x06011223 RID: 70179 RVA: 0x004EAE98 File Offset: 0x004E9298
		public void OnItemVisiable(InscriptionExtractItemData inscriptionExtractData, UnityAction<InscriptionExtractItemData> onClick, bool isSelected = false, bool togIsOpen = false)
		{
			this.mInscriptionExtractData = inscriptionExtractData;
			this.mOnClick = onClick;
			if (this.mInscriptionExtractData == null)
			{
				return;
			}
			if (this.mBackGround != null)
			{
				this.mBackGround.color = this.mInscriptionExtractData.inscriptionItem.GetQualityInfo().Col;
			}
			if (this.mIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mIcon, this.mInscriptionExtractData.inscriptionItem.Icon, true);
			}
			if (this.mName != null)
			{
				this.mName.text = this.mInscriptionExtractData.inscriptionItem.GetColorName(string.Empty, false);
			}
			if (!togIsOpen)
			{
				this.mItemTog.enabled = false;
			}
			if (isSelected && this.mItemTog != null)
			{
				this.mItemTog.isOn = true;
			}
		}

		// Token: 0x06011224 RID: 70180 RVA: 0x004EAF86 File Offset: 0x004E9386
		public void SetTogState()
		{
			if (this.mItemTog != null)
			{
				this.mItemTog.enabled = false;
			}
		}

		// Token: 0x06011225 RID: 70181 RVA: 0x004EAFA5 File Offset: 0x004E93A5
		private void OnInscriptionItemClick(bool value)
		{
			if (value && this.mOnClick != null)
			{
				this.mOnClick.Invoke(this.mInscriptionExtractData);
			}
		}

		// Token: 0x0400B0AB RID: 45227
		[SerializeField]
		private Image mBackGround;

		// Token: 0x0400B0AC RID: 45228
		[SerializeField]
		private Image mIcon;

		// Token: 0x0400B0AD RID: 45229
		[SerializeField]
		private Toggle mItemTog;

		// Token: 0x0400B0AE RID: 45230
		[SerializeField]
		private Text mName;

		// Token: 0x0400B0AF RID: 45231
		private InscriptionExtractItemData mInscriptionExtractData;

		// Token: 0x0400B0B0 RID: 45232
		private UnityAction<InscriptionExtractItemData> mOnClick;
	}
}
