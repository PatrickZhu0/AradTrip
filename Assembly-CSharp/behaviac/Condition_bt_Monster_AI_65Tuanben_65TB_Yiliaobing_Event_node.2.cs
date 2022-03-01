using System;

namespace behaviac
{
	// Token: 0x02002D20 RID: 11552
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node10 : Condition
	{
		// Token: 0x0601432B RID: 82731 RVA: 0x006115FE File Offset: 0x0060F9FE
		public Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521982;
		}

		// Token: 0x0601432C RID: 82732 RVA: 0x00611620 File Offset: 0x0060FA20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCE2 RID: 56546
		private BE_Target opl_p0;

		// Token: 0x0400DCE3 RID: 56547
		private BE_Equal opl_p1;

		// Token: 0x0400DCE4 RID: 56548
		private int opl_p2;
	}
}
