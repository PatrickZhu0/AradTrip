using System;

namespace behaviac
{
	// Token: 0x02002C28 RID: 11304
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node56 : Action
	{
		// Token: 0x0601414F RID: 82255 RVA: 0x0060664D File Offset: 0x00604A4D
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node56()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06014150 RID: 82256 RVA: 0x00606663 File Offset: 0x00604A63
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB1F RID: 56095
		private int method_p0;
	}
}
