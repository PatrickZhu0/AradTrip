using System;

namespace behaviac
{
	// Token: 0x0200348B RID: 13451
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node19 : Condition
	{
		// Token: 0x0601515F RID: 86367 RVA: 0x0065A526 File Offset: 0x00658926
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node19()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x06015160 RID: 86368 RVA: 0x0065A548 File Offset: 0x00658948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA5D RID: 59997
		private BE_Target opl_p0;

		// Token: 0x0400EA5E RID: 59998
		private BE_Equal opl_p1;

		// Token: 0x0400EA5F RID: 59999
		private int opl_p2;
	}
}
