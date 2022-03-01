using System;

namespace behaviac
{
	// Token: 0x0200258E RID: 9614
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node51 : Condition
	{
		// Token: 0x06013464 RID: 78948 RVA: 0x005BAB1F File Offset: 0x005B8F1F
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node51()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013465 RID: 78949 RVA: 0x005BAB54 File Offset: 0x005B8F54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE8D RID: 52877
		private int opl_p0;

		// Token: 0x0400CE8E RID: 52878
		private int opl_p1;

		// Token: 0x0400CE8F RID: 52879
		private int opl_p2;

		// Token: 0x0400CE90 RID: 52880
		private int opl_p3;
	}
}
