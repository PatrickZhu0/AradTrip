using System;

namespace behaviac
{
	// Token: 0x020020DB RID: 8411
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node13 : Condition
	{
		// Token: 0x06012B4B RID: 76619 RVA: 0x0057E7F3 File Offset: 0x0057CBF3
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B4C RID: 76620 RVA: 0x0057E828 File Offset: 0x0057CC28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C53D RID: 50493
		private int opl_p0;

		// Token: 0x0400C53E RID: 50494
		private int opl_p1;

		// Token: 0x0400C53F RID: 50495
		private int opl_p2;

		// Token: 0x0400C540 RID: 50496
		private int opl_p3;
	}
}
