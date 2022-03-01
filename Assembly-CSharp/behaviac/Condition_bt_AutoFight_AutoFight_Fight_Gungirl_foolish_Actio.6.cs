using System;

namespace behaviac
{
	// Token: 0x02001F98 RID: 8088
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node13 : Condition
	{
		// Token: 0x060128CF RID: 75983 RVA: 0x0056F09B File Offset: 0x0056D49B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128D0 RID: 75984 RVA: 0x0056F0D0 File Offset: 0x0056D4D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2C0 RID: 49856
		private int opl_p0;

		// Token: 0x0400C2C1 RID: 49857
		private int opl_p1;

		// Token: 0x0400C2C2 RID: 49858
		private int opl_p2;

		// Token: 0x0400C2C3 RID: 49859
		private int opl_p3;
	}
}
