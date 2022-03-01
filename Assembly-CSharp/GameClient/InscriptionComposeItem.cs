using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B41 RID: 6977
	public class InscriptionComposeItem : MonoBehaviour
	{
		// Token: 0x060111F6 RID: 70134 RVA: 0x004E9FF6 File Offset: 0x004E83F6
		private void Awake()
		{
			if (this.close != null)
			{
				this.close.onClick.RemoveAllListeners();
				this.close.onClick.AddListener(new UnityAction(this.OnCloseClick));
			}
		}

		// Token: 0x060111F7 RID: 70135 RVA: 0x004EA035 File Offset: 0x004E8435
		private void OnDestroy()
		{
			this.itemData = null;
		}

		// Token: 0x060111F8 RID: 70136 RVA: 0x004EA03E File Offset: 0x004E843E
		private void SetBackGround()
		{
			if (this.backGround != null)
			{
				this.backGround.color = this.itemData.GetQualityInfo().Col;
			}
		}

		// Token: 0x060111F9 RID: 70137 RVA: 0x004EA06C File Offset: 0x004E846C
		private void SetIcon()
		{
			if (this.icon != null)
			{
				ETCImageLoader.LoadSprite(ref this.icon, this.itemData.Icon, true);
				this.icon.CustomActive(true);
			}
		}

		// Token: 0x060111FA RID: 70138 RVA: 0x004EA0A3 File Offset: 0x004E84A3
		private void SetCloseBtnState(bool isFlag)
		{
			this.close.CustomActive(isFlag);
		}

		// Token: 0x060111FB RID: 70139 RVA: 0x004EA0B1 File Offset: 0x004E84B1
		private void SetIconState(bool isFlag)
		{
			this.icon.CustomActive(isFlag);
		}

		// Token: 0x060111FC RID: 70140 RVA: 0x004EA0BF File Offset: 0x004E84BF
		private void SetLockedRootState(bool isFlag)
		{
			this.lockedRoot.CustomActive(isFlag);
		}

		// Token: 0x060111FD RID: 70141 RVA: 0x004EA0CD File Offset: 0x004E84CD
		private void SetBackGroudState(bool isFlag)
		{
			this.backGround.CustomActive(isFlag);
		}

		// Token: 0x060111FE RID: 70142 RVA: 0x004EA0DC File Offset: 0x004E84DC
		public void SetUp(ItemData itemData)
		{
			this.itemData = itemData;
			if (this.itemData != null)
			{
				this.SetBackGround();
				this.SetIcon();
				this.SetBackGroudState(true);
				this.SetCloseBtnState(true);
			}
			else
			{
				this.SetBackGroudState(false);
				this.SetIconState(false);
				this.SetCloseBtnState(false);
			}
			this.SetLockedRootState(false);
		}

		// Token: 0x060111FF RID: 70143 RVA: 0x004EA136 File Offset: 0x004E8536
		public void SetupSlot()
		{
			this.SetBackGroudState(false);
			this.SetLockedRootState(true);
			this.SetCloseBtnState(false);
		}

		// Token: 0x06011200 RID: 70144 RVA: 0x004EA14D File Offset: 0x004E854D
		private void OnCloseClick()
		{
			this.SetCloseBtnState(false);
			if (this.itemData != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnCloseSynthesisIncriptionChanged, this.itemData.TableID, null, null, null);
			}
		}

		// Token: 0x0400B083 RID: 45187
		[SerializeField]
		private Image backGround;

		// Token: 0x0400B084 RID: 45188
		[SerializeField]
		private Image icon;

		// Token: 0x0400B085 RID: 45189
		[SerializeField]
		private GameObject lockedRoot;

		// Token: 0x0400B086 RID: 45190
		[SerializeField]
		private Button close;

		// Token: 0x0400B087 RID: 45191
		private ItemData itemData;
	}
}
