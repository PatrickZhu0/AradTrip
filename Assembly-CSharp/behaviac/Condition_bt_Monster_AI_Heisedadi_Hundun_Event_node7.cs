using System;

namespace behaviac
{
	// Token: 0x02003453 RID: 13395
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node7 : Condition
	{
		// Token: 0x060150F2 RID: 86258 RVA: 0x006584BB File Offset: 0x006568BB
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node7()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521729;
		}

		// Token: 0x060150F3 RID: 86259 RVA: 0x006584DC File Offset: 0x006568DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9D7 RID: 59863
		private BE_Target opl_p0;

		// Token: 0x0400E9D8 RID: 59864
		private BE_Equal opl_p1;

		// Token: 0x0400E9D9 RID: 59865
		private int opl_p2;
	}
}
