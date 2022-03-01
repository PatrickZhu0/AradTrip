using System;

namespace behaviac
{
	// Token: 0x02001FBC RID: 8124
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node28 : Condition
	{
		// Token: 0x06012916 RID: 76054 RVA: 0x0057098F File Offset: 0x0056ED8F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node28()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012917 RID: 76055 RVA: 0x005709C4 File Offset: 0x0056EDC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C307 RID: 49927
		private int opl_p0;

		// Token: 0x0400C308 RID: 49928
		private int opl_p1;

		// Token: 0x0400C309 RID: 49929
		private int opl_p2;

		// Token: 0x0400C30A RID: 49930
		private int opl_p3;
	}
}
