using System;

namespace behaviac
{
	// Token: 0x020024C8 RID: 9416
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node85 : Action
	{
		// Token: 0x060132DA RID: 78554 RVA: 0x005B1F46 File Offset: 0x005B0346
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node85()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 10000;
			this.method_p1 = 10000;
			this.method_p2 = 10000;
			this.method_p3 = 10000;
		}

		// Token: 0x060132DB RID: 78555 RVA: 0x005B1F81 File Offset: 0x005B0381
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCF7 RID: 52471
		private int method_p0;

		// Token: 0x0400CCF8 RID: 52472
		private int method_p1;

		// Token: 0x0400CCF9 RID: 52473
		private int method_p2;

		// Token: 0x0400CCFA RID: 52474
		private int method_p3;
	}
}
