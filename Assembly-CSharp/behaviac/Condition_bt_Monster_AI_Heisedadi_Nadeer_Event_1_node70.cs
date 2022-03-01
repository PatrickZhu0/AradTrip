using System;

namespace behaviac
{
	// Token: 0x02003535 RID: 13621
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node70 : Condition
	{
		// Token: 0x060152AD RID: 86701 RVA: 0x0065FF18 File Offset: 0x0065E318
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node70()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521774;
		}

		// Token: 0x060152AE RID: 86702 RVA: 0x0065FF3C File Offset: 0x0065E33C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC44 RID: 60484
		private BE_Target opl_p0;

		// Token: 0x0400EC45 RID: 60485
		private BE_Equal opl_p1;

		// Token: 0x0400EC46 RID: 60486
		private int opl_p2;
	}
}
