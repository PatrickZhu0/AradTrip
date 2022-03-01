using System;

namespace behaviac
{
	// Token: 0x02003C5E RID: 15454
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node0 : Condition
	{
		// Token: 0x06016064 RID: 90212 RVA: 0x006A7FAB File Offset: 0x006A63AB
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node0()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570211;
		}

		// Token: 0x06016065 RID: 90213 RVA: 0x006A7FCC File Offset: 0x006A63CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8E5 RID: 63717
		private BE_Target opl_p0;

		// Token: 0x0400F8E6 RID: 63718
		private BE_Equal opl_p1;

		// Token: 0x0400F8E7 RID: 63719
		private int opl_p2;
	}
}
