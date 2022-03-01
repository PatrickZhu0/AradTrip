using System;

namespace behaviac
{
	// Token: 0x02002E20 RID: 11808
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node137 : Condition
	{
		// Token: 0x0601451D RID: 83229 RVA: 0x0061A206 File Offset: 0x00618606
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node137()
		{
			this.opl_p0 = 1200;
			this.opl_p1 = 1200;
			this.opl_p2 = 1000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601451E RID: 83230 RVA: 0x0061A23C File Offset: 0x0061863C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEC4 RID: 57028
		private int opl_p0;

		// Token: 0x0400DEC5 RID: 57029
		private int opl_p1;

		// Token: 0x0400DEC6 RID: 57030
		private int opl_p2;

		// Token: 0x0400DEC7 RID: 57031
		private int opl_p3;
	}
}
