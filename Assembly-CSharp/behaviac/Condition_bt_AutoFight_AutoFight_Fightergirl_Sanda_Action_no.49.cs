using System;

namespace behaviac
{
	// Token: 0x02001F63 RID: 8035
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node76 : Condition
	{
		// Token: 0x06012869 RID: 75881 RVA: 0x0056BA67 File Offset: 0x00569E67
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node76()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601286A RID: 75882 RVA: 0x0056BA9C File Offset: 0x00569E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C263 RID: 49763
		private int opl_p0;

		// Token: 0x0400C264 RID: 49764
		private int opl_p1;

		// Token: 0x0400C265 RID: 49765
		private int opl_p2;

		// Token: 0x0400C266 RID: 49766
		private int opl_p3;
	}
}
