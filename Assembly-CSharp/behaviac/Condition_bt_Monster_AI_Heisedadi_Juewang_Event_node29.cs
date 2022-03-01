using System;

namespace behaviac
{
	// Token: 0x02003494 RID: 13460
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node29 : Condition
	{
		// Token: 0x06015171 RID: 86385 RVA: 0x0065A796 File Offset: 0x00658B96
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node29()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x06015172 RID: 86386 RVA: 0x0065A7B8 File Offset: 0x00658BB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA6C RID: 60012
		private BE_Target opl_p0;

		// Token: 0x0400EA6D RID: 60013
		private BE_Equal opl_p1;

		// Token: 0x0400EA6E RID: 60014
		private int opl_p2;
	}
}
