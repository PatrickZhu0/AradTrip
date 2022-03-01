using System;

namespace behaviac
{
	// Token: 0x02002A56 RID: 10838
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node2 : Condition
	{
		// Token: 0x06013DD6 RID: 81366 RVA: 0x005F411A File Offset: 0x005F251A
		public Condition_bt_Guanka_apc_guijian_jue_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013DD7 RID: 81367 RVA: 0x005F4150 File Offset: 0x005F2550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D848 RID: 55368
		private int opl_p0;

		// Token: 0x0400D849 RID: 55369
		private int opl_p1;

		// Token: 0x0400D84A RID: 55370
		private int opl_p2;

		// Token: 0x0400D84B RID: 55371
		private int opl_p3;
	}
}
