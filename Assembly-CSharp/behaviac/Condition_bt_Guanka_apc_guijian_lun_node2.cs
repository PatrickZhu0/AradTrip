using System;

namespace behaviac
{
	// Token: 0x02002A64 RID: 10852
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_lun_node2 : Condition
	{
		// Token: 0x06013DF1 RID: 81393 RVA: 0x005F4CDC File Offset: 0x005F30DC
		public Condition_bt_Guanka_apc_guijian_lun_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013DF2 RID: 81394 RVA: 0x005F4D10 File Offset: 0x005F3110
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D863 RID: 55395
		private int opl_p0;

		// Token: 0x0400D864 RID: 55396
		private int opl_p1;

		// Token: 0x0400D865 RID: 55397
		private int opl_p2;

		// Token: 0x0400D866 RID: 55398
		private int opl_p3;
	}
}
