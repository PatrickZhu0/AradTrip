using System;

namespace behaviac
{
	// Token: 0x02002152 RID: 8530
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node2 : Condition
	{
		// Token: 0x06012C35 RID: 76853 RVA: 0x0058457A File Offset: 0x0058297A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node2()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06012C36 RID: 76854 RVA: 0x00584590 File Offset: 0x00582990
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C628 RID: 50728
		private float opl_p0;
	}
}
