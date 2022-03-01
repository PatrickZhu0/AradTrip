using System;

namespace behaviac
{
	// Token: 0x020025FC RID: 9724
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node12 : Condition
	{
		// Token: 0x0601353E RID: 79166 RVA: 0x005C02C0 File Offset: 0x005BE6C0
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node12()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
			this.opl_p4 = 6500;
			this.opl_p5 = 1000;
			this.opl_p6 = 1500;
			this.opl_p7 = 1500;
		}

		// Token: 0x0601353F RID: 79167 RVA: 0x005C032C File Offset: 0x005BE72C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF85 RID: 53125
		private int opl_p0;

		// Token: 0x0400CF86 RID: 53126
		private int opl_p1;

		// Token: 0x0400CF87 RID: 53127
		private int opl_p2;

		// Token: 0x0400CF88 RID: 53128
		private int opl_p3;

		// Token: 0x0400CF89 RID: 53129
		private int opl_p4;

		// Token: 0x0400CF8A RID: 53130
		private int opl_p5;

		// Token: 0x0400CF8B RID: 53131
		private int opl_p6;

		// Token: 0x0400CF8C RID: 53132
		private int opl_p7;
	}
}
