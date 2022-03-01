using System;

namespace behaviac
{
	// Token: 0x02002BE2 RID: 11234
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node28 : Action
	{
		// Token: 0x060140C3 RID: 82115 RVA: 0x0060530C File Offset: 0x0060370C
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060140C4 RID: 82116 RVA: 0x00605322 File Offset: 0x00603722
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAAB RID: 55979
		private int method_p0;
	}
}
