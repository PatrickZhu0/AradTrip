using System;

namespace behaviac
{
	// Token: 0x02003953 RID: 14675
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node12 : Action
	{
		// Token: 0x06015A80 RID: 88704 RVA: 0x0068AA22 File Offset: 0x00688E22
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521647;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A81 RID: 88705 RVA: 0x0068AA59 File Offset: 0x00688E59
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F417 RID: 62487
		private BE_Target method_p0;

		// Token: 0x0400F418 RID: 62488
		private int method_p1;

		// Token: 0x0400F419 RID: 62489
		private int method_p2;

		// Token: 0x0400F41A RID: 62490
		private int method_p3;

		// Token: 0x0400F41B RID: 62491
		private int method_p4;
	}
}
