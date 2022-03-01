using System;

namespace behaviac
{
	// Token: 0x020031DF RID: 12767
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node8 : Action
	{
		// Token: 0x06014C4D RID: 85069 RVA: 0x00641B89 File Offset: 0x0063FF89
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06014C4E RID: 85070 RVA: 0x00641BC1 File Offset: 0x0063FFC1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5A8 RID: 58792
		private BE_Target method_p0;

		// Token: 0x0400E5A9 RID: 58793
		private int method_p1;

		// Token: 0x0400E5AA RID: 58794
		private int method_p2;

		// Token: 0x0400E5AB RID: 58795
		private int method_p3;

		// Token: 0x0400E5AC RID: 58796
		private int method_p4;
	}
}
