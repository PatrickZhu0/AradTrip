using System;

namespace behaviac
{
	// Token: 0x020037BE RID: 14270
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3 : Action
	{
		// Token: 0x0601577D RID: 87933 RVA: 0x0067ACAE File Offset: 0x006790AE
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 3500;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601577E RID: 87934 RVA: 0x0067ACE6 File Offset: 0x006790E6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F12D RID: 61741
		private BE_Target method_p0;

		// Token: 0x0400F12E RID: 61742
		private int method_p1;

		// Token: 0x0400F12F RID: 61743
		private int method_p2;

		// Token: 0x0400F130 RID: 61744
		private int method_p3;

		// Token: 0x0400F131 RID: 61745
		private int method_p4;
	}
}
