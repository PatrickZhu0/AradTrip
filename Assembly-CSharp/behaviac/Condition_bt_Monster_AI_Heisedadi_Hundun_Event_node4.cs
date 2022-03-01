using System;

namespace behaviac
{
	// Token: 0x0200344B RID: 13387
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node4 : Condition
	{
		// Token: 0x060150E2 RID: 86242 RVA: 0x006581E3 File Offset: 0x006565E3
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521729;
		}

		// Token: 0x060150E3 RID: 86243 RVA: 0x00658204 File Offset: 0x00656604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9BB RID: 59835
		private BE_Target opl_p0;

		// Token: 0x0400E9BC RID: 59836
		private BE_Equal opl_p1;

		// Token: 0x0400E9BD RID: 59837
		private int opl_p2;
	}
}
