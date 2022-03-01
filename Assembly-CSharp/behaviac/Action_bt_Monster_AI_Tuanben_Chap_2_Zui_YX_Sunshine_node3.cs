using System;

namespace behaviac
{
	// Token: 0x020037EA RID: 14314
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Sunshine_node3 : Action
	{
		// Token: 0x060157CB RID: 88011 RVA: 0x0067C472 File Offset: 0x0067A872
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Sunshine_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060157CC RID: 88012 RVA: 0x0067C4AA File Offset: 0x0067A8AA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F198 RID: 61848
		private BE_Target method_p0;

		// Token: 0x0400F199 RID: 61849
		private int method_p1;

		// Token: 0x0400F19A RID: 61850
		private int method_p2;

		// Token: 0x0400F19B RID: 61851
		private int method_p3;

		// Token: 0x0400F19C RID: 61852
		private int method_p4;
	}
}
