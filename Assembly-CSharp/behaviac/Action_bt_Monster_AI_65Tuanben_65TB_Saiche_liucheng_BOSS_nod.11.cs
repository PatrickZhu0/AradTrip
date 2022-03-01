using System;

namespace behaviac
{
	// Token: 0x02002BEC RID: 11244
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node111 : Action
	{
		// Token: 0x060140D7 RID: 82135 RVA: 0x00605557 File Offset: 0x00603957
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node111()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522200;
		}

		// Token: 0x060140D8 RID: 82136 RVA: 0x00605578 File Offset: 0x00603978
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAB7 RID: 55991
		private BE_Target method_p0;

		// Token: 0x0400DAB8 RID: 55992
		private int method_p1;
	}
}
