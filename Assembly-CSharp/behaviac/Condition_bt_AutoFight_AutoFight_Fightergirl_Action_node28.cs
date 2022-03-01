using System;

namespace behaviac
{
	// Token: 0x02001EEF RID: 7919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node28 : Condition
	{
		// Token: 0x06012783 RID: 75651 RVA: 0x00566E0E File Offset: 0x0056520E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node28()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012784 RID: 75652 RVA: 0x00566E44 File Offset: 0x00565244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C178 RID: 49528
		private int opl_p0;

		// Token: 0x0400C179 RID: 49529
		private int opl_p1;

		// Token: 0x0400C17A RID: 49530
		private int opl_p2;

		// Token: 0x0400C17B RID: 49531
		private int opl_p3;
	}
}
