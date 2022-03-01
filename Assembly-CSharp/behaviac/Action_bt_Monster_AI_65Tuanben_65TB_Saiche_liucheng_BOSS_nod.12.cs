using System;

namespace behaviac
{
	// Token: 0x02002BED RID: 11245
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node92 : Action
	{
		// Token: 0x060140D9 RID: 82137 RVA: 0x00605592 File Offset: 0x00603992
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node92()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521383;
			this.method_p2 = 1000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060140DA RID: 82138 RVA: 0x006055CC File Offset: 0x006039CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAB9 RID: 55993
		private BE_Target method_p0;

		// Token: 0x0400DABA RID: 55994
		private int method_p1;

		// Token: 0x0400DABB RID: 55995
		private int method_p2;

		// Token: 0x0400DABC RID: 55996
		private int method_p3;

		// Token: 0x0400DABD RID: 55997
		private int method_p4;
	}
}
