using System;

namespace behaviac
{
	// Token: 0x02003449 RID: 13385
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node31 : Condition
	{
		// Token: 0x060150DE RID: 86238 RVA: 0x0065811C File Offset: 0x0065651C
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node31()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521855;
		}

		// Token: 0x060150DF RID: 86239 RVA: 0x00658140 File Offset: 0x00656540
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9B5 RID: 59829
		private BE_Target opl_p0;

		// Token: 0x0400E9B6 RID: 59830
		private BE_Equal opl_p1;

		// Token: 0x0400E9B7 RID: 59831
		private int opl_p2;
	}
}
