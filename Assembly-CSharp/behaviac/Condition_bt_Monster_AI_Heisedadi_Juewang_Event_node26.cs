using System;

namespace behaviac
{
	// Token: 0x02003491 RID: 13457
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node26 : Condition
	{
		// Token: 0x0601516B RID: 86379 RVA: 0x0065A6C6 File Offset: 0x00658AC6
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node26()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x0601516C RID: 86380 RVA: 0x0065A6E8 File Offset: 0x00658AE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA67 RID: 60007
		private BE_Target opl_p0;

		// Token: 0x0400EA68 RID: 60008
		private BE_Equal opl_p1;

		// Token: 0x0400EA69 RID: 60009
		private int opl_p2;
	}
}
