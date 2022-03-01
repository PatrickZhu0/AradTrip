using System;

namespace behaviac
{
	// Token: 0x020020EE RID: 8430
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node7 : Condition
	{
		// Token: 0x06012B70 RID: 76656 RVA: 0x0057F8CE File Offset: 0x0057DCCE
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node7()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012B71 RID: 76657 RVA: 0x0057F8E4 File Offset: 0x0057DCE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C563 RID: 50531
		private float opl_p0;
	}
}
