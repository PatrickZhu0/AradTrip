using System;

namespace behaviac
{
	// Token: 0x02002E65 RID: 11877
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node255 : Condition
	{
		// Token: 0x060145A7 RID: 83367 RVA: 0x0061BC87 File Offset: 0x0061A087
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node255()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570290;
		}

		// Token: 0x060145A8 RID: 83368 RVA: 0x0061BCA8 File Offset: 0x0061A0A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF32 RID: 57138
		private BE_Target opl_p0;

		// Token: 0x0400DF33 RID: 57139
		private BE_Equal opl_p1;

		// Token: 0x0400DF34 RID: 57140
		private int opl_p2;
	}
}
