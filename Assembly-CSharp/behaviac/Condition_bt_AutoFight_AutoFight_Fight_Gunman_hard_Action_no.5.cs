using System;

namespace behaviac
{
	// Token: 0x020020F2 RID: 8434
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node12 : Condition
	{
		// Token: 0x06012B78 RID: 76664 RVA: 0x0057FA6A File Offset: 0x0057DE6A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node12()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012B79 RID: 76665 RVA: 0x0057FA80 File Offset: 0x0057DE80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C56B RID: 50539
		private float opl_p0;
	}
}
