using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001161 RID: 4449
	internal class ChangeJobItem : CachedSelectedObject<JobTable, ChangeJobItem>
	{
		// Token: 0x0600A9E4 RID: 43492 RVA: 0x00242C60 File Offset: 0x00241060
		public override void Initialize()
		{
			this.jobName = Utility.FindComponent<Text>(this.goLocal, "Text", true);
			this.goCheckMark = Utility.FindChild(this.goLocal, "CheckMark");
			this.checkJobName = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
			this.imgBack = this.goLocal.GetComponent<Image>();
			if (base.Value.Open <= 0)
			{
				this.toggleGroup = this.toggle.group;
				this.toggle.group = null;
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(delegate(bool bValue)
				{
					if (bValue)
					{
						this.toggle.isOn = false;
						if (this.onSelected != null)
						{
							this.onSelected(this.data);
						}
						this.OnDisplayChanged(false);
					}
				});
			}
			else
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(delegate(bool bValue)
				{
					if (bValue && this.onSelected != null)
					{
						if (CachedSelectedObject<JobTable, ChangeJobItem>.Selected != this)
						{
							if (CachedSelectedObject<JobTable, ChangeJobItem>.Selected != null)
							{
								CachedSelectedObject<JobTable, ChangeJobItem>.Selected.OnDisplayChanged(false);
							}
							CachedSelectedObject<JobTable, ChangeJobItem>.Selected = this;
						}
						CachedSelectedObject<JobTable, ChangeJobItem>.Selected.OnDisplayChanged(true);
						this.onSelected(this.data);
					}
				});
			}
		}

		// Token: 0x0600A9E5 RID: 43493 RVA: 0x00242D4D File Offset: 0x0024114D
		public override void OnRecycle()
		{
			base.OnRecycle();
			if (this.toggleGroup != null)
			{
				this.toggle.group = this.toggleGroup;
				this.toggleGroup = null;
			}
		}

		// Token: 0x0600A9E6 RID: 43494 RVA: 0x00242D7E File Offset: 0x0024117E
		public override void UnInitialize()
		{
			this.checkJobName = null;
			this.goCheckMark = null;
			this.jobName = null;
		}

		// Token: 0x0600A9E7 RID: 43495 RVA: 0x00242D98 File Offset: 0x00241198
		public override void OnUpdate()
		{
			this.jobName.text = this.data.Name;
			this.checkJobName.text = this.data.Name;
			UIGray uigray = this.toggle.gameObject.GetComponent<UIGray>();
			if (uigray == null)
			{
				uigray = this.toggle.gameObject.AddComponent<UIGray>();
			}
			if (base.Value.Open > 0)
			{
				uigray.enabled = false;
			}
			else
			{
				uigray.enabled = true;
			}
		}

		// Token: 0x0600A9E8 RID: 43496 RVA: 0x00242E24 File Offset: 0x00241224
		public override void OnDisplayChanged(bool bShow)
		{
			this.goCheckMark.CustomActive(bShow);
			if (bShow)
			{
				this.goLocal.transform.localScale = ChangeJobItem.ms_scale_selected;
				this.jobName.transform.localScale = ChangeJobItem.ms_text_selected;
				this.checkJobName.transform.localScale = ChangeJobItem.ms_text_selected;
			}
			else
			{
				this.goLocal.transform.localScale = ChangeJobItem.ms_scale_normal;
				this.jobName.transform.localScale = ChangeJobItem.ms_scale_normal;
				this.checkJobName.transform.localScale = ChangeJobItem.ms_scale_normal;
			}
			this.jobName.enabled = !bShow;
		}

		// Token: 0x04005F33 RID: 24371
		private static Vector3 ms_scale_selected = new Vector3(1.02f, 1f, 1f);

		// Token: 0x04005F34 RID: 24372
		private static Vector3 ms_scale_normal = new Vector3(1f, 1f, 1f);

		// Token: 0x04005F35 RID: 24373
		private static Vector3 ms_text_selected = new Vector3(0.98f, 1f, 1f);

		// Token: 0x04005F36 RID: 24374
		private Text jobName;

		// Token: 0x04005F37 RID: 24375
		private GameObject goCheckMark;

		// Token: 0x04005F38 RID: 24376
		private Text checkJobName;

		// Token: 0x04005F39 RID: 24377
		private ToggleGroup toggleGroup;

		// Token: 0x04005F3A RID: 24378
		private Image imgBack;
	}
}
