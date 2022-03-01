using System;

namespace behaviac
{
	// Token: 0x02002C0A RID: 11274
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node109 : Action
	{
		// Token: 0x06014113 RID: 82195 RVA: 0x00605E20 File Offset: 0x00604220
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node109()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x06014114 RID: 82196 RVA: 0x00605E36 File Offset: 0x00604236
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAF1 RID: 56049
		private int method_p0;
	}
}
