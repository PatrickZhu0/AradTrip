using System;

namespace behaviac
{
	// Token: 0x02002347 RID: 9031
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node30 : Condition
	{
		// Token: 0x06012FFC RID: 77820 RVA: 0x0059E762 File Offset: 0x0059CB62
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node30()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012FFD RID: 77821 RVA: 0x0059E794 File Offset: 0x0059CB94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA12 RID: 51730
		private int opl_p0;

		// Token: 0x0400CA13 RID: 51731
		private int opl_p1;

		// Token: 0x0400CA14 RID: 51732
		private int opl_p2;

		// Token: 0x0400CA15 RID: 51733
		private int opl_p3;
	}
}
