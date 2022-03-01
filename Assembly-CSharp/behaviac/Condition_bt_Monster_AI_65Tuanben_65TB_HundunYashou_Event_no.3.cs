using System;

namespace behaviac
{
	// Token: 0x02002B9C RID: 11164
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node4 : Condition
	{
		// Token: 0x06014042 RID: 81986 RVA: 0x00602E2A File Offset: 0x0060122A
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 96;
		}

		// Token: 0x06014043 RID: 81987 RVA: 0x00602E48 File Offset: 0x00601248
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA37 RID: 55863
		private BE_Target opl_p0;

		// Token: 0x0400DA38 RID: 55864
		private BE_Equal opl_p1;

		// Token: 0x0400DA39 RID: 55865
		private int opl_p2;
	}
}
