using System;

namespace behaviac
{
	// Token: 0x02003A3F RID: 14911
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node8 : Action
	{
		// Token: 0x06015C47 RID: 89159 RVA: 0x00693446 File Offset: 0x00691846
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570108;
			this.method_p2 = 12000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015C48 RID: 89160 RVA: 0x00693481 File Offset: 0x00691881
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F562 RID: 62818
		private BE_Target method_p0;

		// Token: 0x0400F563 RID: 62819
		private int method_p1;

		// Token: 0x0400F564 RID: 62820
		private int method_p2;

		// Token: 0x0400F565 RID: 62821
		private int method_p3;

		// Token: 0x0400F566 RID: 62822
		private int method_p4;
	}
}
