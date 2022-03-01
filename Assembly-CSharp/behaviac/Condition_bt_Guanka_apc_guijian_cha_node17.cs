using System;

namespace behaviac
{
	// Token: 0x02002A3F RID: 10815
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node17 : Condition
	{
		// Token: 0x06013DAA RID: 81322 RVA: 0x005F2AD3 File Offset: 0x005F0ED3
		public Condition_bt_Guanka_apc_guijian_cha_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013DAB RID: 81323 RVA: 0x005F2B08 File Offset: 0x005F0F08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D81B RID: 55323
		private int opl_p0;

		// Token: 0x0400D81C RID: 55324
		private int opl_p1;

		// Token: 0x0400D81D RID: 55325
		private int opl_p2;

		// Token: 0x0400D81E RID: 55326
		private int opl_p3;
	}
}
