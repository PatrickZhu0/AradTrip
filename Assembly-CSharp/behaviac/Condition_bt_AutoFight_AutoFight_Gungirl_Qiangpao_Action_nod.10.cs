using System;

namespace behaviac
{
	// Token: 0x02002520 RID: 9504
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node42 : Condition
	{
		// Token: 0x06013389 RID: 78729 RVA: 0x005B60C6 File Offset: 0x005B44C6
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node42()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601338A RID: 78730 RVA: 0x005B60FC File Offset: 0x005B44FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDAB RID: 52651
		private int opl_p0;

		// Token: 0x0400CDAC RID: 52652
		private int opl_p1;

		// Token: 0x0400CDAD RID: 52653
		private int opl_p2;

		// Token: 0x0400CDAE RID: 52654
		private int opl_p3;
	}
}
