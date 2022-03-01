using System;

namespace behaviac
{
	// Token: 0x020040B0 RID: 16560
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node8 : Condition
	{
		// Token: 0x060168B9 RID: 92345 RVA: 0x006D3977 File Offset: 0x006D1D77
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node8()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1200;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060168BA RID: 92346 RVA: 0x006D39AC File Offset: 0x006D1DAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100FF RID: 65791
		private int opl_p0;

		// Token: 0x04010100 RID: 65792
		private int opl_p1;

		// Token: 0x04010101 RID: 65793
		private int opl_p2;

		// Token: 0x04010102 RID: 65794
		private int opl_p3;
	}
}
