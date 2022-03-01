using System;

namespace behaviac
{
	// Token: 0x02002A3A RID: 10810
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node9 : Condition
	{
		// Token: 0x06013DA0 RID: 81312 RVA: 0x005F274E File Offset: 0x005F0B4E
		public Condition_bt_Guanka_apc_guijian_cha_node9()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013DA1 RID: 81313 RVA: 0x005F2784 File Offset: 0x005F0B84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D810 RID: 55312
		private int opl_p0;

		// Token: 0x0400D811 RID: 55313
		private int opl_p1;

		// Token: 0x0400D812 RID: 55314
		private int opl_p2;

		// Token: 0x0400D813 RID: 55315
		private int opl_p3;
	}
}
