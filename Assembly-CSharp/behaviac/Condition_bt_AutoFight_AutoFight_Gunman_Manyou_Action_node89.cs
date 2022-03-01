using System;

namespace behaviac
{
	// Token: 0x02002622 RID: 9762
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node89 : Condition
	{
		// Token: 0x0601358A RID: 79242 RVA: 0x005C1404 File Offset: 0x005BF804
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node89()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
			this.opl_p4 = 8000;
			this.opl_p5 = 1000;
			this.opl_p6 = 1500;
			this.opl_p7 = 1500;
		}

		// Token: 0x0601358B RID: 79243 RVA: 0x005C1470 File Offset: 0x005BF870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFD3 RID: 53203
		private int opl_p0;

		// Token: 0x0400CFD4 RID: 53204
		private int opl_p1;

		// Token: 0x0400CFD5 RID: 53205
		private int opl_p2;

		// Token: 0x0400CFD6 RID: 53206
		private int opl_p3;

		// Token: 0x0400CFD7 RID: 53207
		private int opl_p4;

		// Token: 0x0400CFD8 RID: 53208
		private int opl_p5;

		// Token: 0x0400CFD9 RID: 53209
		private int opl_p6;

		// Token: 0x0400CFDA RID: 53210
		private int opl_p7;
	}
}
