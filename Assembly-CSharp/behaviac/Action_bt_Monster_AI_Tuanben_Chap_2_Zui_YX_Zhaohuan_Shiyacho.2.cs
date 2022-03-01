using System;

namespace behaviac
{
	// Token: 0x020037F4 RID: 14324
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node3 : Action
	{
		// Token: 0x060157DD RID: 88029 RVA: 0x0067C8C9 File Offset: 0x0067ACC9
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521656;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060157DE RID: 88030 RVA: 0x0067C901 File Offset: 0x0067AD01
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1A6 RID: 61862
		private BE_Target method_p0;

		// Token: 0x0400F1A7 RID: 61863
		private int method_p1;

		// Token: 0x0400F1A8 RID: 61864
		private int method_p2;

		// Token: 0x0400F1A9 RID: 61865
		private int method_p3;

		// Token: 0x0400F1AA RID: 61866
		private int method_p4;
	}
}
