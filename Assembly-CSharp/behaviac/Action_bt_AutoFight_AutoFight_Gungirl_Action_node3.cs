using System;

namespace behaviac
{
	// Token: 0x020024A1 RID: 9377
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Action_node3 : Action
	{
		// Token: 0x0601328D RID: 78477 RVA: 0x005AFD47 File Offset: 0x005AE147
		public Action_bt_AutoFight_AutoFight_Gungirl_Action_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1500;
			this.method_p1 = 500;
			this.method_p2 = 1000;
			this.method_p3 = 1000;
		}

		// Token: 0x0601328E RID: 78478 RVA: 0x005AFD82 File Offset: 0x005AE182
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCA3 RID: 52387
		private int method_p0;

		// Token: 0x0400CCA4 RID: 52388
		private int method_p1;

		// Token: 0x0400CCA5 RID: 52389
		private int method_p2;

		// Token: 0x0400CCA6 RID: 52390
		private int method_p3;
	}
}
