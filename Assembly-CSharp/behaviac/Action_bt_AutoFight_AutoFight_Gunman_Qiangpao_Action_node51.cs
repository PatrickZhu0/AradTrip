using System;

namespace behaviac
{
	// Token: 0x02002648 RID: 9800
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node51 : Action
	{
		// Token: 0x060135D5 RID: 79317 RVA: 0x005C39AA File Offset: 0x005C1DAA
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node51()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4000;
			this.method_p1 = 4000;
			this.method_p2 = 4000;
			this.method_p3 = 4000;
		}

		// Token: 0x060135D6 RID: 79318 RVA: 0x005C39E5 File Offset: 0x005C1DE5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D024 RID: 53284
		private int method_p0;

		// Token: 0x0400D025 RID: 53285
		private int method_p1;

		// Token: 0x0400D026 RID: 53286
		private int method_p2;

		// Token: 0x0400D027 RID: 53287
		private int method_p3;
	}
}
