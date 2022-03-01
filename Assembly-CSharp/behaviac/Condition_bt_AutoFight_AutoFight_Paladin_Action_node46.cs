using System;

namespace behaviac
{
	// Token: 0x0200278F RID: 10127
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node46 : Condition
	{
		// Token: 0x0601385E RID: 79966 RVA: 0x005D23AA File Offset: 0x005D07AA
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node46()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601385F RID: 79967 RVA: 0x005D23E0 File Offset: 0x005D07E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2BD RID: 53949
		private int opl_p0;

		// Token: 0x0400D2BE RID: 53950
		private int opl_p1;

		// Token: 0x0400D2BF RID: 53951
		private int opl_p2;

		// Token: 0x0400D2C0 RID: 53952
		private int opl_p3;
	}
}
