using System;

namespace behaviac
{
	// Token: 0x02003706 RID: 14086
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node21 : Action
	{
		// Token: 0x0601561B RID: 87579 RVA: 0x00673369 File Offset: 0x00671769
		public Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2;
			this.method_p2 = 60000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601561C RID: 87580 RVA: 0x0067339F File Offset: 0x0067179F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFDF RID: 61407
		private BE_Target method_p0;

		// Token: 0x0400EFE0 RID: 61408
		private int method_p1;

		// Token: 0x0400EFE1 RID: 61409
		private int method_p2;

		// Token: 0x0400EFE2 RID: 61410
		private int method_p3;

		// Token: 0x0400EFE3 RID: 61411
		private int method_p4;
	}
}
