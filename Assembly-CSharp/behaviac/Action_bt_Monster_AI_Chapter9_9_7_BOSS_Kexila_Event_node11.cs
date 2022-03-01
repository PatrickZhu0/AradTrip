using System;

namespace behaviac
{
	// Token: 0x0200321F RID: 12831
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node11 : Action
	{
		// Token: 0x06014CC7 RID: 85191 RVA: 0x00644316 File Offset: 0x00642716
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570258;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014CC8 RID: 85192 RVA: 0x0064434D File Offset: 0x0064274D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E613 RID: 58899
		private BE_Target method_p0;

		// Token: 0x0400E614 RID: 58900
		private int method_p1;

		// Token: 0x0400E615 RID: 58901
		private int method_p2;

		// Token: 0x0400E616 RID: 58902
		private int method_p3;

		// Token: 0x0400E617 RID: 58903
		private int method_p4;
	}
}
