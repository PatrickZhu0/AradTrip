using System;

namespace behaviac
{
	// Token: 0x02003DA1 RID: 15777
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node12 : Action
	{
		// Token: 0x060162D4 RID: 90836 RVA: 0x006B44F5 File Offset: 0x006B28F5
		public Action_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Enemy;
			this.method_p1 = 570153;
			this.method_p2 = 6000000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060162D5 RID: 90837 RVA: 0x006B452F File Offset: 0x006B292F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB21 RID: 64289
		private BE_Target method_p0;

		// Token: 0x0400FB22 RID: 64290
		private int method_p1;

		// Token: 0x0400FB23 RID: 64291
		private int method_p2;

		// Token: 0x0400FB24 RID: 64292
		private int method_p3;

		// Token: 0x0400FB25 RID: 64293
		private int method_p4;
	}
}
