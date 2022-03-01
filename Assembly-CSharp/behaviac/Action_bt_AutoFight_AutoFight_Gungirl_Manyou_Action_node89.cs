using System;

namespace behaviac
{
	// Token: 0x020024CC RID: 9420
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node89 : Action
	{
		// Token: 0x060132E2 RID: 78562 RVA: 0x005B20E2 File Offset: 0x005B04E2
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node89()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 10000;
			this.method_p1 = 10000;
			this.method_p2 = 10000;
			this.method_p3 = 10000;
		}

		// Token: 0x060132E3 RID: 78563 RVA: 0x005B211D File Offset: 0x005B051D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCFF RID: 52479
		private int method_p0;

		// Token: 0x0400CD00 RID: 52480
		private int method_p1;

		// Token: 0x0400CD01 RID: 52481
		private int method_p2;

		// Token: 0x0400CD02 RID: 52482
		private int method_p3;
	}
}
