using System;

namespace behaviac
{
	// Token: 0x02001DAB RID: 7595
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node2 : Condition
	{
		// Token: 0x0601250F RID: 75023 RVA: 0x00558D68 File Offset: 0x00557168
		public Condition_bt_APC_APC_Kuangzhan_Action_node2()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012510 RID: 75024 RVA: 0x00558D9C File Offset: 0x0055719C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEFD RID: 48893
		private int opl_p0;

		// Token: 0x0400BEFE RID: 48894
		private int opl_p1;

		// Token: 0x0400BEFF RID: 48895
		private int opl_p2;

		// Token: 0x0400BF00 RID: 48896
		private int opl_p3;
	}
}
