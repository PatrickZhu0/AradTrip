using System;

namespace behaviac
{
	// Token: 0x02002BFA RID: 11258
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node77 : Action
	{
		// Token: 0x060140F3 RID: 82163 RVA: 0x0060598E File Offset: 0x00603D8E
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node77()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060140F4 RID: 82164 RVA: 0x006059A4 File Offset: 0x00603DA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAD5 RID: 56021
		private int method_p0;
	}
}
