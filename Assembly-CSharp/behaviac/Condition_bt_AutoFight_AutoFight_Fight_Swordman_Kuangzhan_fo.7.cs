using System;

namespace behaviac
{
	// Token: 0x0200233D RID: 9021
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node16 : Condition
	{
		// Token: 0x06012FEA RID: 77802 RVA: 0x0059E37E File Offset: 0x0059C77E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node16()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012FEB RID: 77803 RVA: 0x0059E3B4 File Offset: 0x0059C7B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA02 RID: 51714
		private int opl_p0;

		// Token: 0x0400CA03 RID: 51715
		private int opl_p1;

		// Token: 0x0400CA04 RID: 51716
		private int opl_p2;

		// Token: 0x0400CA05 RID: 51717
		private int opl_p3;
	}
}
