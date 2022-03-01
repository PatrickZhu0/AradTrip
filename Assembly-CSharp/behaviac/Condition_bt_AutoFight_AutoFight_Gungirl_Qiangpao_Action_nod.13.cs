using System;

namespace behaviac
{
	// Token: 0x02002524 RID: 9508
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node55 : Condition
	{
		// Token: 0x06013391 RID: 78737 RVA: 0x005B627A File Offset: 0x005B467A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node55()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06013392 RID: 78738 RVA: 0x005B62B0 File Offset: 0x005B46B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDB3 RID: 52659
		private int opl_p0;

		// Token: 0x0400CDB4 RID: 52660
		private int opl_p1;

		// Token: 0x0400CDB5 RID: 52661
		private int opl_p2;

		// Token: 0x0400CDB6 RID: 52662
		private int opl_p3;
	}
}
