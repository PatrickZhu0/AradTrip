using System;

namespace behaviac
{
	// Token: 0x020024BE RID: 9406
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node42 : Condition
	{
		// Token: 0x060132C7 RID: 78535 RVA: 0x005B0D6B File Offset: 0x005AF16B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node42()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060132C8 RID: 78536 RVA: 0x005B0DA0 File Offset: 0x005AF1A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCE0 RID: 52448
		private int opl_p0;

		// Token: 0x0400CCE1 RID: 52449
		private int opl_p1;

		// Token: 0x0400CCE2 RID: 52450
		private int opl_p2;

		// Token: 0x0400CCE3 RID: 52451
		private int opl_p3;
	}
}
