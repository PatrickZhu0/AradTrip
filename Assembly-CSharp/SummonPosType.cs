using System;
using System.ComponentModel;

// Token: 0x02004BD1 RID: 19409
public enum SummonPosType
{
	// Token: 0x04013ABB RID: 80571
	[Description("面前一个单位")]
	FACE,
	// Token: 0x04013ABC RID: 80572
	[Description("原地")]
	ORIGIN,
	// Token: 0x04013ABD RID: 80573
	[Description("面前一个单位不管阻挡")]
	FACE_FORCE,
	// Token: 0x04013ABE RID: 80574
	[Description("面前没有阻挡的位置")]
	FACE_BLACK
}
