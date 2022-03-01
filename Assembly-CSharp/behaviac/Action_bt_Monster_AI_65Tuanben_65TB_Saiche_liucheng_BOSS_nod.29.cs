using System;

namespace behaviac
{
	// Token: 0x02002C10 RID: 11280
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node118 : Action
	{
		// Token: 0x0601411F RID: 82207 RVA: 0x00605F6E File Offset: 0x0060436E
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node118()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521383;
			this.method_p2 = 1000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06014120 RID: 82208 RVA: 0x00605FA8 File Offset: 0x006043A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAF8 RID: 56056
		private BE_Target method_p0;

		// Token: 0x0400DAF9 RID: 56057
		private int method_p1;

		// Token: 0x0400DAFA RID: 56058
		private int method_p2;

		// Token: 0x0400DAFB RID: 56059
		private int method_p3;

		// Token: 0x0400DAFC RID: 56060
		private int method_p4;
	}
}
