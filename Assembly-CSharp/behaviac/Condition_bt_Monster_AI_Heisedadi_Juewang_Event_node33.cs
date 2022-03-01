using System;

namespace behaviac
{
	// Token: 0x02003497 RID: 13463
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node33 : Condition
	{
		// Token: 0x06015177 RID: 86391 RVA: 0x0065A87F File Offset: 0x00658C7F
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node33()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 69;
		}

		// Token: 0x06015178 RID: 86392 RVA: 0x0065A8A0 File Offset: 0x00658CA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA72 RID: 60018
		private BE_Target opl_p0;

		// Token: 0x0400EA73 RID: 60019
		private BE_Equal opl_p1;

		// Token: 0x0400EA74 RID: 60020
		private int opl_p2;
	}
}
