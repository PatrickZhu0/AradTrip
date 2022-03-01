using System;

namespace behaviac
{
	// Token: 0x02002C6C RID: 11372
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node10 : Condition
	{
		// Token: 0x060141D1 RID: 82385 RVA: 0x0060A66E File Offset: 0x00608A6E
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521982;
		}

		// Token: 0x060141D2 RID: 82386 RVA: 0x0060A690 File Offset: 0x00608A90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB92 RID: 56210
		private BE_Target opl_p0;

		// Token: 0x0400DB93 RID: 56211
		private BE_Equal opl_p1;

		// Token: 0x0400DB94 RID: 56212
		private int opl_p2;
	}
}
