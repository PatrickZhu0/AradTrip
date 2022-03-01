using System;

namespace behaviac
{
	// Token: 0x02001F41 RID: 8001
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node68 : Condition
	{
		// Token: 0x06012825 RID: 75813 RVA: 0x0056AB9D File Offset: 0x00568F9D
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node68()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 100;
			this.opl_p2 = 100;
			this.opl_p3 = 100;
		}

		// Token: 0x06012826 RID: 75814 RVA: 0x0056ABC8 File Offset: 0x00568FC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C21D RID: 49693
		private int opl_p0;

		// Token: 0x0400C21E RID: 49694
		private int opl_p1;

		// Token: 0x0400C21F RID: 49695
		private int opl_p2;

		// Token: 0x0400C220 RID: 49696
		private int opl_p3;
	}
}
