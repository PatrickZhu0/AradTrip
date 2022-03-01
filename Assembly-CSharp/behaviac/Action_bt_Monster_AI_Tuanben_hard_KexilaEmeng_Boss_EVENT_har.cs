using System;

namespace behaviac
{
	// Token: 0x02003BC8 RID: 15304
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node34 : Action
	{
		// Token: 0x06015F3D RID: 89917 RVA: 0x006A26D7 File Offset: 0x006A0AD7
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570215;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015F3E RID: 89918 RVA: 0x006A270E File Offset: 0x006A0B0E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7C9 RID: 63433
		private BE_Target method_p0;

		// Token: 0x0400F7CA RID: 63434
		private int method_p1;

		// Token: 0x0400F7CB RID: 63435
		private int method_p2;

		// Token: 0x0400F7CC RID: 63436
		private int method_p3;

		// Token: 0x0400F7CD RID: 63437
		private int method_p4;
	}
}
