using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001B3D RID: 6973
	internal class GuidanceEntrance : CachedNormalObject<EntranceData>
	{
		// Token: 0x060111C2 RID: 70082 RVA: 0x004E8A40 File Offset: 0x004E6E40
		public override void Initialize()
		{
			this.frameBinder = this.goLocal.GetComponentInParent<ClientFrameBinder>();
			this.comGuidanceItem = this.goLocal.GetComponent<ComGuidanceItem>();
			this.comGuidanceItem.button.onClick.RemoveListener(new UnityAction(this.OnClickItem));
			this.comGuidanceItem.button.onClick.AddListener(new UnityAction(this.OnClickItem));
		}

		// Token: 0x060111C3 RID: 70083 RVA: 0x004E8AB1 File Offset: 0x004E6EB1
		public override void UnInitialize()
		{
			if (this.comGuidanceItem.button != null)
			{
				this.comGuidanceItem.button.onClick.RemoveListener(new UnityAction(this.OnClickItem));
			}
		}

		// Token: 0x060111C4 RID: 70084 RVA: 0x004E8AEC File Offset: 0x004E6EEC
		private void OnClickItem()
		{
			if (base.Value != null && base.Value.entranceItem != null && !string.IsNullOrEmpty(base.Value.entranceItem.LinkInfo))
			{
				if (this.frameBinder != null)
				{
					this.frameBinder.CloseFrame(false);
				}
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(base.Value.entranceItem.LinkInfo, null, false);
			}
		}

		// Token: 0x060111C5 RID: 70085 RVA: 0x004E8B68 File Offset: 0x004E6F68
		public override void OnUpdate()
		{
			if (base.Value != null)
			{
				this.comGuidanceItem.Name.text = base.Value.entranceItem.Name;
				ETCImageLoader.LoadSprite(ref this.comGuidanceItem.Icon, base.Value.entranceItem.Icon, true);
			}
		}

		// Token: 0x0400B05E RID: 45150
		private ComGuidanceItem comGuidanceItem;

		// Token: 0x0400B05F RID: 45151
		private ClientFrameBinder frameBinder;
	}
}
