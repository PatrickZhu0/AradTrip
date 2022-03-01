using System;

namespace behaviac
{
	// Token: 0x02003DB6 RID: 15798
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node14 : Action
	{
		// Token: 0x060162FC RID: 90876 RVA: 0x006B4FBE File Offset: 0x006B33BE
		public Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 523802;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060162FD RID: 90877 RVA: 0x006B4FF8 File Offset: 0x006B33F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB4A RID: 64330
		private BE_Target method_p0;

		// Token: 0x0400FB4B RID: 64331
		private int method_p1;

		// Token: 0x0400FB4C RID: 64332
		private int method_p2;

		// Token: 0x0400FB4D RID: 64333
		private int method_p3;

		// Token: 0x0400FB4E RID: 64334
		private int method_p4;
	}
}
