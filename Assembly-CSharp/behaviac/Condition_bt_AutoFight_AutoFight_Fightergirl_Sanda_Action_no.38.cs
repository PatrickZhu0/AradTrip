using System;

namespace behaviac
{
	// Token: 0x02001F55 RID: 8021
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node15 : Condition
	{
		// Token: 0x0601284D RID: 75853 RVA: 0x0056B487 File Offset: 0x00569887
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x0601284E RID: 75854 RVA: 0x0056B4BC File Offset: 0x005698BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C245 RID: 49733
		private int opl_p0;

		// Token: 0x0400C246 RID: 49734
		private int opl_p1;

		// Token: 0x0400C247 RID: 49735
		private int opl_p2;

		// Token: 0x0400C248 RID: 49736
		private int opl_p3;
	}
}
