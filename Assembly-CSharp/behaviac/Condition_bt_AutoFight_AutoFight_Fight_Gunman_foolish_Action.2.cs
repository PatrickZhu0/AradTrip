using System;

namespace behaviac
{
	// Token: 0x020020D3 RID: 8403
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node3 : Condition
	{
		// Token: 0x06012B3B RID: 76603 RVA: 0x0057E40B File Offset: 0x0057C80B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B3C RID: 76604 RVA: 0x0057E440 File Offset: 0x0057C840
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C52D RID: 50477
		private int opl_p0;

		// Token: 0x0400C52E RID: 50478
		private int opl_p1;

		// Token: 0x0400C52F RID: 50479
		private int opl_p2;

		// Token: 0x0400C530 RID: 50480
		private int opl_p3;
	}
}
