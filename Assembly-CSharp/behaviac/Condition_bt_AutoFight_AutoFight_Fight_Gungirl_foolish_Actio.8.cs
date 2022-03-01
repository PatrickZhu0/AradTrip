using System;

namespace behaviac
{
	// Token: 0x02001F9C RID: 8092
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node18 : Condition
	{
		// Token: 0x060128D7 RID: 75991 RVA: 0x0056F2E7 File Offset: 0x0056D6E7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128D8 RID: 75992 RVA: 0x0056F31C File Offset: 0x0056D71C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2C8 RID: 49864
		private int opl_p0;

		// Token: 0x0400C2C9 RID: 49865
		private int opl_p1;

		// Token: 0x0400C2CA RID: 49866
		private int opl_p2;

		// Token: 0x0400C2CB RID: 49867
		private int opl_p3;
	}
}
