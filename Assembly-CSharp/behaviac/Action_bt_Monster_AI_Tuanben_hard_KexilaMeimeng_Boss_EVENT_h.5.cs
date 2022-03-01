using System;

namespace behaviac
{
	// Token: 0x02003C5A RID: 15450
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node48 : Action
	{
		// Token: 0x0601605C RID: 90204 RVA: 0x006A7E86 File Offset: 0x006A6286
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601605D RID: 90205 RVA: 0x006A7EBD File Offset: 0x006A62BD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8D9 RID: 63705
		private BE_Target method_p0;

		// Token: 0x0400F8DA RID: 63706
		private int method_p1;

		// Token: 0x0400F8DB RID: 63707
		private int method_p2;

		// Token: 0x0400F8DC RID: 63708
		private int method_p3;

		// Token: 0x0400F8DD RID: 63709
		private int method_p4;
	}
}
