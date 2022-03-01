using System;

namespace behaviac
{
	// Token: 0x02002BE7 RID: 11239
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node13 : Action
	{
		// Token: 0x060140CD RID: 82125 RVA: 0x00605444 File Offset: 0x00603844
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060140CE RID: 82126 RVA: 0x0060545A File Offset: 0x0060385A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAB2 RID: 55986
		private int method_p0;
	}
}
