using System;

namespace behaviac
{
	// Token: 0x02002651 RID: 9809
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node52 : Action
	{
		// Token: 0x060135E7 RID: 79335 RVA: 0x005C3D4A File Offset: 0x005C214A
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node52()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4000;
			this.method_p1 = 500;
			this.method_p2 = 2500;
			this.method_p3 = 2500;
		}

		// Token: 0x060135E8 RID: 79336 RVA: 0x005C3D85 File Offset: 0x005C2185
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D036 RID: 53302
		private int method_p0;

		// Token: 0x0400D037 RID: 53303
		private int method_p1;

		// Token: 0x0400D038 RID: 53304
		private int method_p2;

		// Token: 0x0400D039 RID: 53305
		private int method_p3;
	}
}
