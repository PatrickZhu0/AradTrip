using System;

namespace behaviac
{
	// Token: 0x02002A73 RID: 10867
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node17 : Condition
	{
		// Token: 0x06013E0D RID: 81421 RVA: 0x005F592B File Offset: 0x005F3D2B
		public Condition_bt_Guanka_apc_guijian_sha_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013E0E RID: 81422 RVA: 0x005F5960 File Offset: 0x005F3D60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D880 RID: 55424
		private int opl_p0;

		// Token: 0x0400D881 RID: 55425
		private int opl_p1;

		// Token: 0x0400D882 RID: 55426
		private int opl_p2;

		// Token: 0x0400D883 RID: 55427
		private int opl_p3;
	}
}
