using System;

namespace behaviac
{
	// Token: 0x020020CA RID: 8394
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node22 : Condition
	{
		// Token: 0x06012B2A RID: 76586 RVA: 0x0057D982 File Offset: 0x0057BD82
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node22()
		{
			this.opl_p0 = 0.37f;
		}

		// Token: 0x06012B2B RID: 76587 RVA: 0x0057D998 File Offset: 0x0057BD98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C51D RID: 50461
		private float opl_p0;
	}
}
