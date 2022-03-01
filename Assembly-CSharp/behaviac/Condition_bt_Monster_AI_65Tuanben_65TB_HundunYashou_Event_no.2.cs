using System;

namespace behaviac
{
	// Token: 0x02002B9B RID: 11163
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3 : Condition
	{
		// Token: 0x06014040 RID: 81984 RVA: 0x00602DCB File Offset: 0x006011CB
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 1;
		}

		// Token: 0x06014041 RID: 81985 RVA: 0x00602DE8 File Offset: 0x006011E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA34 RID: 55860
		private BE_Target opl_p0;

		// Token: 0x0400DA35 RID: 55861
		private BE_Equal opl_p1;

		// Token: 0x0400DA36 RID: 55862
		private int opl_p2;
	}
}
