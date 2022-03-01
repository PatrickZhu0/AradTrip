using System;

namespace behaviac
{
	// Token: 0x02002540 RID: 9536
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node68 : Condition
	{
		// Token: 0x060133C9 RID: 78793 RVA: 0x005B6EC6 File Offset: 0x005B52C6
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node68()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060133CA RID: 78794 RVA: 0x005B6EFC File Offset: 0x005B52FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDEF RID: 52719
		private int opl_p0;

		// Token: 0x0400CDF0 RID: 52720
		private int opl_p1;

		// Token: 0x0400CDF1 RID: 52721
		private int opl_p2;

		// Token: 0x0400CDF2 RID: 52722
		private int opl_p3;
	}
}
