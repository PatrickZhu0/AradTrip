using System;

namespace behaviac
{
	// Token: 0x02002342 RID: 9026
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node23 : Condition
	{
		// Token: 0x06012FF3 RID: 77811 RVA: 0x0059E542 File Offset: 0x0059C942
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012FF4 RID: 77812 RVA: 0x0059E578 File Offset: 0x0059C978
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA0A RID: 51722
		private int opl_p0;

		// Token: 0x0400CA0B RID: 51723
		private int opl_p1;

		// Token: 0x0400CA0C RID: 51724
		private int opl_p2;

		// Token: 0x0400CA0D RID: 51725
		private int opl_p3;
	}
}
