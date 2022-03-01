using System;

namespace behaviac
{
	// Token: 0x02002E1D RID: 11805
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node133 : Condition
	{
		// Token: 0x06014517 RID: 83223 RVA: 0x0061A09A File Offset: 0x0061849A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node133()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014518 RID: 83224 RVA: 0x0061A0D0 File Offset: 0x006184D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEBD RID: 57021
		private int opl_p0;

		// Token: 0x0400DEBE RID: 57022
		private int opl_p1;

		// Token: 0x0400DEBF RID: 57023
		private int opl_p2;

		// Token: 0x0400DEC0 RID: 57024
		private int opl_p3;
	}
}
