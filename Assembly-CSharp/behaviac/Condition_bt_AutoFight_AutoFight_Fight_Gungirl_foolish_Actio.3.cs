using System;

namespace behaviac
{
	// Token: 0x02001F93 RID: 8083
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node7 : Condition
	{
		// Token: 0x060128C5 RID: 75973 RVA: 0x0056EEB6 File Offset: 0x0056D2B6
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node7()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060128C6 RID: 75974 RVA: 0x0056EECC File Offset: 0x0056D2CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2B7 RID: 49847
		private float opl_p0;
	}
}
