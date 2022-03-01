using System;

namespace behaviac
{
	// Token: 0x0200283F RID: 10303
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node28 : Condition
	{
		// Token: 0x060139BC RID: 80316 RVA: 0x005D9786 File Offset: 0x005D7B86
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node28()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060139BD RID: 80317 RVA: 0x005D97BC File Offset: 0x005D7BBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D414 RID: 54292
		private int opl_p0;

		// Token: 0x0400D415 RID: 54293
		private int opl_p1;

		// Token: 0x0400D416 RID: 54294
		private int opl_p2;

		// Token: 0x0400D417 RID: 54295
		private int opl_p3;
	}
}
