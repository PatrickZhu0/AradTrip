using System;
using System.ComponentModel;
using UnityEngine;

// Token: 0x0200013D RID: 317
public class ComGraphicControl : MonoBehaviour
{
	// Token: 0x06000929 RID: 2345 RVA: 0x0002FE14 File Offset: 0x0002E214
	public string getViewString()
	{
		string text = "[LOD]";
		if (this.controlEnum == ComGraphicControl.GraphicControlEnum.High)
		{
			text += "|H";
		}
		else if (this.controlEnum == ComGraphicControl.GraphicControlEnum.Mid)
		{
			text += "|M";
		}
		else if (this.controlEnum == ComGraphicControl.GraphicControlEnum.Low)
		{
			text += "|L";
		}
		else if (this.controlEnum == ComGraphicControl.GraphicControlEnum.VeryLow)
		{
			text += "|V";
		}
		return text;
	}

	// Token: 0x040006FF RID: 1791
	public ComGraphicControl.GraphicControlEnum controlEnum = ComGraphicControl.GraphicControlEnum.Low;

	// Token: 0x0200013E RID: 318
	public enum GraphicControlEnum
	{
		// Token: 0x04000701 RID: 1793
		[Description("高配关闭")]
		High,
		// Token: 0x04000702 RID: 1794
		[Description("中配关闭")]
		Mid,
		// Token: 0x04000703 RID: 1795
		[Description("低配关闭")]
		Low,
		// Token: 0x04000704 RID: 1796
		[Description("超低配关闭")]
		VeryLow,
		// Token: 0x04000705 RID: 1797
		Defalut = 2
	}
}
