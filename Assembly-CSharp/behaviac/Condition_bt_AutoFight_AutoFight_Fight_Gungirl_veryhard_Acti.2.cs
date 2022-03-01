using System;

namespace behaviac
{
	// Token: 0x020020A3 RID: 8355
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node3 : Condition
	{
		// Token: 0x06012ADD RID: 76509 RVA: 0x0057BE8B File Offset: 0x0057A28B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012ADE RID: 76510 RVA: 0x0057BEC0 File Offset: 0x0057A2C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4CF RID: 50383
		private int opl_p0;

		// Token: 0x0400C4D0 RID: 50384
		private int opl_p1;

		// Token: 0x0400C4D1 RID: 50385
		private int opl_p2;

		// Token: 0x0400C4D2 RID: 50386
		private int opl_p3;
	}
}
