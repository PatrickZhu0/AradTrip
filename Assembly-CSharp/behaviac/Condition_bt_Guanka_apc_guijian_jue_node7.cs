using System;

namespace behaviac
{
	// Token: 0x02002A59 RID: 10841
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node7 : Condition
	{
		// Token: 0x06013DDC RID: 81372 RVA: 0x005F423B File Offset: 0x005F263B
		public Condition_bt_Guanka_apc_guijian_jue_node7()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013DDD RID: 81373 RVA: 0x005F4250 File Offset: 0x005F2650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D850 RID: 55376
		private int opl_p0;
	}
}
