using System;

namespace behaviac
{
	// Token: 0x02002E4D RID: 11853
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node30 : Condition
	{
		// Token: 0x06014577 RID: 83319 RVA: 0x0061B2E2 File Offset: 0x006196E2
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node30()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1510;
			this.opl_p3 = 3010;
		}

		// Token: 0x06014578 RID: 83320 RVA: 0x0061B318 File Offset: 0x00619718
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF07 RID: 57095
		private int opl_p0;

		// Token: 0x0400DF08 RID: 57096
		private int opl_p1;

		// Token: 0x0400DF09 RID: 57097
		private int opl_p2;

		// Token: 0x0400DF0A RID: 57098
		private int opl_p3;
	}
}
