using System;

namespace behaviac
{
	// Token: 0x020034F4 RID: 13556
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node22 : Condition
	{
		// Token: 0x0601522B RID: 86571 RVA: 0x0065E911 File Offset: 0x0065CD11
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node22()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521749;
		}

		// Token: 0x0601522C RID: 86572 RVA: 0x0065E934 File Offset: 0x0065CD34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB53 RID: 60243
		private BE_Target opl_p0;

		// Token: 0x0400EB54 RID: 60244
		private BE_Equal opl_p1;

		// Token: 0x0400EB55 RID: 60245
		private int opl_p2;
	}
}
