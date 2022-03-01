using System;

namespace behaviac
{
	// Token: 0x02002C04 RID: 11268
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node102 : Action
	{
		// Token: 0x06014107 RID: 82183 RVA: 0x00605C83 File Offset: 0x00604083
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node102()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522221;
			this.method_p2 = 5000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06014108 RID: 82184 RVA: 0x00605CBD File Offset: 0x006040BD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAE5 RID: 56037
		private BE_Target method_p0;

		// Token: 0x0400DAE6 RID: 56038
		private int method_p1;

		// Token: 0x0400DAE7 RID: 56039
		private int method_p2;

		// Token: 0x0400DAE8 RID: 56040
		private int method_p3;

		// Token: 0x0400DAE9 RID: 56041
		private int method_p4;
	}
}
