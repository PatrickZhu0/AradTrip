using System;

namespace behaviac
{
	// Token: 0x02002AB9 RID: 10937
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node17 : Condition
	{
		// Token: 0x06013E90 RID: 81552 RVA: 0x005F8FC6 File Offset: 0x005F73C6
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013E91 RID: 81553 RVA: 0x005F8FFC File Offset: 0x005F73FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D903 RID: 55555
		private int opl_p0;

		// Token: 0x0400D904 RID: 55556
		private int opl_p1;

		// Token: 0x0400D905 RID: 55557
		private int opl_p2;

		// Token: 0x0400D906 RID: 55558
		private int opl_p3;
	}
}
