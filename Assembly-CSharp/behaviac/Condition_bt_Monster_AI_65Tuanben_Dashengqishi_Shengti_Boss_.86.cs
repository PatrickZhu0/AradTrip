using System;

namespace behaviac
{
	// Token: 0x02002E64 RID: 11876
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node254 : Condition
	{
		// Token: 0x060145A5 RID: 83365 RVA: 0x0061BC26 File Offset: 0x0061A026
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node254()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 2229;
		}

		// Token: 0x060145A6 RID: 83366 RVA: 0x0061BC48 File Offset: 0x0061A048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasMechanism(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF2F RID: 57135
		private BE_Target opl_p0;

		// Token: 0x0400DF30 RID: 57136
		private BE_Equal opl_p1;

		// Token: 0x0400DF31 RID: 57137
		private int opl_p2;
	}
}
