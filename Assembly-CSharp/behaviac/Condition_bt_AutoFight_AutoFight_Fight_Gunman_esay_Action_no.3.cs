using System;

namespace behaviac
{
	// Token: 0x020020BE RID: 8382
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node7 : Condition
	{
		// Token: 0x06012B12 RID: 76562 RVA: 0x0057D34E File Offset: 0x0057B74E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node7()
		{
			this.opl_p0 = 0.32f;
		}

		// Token: 0x06012B13 RID: 76563 RVA: 0x0057D364 File Offset: 0x0057B764
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C505 RID: 50437
		private float opl_p0;
	}
}
