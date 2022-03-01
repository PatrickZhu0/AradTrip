using System;

namespace behaviac
{
	// Token: 0x020025A1 RID: 9633
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node15 : Condition
	{
		// Token: 0x06013489 RID: 78985 RVA: 0x005BC14A File Offset: 0x005BA54A
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node15()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601348A RID: 78986 RVA: 0x005BC180 File Offset: 0x005BA580
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEBD RID: 52925
		private int opl_p0;

		// Token: 0x0400CEBE RID: 52926
		private int opl_p1;

		// Token: 0x0400CEBF RID: 52927
		private int opl_p2;

		// Token: 0x0400CEC0 RID: 52928
		private int opl_p3;
	}
}
