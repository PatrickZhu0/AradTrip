using System;

namespace behaviac
{
	// Token: 0x02001F8F RID: 8079
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node2 : Condition
	{
		// Token: 0x060128BD RID: 75965 RVA: 0x0056EC6A File Offset: 0x0056D06A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node2()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060128BE RID: 75966 RVA: 0x0056EC80 File Offset: 0x0056D080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2AF RID: 49839
		private float opl_p0;
	}
}
