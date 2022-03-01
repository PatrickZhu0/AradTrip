using System;

namespace behaviac
{
	// Token: 0x0200284F RID: 10319
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node86 : Condition
	{
		// Token: 0x060139DC RID: 80348 RVA: 0x005D9E56 File Offset: 0x005D8256
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node86()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060139DD RID: 80349 RVA: 0x005D9E8C File Offset: 0x005D828C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D434 RID: 54324
		private int opl_p0;

		// Token: 0x0400D435 RID: 54325
		private int opl_p1;

		// Token: 0x0400D436 RID: 54326
		private int opl_p2;

		// Token: 0x0400D437 RID: 54327
		private int opl_p3;
	}
}
