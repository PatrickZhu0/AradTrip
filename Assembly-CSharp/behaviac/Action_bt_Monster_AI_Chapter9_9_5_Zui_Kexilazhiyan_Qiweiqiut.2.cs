using System;

namespace behaviac
{
	// Token: 0x020031DC RID: 12764
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node3 : Action
	{
		// Token: 0x06014C47 RID: 85063 RVA: 0x00641A8C File Offset: 0x0063FE8C
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06014C48 RID: 85064 RVA: 0x00641AC4 File Offset: 0x0063FEC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E59E RID: 58782
		private BE_Target method_p0;

		// Token: 0x0400E59F RID: 58783
		private int method_p1;

		// Token: 0x0400E5A0 RID: 58784
		private int method_p2;

		// Token: 0x0400E5A1 RID: 58785
		private int method_p3;

		// Token: 0x0400E5A2 RID: 58786
		private int method_p4;
	}
}
