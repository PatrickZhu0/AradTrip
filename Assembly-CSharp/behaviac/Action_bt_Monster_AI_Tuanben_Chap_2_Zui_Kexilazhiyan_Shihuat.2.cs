using System;

namespace behaviac
{
	// Token: 0x020037DA RID: 14298
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_node3 : Action
	{
		// Token: 0x060157AF RID: 87983 RVA: 0x0067BBF3 File Offset: 0x00679FF3
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060157B0 RID: 87984 RVA: 0x0067BC2B File Offset: 0x0067A02B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F176 RID: 61814
		private BE_Target method_p0;

		// Token: 0x0400F177 RID: 61815
		private int method_p1;

		// Token: 0x0400F178 RID: 61816
		private int method_p2;

		// Token: 0x0400F179 RID: 61817
		private int method_p3;

		// Token: 0x0400F17A RID: 61818
		private int method_p4;
	}
}
