using System;

namespace behaviac
{
	// Token: 0x02003C8B RID: 15499
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node21 : Condition
	{
		// Token: 0x060160BD RID: 90301 RVA: 0x006A96BA File Offset: 0x006A7ABA
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node21()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570034;
		}

		// Token: 0x060160BE RID: 90302 RVA: 0x006A96DC File Offset: 0x006A7ADC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F954 RID: 63828
		private BE_Target opl_p0;

		// Token: 0x0400F955 RID: 63829
		private BE_Equal opl_p1;

		// Token: 0x0400F956 RID: 63830
		private int opl_p2;
	}
}
