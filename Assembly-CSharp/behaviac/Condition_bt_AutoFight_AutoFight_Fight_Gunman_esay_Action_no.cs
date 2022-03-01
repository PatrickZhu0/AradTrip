using System;

namespace behaviac
{
	// Token: 0x020020BA RID: 8378
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node2 : Condition
	{
		// Token: 0x06012B0A RID: 76554 RVA: 0x0057D102 File Offset: 0x0057B502
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node2()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012B0B RID: 76555 RVA: 0x0057D118 File Offset: 0x0057B518
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4FD RID: 50429
		private float opl_p0;
	}
}
