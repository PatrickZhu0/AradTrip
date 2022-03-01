using System;

namespace behaviac
{
	// Token: 0x02002E76 RID: 11894
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node292 : Condition
	{
		// Token: 0x060145C9 RID: 83401 RVA: 0x0061C40E File Offset: 0x0061A80E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node292()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1510;
			this.opl_p3 = 3010;
		}

		// Token: 0x060145CA RID: 83402 RVA: 0x0061C444 File Offset: 0x0061A844
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF51 RID: 57169
		private int opl_p0;

		// Token: 0x0400DF52 RID: 57170
		private int opl_p1;

		// Token: 0x0400DF53 RID: 57171
		private int opl_p2;

		// Token: 0x0400DF54 RID: 57172
		private int opl_p3;
	}
}
