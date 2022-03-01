using System;

namespace behaviac
{
	// Token: 0x02003707 RID: 14087
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node22 : Action
	{
		// Token: 0x0601561D RID: 87581 RVA: 0x006733CB File Offset: 0x006717CB
		public Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 540103;
			this.method_p2 = 60000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601561E RID: 87582 RVA: 0x00673405 File Offset: 0x00671805
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFE4 RID: 61412
		private BE_Target method_p0;

		// Token: 0x0400EFE5 RID: 61413
		private int method_p1;

		// Token: 0x0400EFE6 RID: 61414
		private int method_p2;

		// Token: 0x0400EFE7 RID: 61415
		private int method_p3;

		// Token: 0x0400EFE8 RID: 61416
		private int method_p4;
	}
}
