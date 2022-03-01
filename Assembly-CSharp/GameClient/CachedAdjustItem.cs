using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000019 RID: 25
	internal class CachedAdjustItem : CachedNormalObject<AdjustChangedAttr>
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00007B50 File Offset: 0x00005F50
		public override void Initialize()
		{
			this.attrName = Utility.FindComponent<Text>(this.goLocal, "Name", true);
			this.slider = Utility.FindComponent<Slider>(this.goLocal, "BaseAttrProgress/Front", true);
			this.progress = Utility.FindComponent<Text>(this.goLocal, "BaseAttrProgress/Progress", true);
			this.deltaValue = Utility.FindComponent<Text>(this.goLocal, "UpAttr", true);
			this.goArrowUp = Utility.FindChild(this.goLocal, "Arrows/Arrows_up");
			this.goArrowDown = Utility.FindChild(this.goLocal, "Arrows/Arrows_Down");
			this.extraAttr = Utility.FindComponent<Text>(this.goLocal, "ExtraAttrProgress/Progress", true);
			this.graExtra = Utility.FindComponent<UIGray>(this.goLocal, "ExtraAttrProgress", true);
			this.goExtraFront = Utility.FindChild(this.goLocal, "ExtraAttrProgress/Front");
			this.comEffect = this.goLocal.GetComponent<ComEffect>();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00007C3A File Offset: 0x0000603A
		public override void UnInitialize()
		{
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00007C3C File Offset: 0x0000603C
		private void _PlayEffect()
		{
			this.StopEffect();
			if (base.Value.bEffect)
			{
				if (base.Value.IsUp && base.Value.IsFull)
				{
					this.comEffect.Play("Perfect");
				}
				else
				{
					this.comEffect.Play("Normal");
				}
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00007CA4 File Offset: 0x000060A4
		public void StopEffect()
		{
			this.comEffect.Stop("Normal");
			this.comEffect.Stop("Perfect");
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00007CC6 File Offset: 0x000060C6
		public override void OnRecycle()
		{
			this.StopEffect();
			this.Disable();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00007CD4 File Offset: 0x000060D4
		public override void OnUpdate()
		{
			PropAttribute enumAttribute = Utility.GetEnumAttribute<EEquipProp, PropAttribute>(base.Value.eEEquipProp);
			if (enumAttribute != null)
			{
				this.attrName.text = enumAttribute.desc;
			}
			float fAmount = base.Value.fAmount;
			this.slider.value = fAmount;
			this.progress.text = base.Value.Process;
			if (!base.Value.IsChanged)
			{
				this.deltaValue.text = "0.0";
				this.deltaValue.enabled = false;
				this.deltaValue.color = Color.white;
				this.goArrowDown.CustomActive(false);
				this.goArrowUp.CustomActive(false);
			}
			else
			{
				this.deltaValue.text = string.Format("{0:F1}", base.Value.DeltaValue);
				this.deltaValue.enabled = true;
				if (base.Value.IsUp)
				{
					this.deltaValue.color = Color.green;
					this.goArrowDown.CustomActive(false);
					this.goArrowUp.CustomActive(true);
				}
				else
				{
					this.deltaValue.color = Color.red;
					this.goArrowDown.CustomActive(true);
					this.goArrowUp.CustomActive(false);
				}
			}
			this.extraAttr.text = base.Value.ExtraAttr;
			this.graExtra.enabled = false;
			this.goExtraFront.CustomActive(base.Value.IsFull);
			this._PlayEffect();
		}

		// Token: 0x04000061 RID: 97
		private Text attrName;

		// Token: 0x04000062 RID: 98
		private Slider slider;

		// Token: 0x04000063 RID: 99
		private Text progress;

		// Token: 0x04000064 RID: 100
		private Text deltaValue;

		// Token: 0x04000065 RID: 101
		private GameObject goArrowUp;

		// Token: 0x04000066 RID: 102
		private GameObject goArrowDown;

		// Token: 0x04000067 RID: 103
		private ComEffect comEffect;

		// Token: 0x04000068 RID: 104
		private Text extraAttr;

		// Token: 0x04000069 RID: 105
		private UIGray graExtra;

		// Token: 0x0400006A RID: 106
		private GameObject goExtraFront;
	}
}
