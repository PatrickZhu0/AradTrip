using System;

namespace behaviac
{
	// Token: 0x02002B99 RID: 11161
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node6 : Condition
	{
		// Token: 0x0601403C RID: 81980 RVA: 0x00602D34 File Offset: 0x00601134
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 1;
		}

		// Token: 0x0601403D RID: 81981 RVA: 0x00602D54 File Offset: 0x00601154
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA2F RID: 55855
		private BE_Target opl_p0;

		// Token: 0x0400DA30 RID: 55856
		private BE_Equal opl_p1;

		// Token: 0x0400DA31 RID: 55857
		private int opl_p2;
	}
}
