using System;

namespace behaviac
{
	// Token: 0x02002D0E RID: 11534
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node10 : Condition
	{
		// Token: 0x0601430A RID: 82698 RVA: 0x00610A8A File Offset: 0x0060EE8A
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 506409;
		}

		// Token: 0x0601430B RID: 82699 RVA: 0x00610AAC File Offset: 0x0060EEAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCB5 RID: 56501
		private BE_Target opl_p0;

		// Token: 0x0400DCB6 RID: 56502
		private BE_Equal opl_p1;

		// Token: 0x0400DCB7 RID: 56503
		private int opl_p2;
	}
}
