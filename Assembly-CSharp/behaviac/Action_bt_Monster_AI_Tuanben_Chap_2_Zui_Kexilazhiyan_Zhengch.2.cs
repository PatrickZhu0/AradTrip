using System;

namespace behaviac
{
	// Token: 0x020037E2 RID: 14306
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node3 : Action
	{
		// Token: 0x060157BD RID: 87997 RVA: 0x0067C05B File Offset: 0x0067A45B
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060157BE RID: 87998 RVA: 0x0067C093 File Offset: 0x0067A493
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F188 RID: 61832
		private BE_Target method_p0;

		// Token: 0x0400F189 RID: 61833
		private int method_p1;

		// Token: 0x0400F18A RID: 61834
		private int method_p2;

		// Token: 0x0400F18B RID: 61835
		private int method_p3;

		// Token: 0x0400F18C RID: 61836
		private int method_p4;
	}
}
