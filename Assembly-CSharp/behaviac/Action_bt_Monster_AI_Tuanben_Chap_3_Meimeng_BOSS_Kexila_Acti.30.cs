using System;

namespace behaviac
{
	// Token: 0x02003931 RID: 14641
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node63 : Action
	{
		// Token: 0x06015A3D RID: 88637 RVA: 0x006885DB File Offset: 0x006869DB
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node63()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521648;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A3E RID: 88638 RVA: 0x00688612 File Offset: 0x00686A12
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3D0 RID: 62416
		private BE_Target method_p0;

		// Token: 0x0400F3D1 RID: 62417
		private int method_p1;

		// Token: 0x0400F3D2 RID: 62418
		private int method_p2;

		// Token: 0x0400F3D3 RID: 62419
		private int method_p3;

		// Token: 0x0400F3D4 RID: 62420
		private int method_p4;
	}
}
