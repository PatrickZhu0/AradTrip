using System;

namespace behaviac
{
	// Token: 0x02001F6A RID: 8042
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node19 : Condition
	{
		// Token: 0x06012877 RID: 75895 RVA: 0x0056BD8F File Offset: 0x0056A18F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node19()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012878 RID: 75896 RVA: 0x0056BDC4 File Offset: 0x0056A1C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C272 RID: 49778
		private int opl_p0;

		// Token: 0x0400C273 RID: 49779
		private int opl_p1;

		// Token: 0x0400C274 RID: 49780
		private int opl_p2;

		// Token: 0x0400C275 RID: 49781
		private int opl_p3;
	}
}
