using System;

namespace behaviac
{
	// Token: 0x02002C0F RID: 11279
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node117 : Action
	{
		// Token: 0x0601411D RID: 82205 RVA: 0x00605F33 File Offset: 0x00604333
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node117()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522200;
		}

		// Token: 0x0601411E RID: 82206 RVA: 0x00605F54 File Offset: 0x00604354
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAF6 RID: 56054
		private BE_Target method_p0;

		// Token: 0x0400DAF7 RID: 56055
		private int method_p1;
	}
}
