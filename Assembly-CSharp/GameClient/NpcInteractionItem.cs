using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200460F RID: 17935
	internal class NpcInteractionItem : CachedObject
	{
		// Token: 0x06019367 RID: 103271 RVA: 0x007F9F2C File Offset: 0x007F832C
		public override void OnCreate(object[] param)
		{
			this.goParent = (param[0] as GameObject);
			this.goPrefab = (param[1] as GameObject);
			this.data = (param[2] as NpcInteractionData);
			this.frame = (param[3] as ClientFrame);
			if (this.goLocal == null)
			{
				this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
				Utility.AttachTo(this.goLocal, this.goParent, false);
				this.image = this.goLocal.GetComponent<Image>();
				this.btnClick = this.goLocal.GetComponent<Button>();
				this.btnClick.onClick.RemoveAllListeners();
				this.btnClick.onClick.AddListener(delegate()
				{
					if (this.data.onClickFunction != null)
					{
						this.data.onClickFunction();
						if (this.frame != null)
						{
							this.frame.Close(true);
						}
					}
				});
			}
			this.Enable();
			this.SetAsLastSibling();
			this.OnUpdate();
		}

		// Token: 0x06019368 RID: 103272 RVA: 0x007FA008 File Offset: 0x007F8408
		public override void OnDestroy()
		{
			this.goLocal = null;
			this.data = null;
			this.goPrefab = null;
			this.goParent = null;
			this.image = null;
			if (this.btnClick != null)
			{
				this.btnClick.onClick.RemoveAllListeners();
				this.btnClick = null;
			}
			this.frame = null;
		}

		// Token: 0x06019369 RID: 103273 RVA: 0x007FA067 File Offset: 0x007F8467
		public override void Enable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(true);
			}
		}

		// Token: 0x0601936A RID: 103274 RVA: 0x007FA086 File Offset: 0x007F8486
		public override void Disable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(false);
			}
		}

		// Token: 0x0601936B RID: 103275 RVA: 0x007FA0A5 File Offset: 0x007F84A5
		public override void SetAsLastSibling()
		{
			if (this.goLocal != null)
			{
				this.goLocal.transform.SetAsLastSibling();
			}
		}

		// Token: 0x0601936C RID: 103276 RVA: 0x007FA0C8 File Offset: 0x007F84C8
		public override void OnRefresh(object[] param)
		{
			if (param != null && param.Length > 0)
			{
				this.data = (param[0] as NpcInteractionData);
			}
			this.OnUpdate();
		}

		// Token: 0x0601936D RID: 103277 RVA: 0x007FA0ED File Offset: 0x007F84ED
		public override void OnRecycle()
		{
			this.Disable();
		}

		// Token: 0x0601936E RID: 103278 RVA: 0x007FA0F5 File Offset: 0x007F84F5
		public override void OnDecycle(object[] param)
		{
			this.OnCreate(param);
		}

		// Token: 0x0601936F RID: 103279 RVA: 0x007FA0FE File Offset: 0x007F84FE
		private void OnUpdate()
		{
			ETCImageLoader.LoadSprite(ref this.image, this.data.icon, true);
		}

		// Token: 0x0401210E RID: 73998
		protected GameObject goLocal;

		// Token: 0x0401210F RID: 73999
		public GameObject goPrefab;

		// Token: 0x04012110 RID: 74000
		public GameObject goParent;

		// Token: 0x04012111 RID: 74001
		public NpcInteractionData data;

		// Token: 0x04012112 RID: 74002
		public ClientFrame frame;

		// Token: 0x04012113 RID: 74003
		private Image image;

		// Token: 0x04012114 RID: 74004
		private Button btnClick;
	}
}
