using System;

namespace behaviac
{
	// Token: 0x02002E3B RID: 11835
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node142 : Condition
	{
		// Token: 0x06014553 RID: 83283 RVA: 0x0061AB25 File Offset: 0x00618F25
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node142()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570290;
		}

		// Token: 0x06014554 RID: 83284 RVA: 0x0061AB48 File Offset: 0x00618F48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEE8 RID: 57064
		private BE_Target opl_p0;

		// Token: 0x0400DEE9 RID: 57065
		private BE_Equal opl_p1;

		// Token: 0x0400DEEA RID: 57066
		private int opl_p2;
	}
}
