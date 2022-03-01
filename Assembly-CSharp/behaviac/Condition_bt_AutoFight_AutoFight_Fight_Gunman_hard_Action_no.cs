using System;

namespace behaviac
{
	// Token: 0x020020EA RID: 8426
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node2 : Condition
	{
		// Token: 0x06012B68 RID: 76648 RVA: 0x0057F682 File Offset: 0x0057DA82
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node2()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012B69 RID: 76649 RVA: 0x0057F698 File Offset: 0x0057DA98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C55B RID: 50523
		private float opl_p0;
	}
}
