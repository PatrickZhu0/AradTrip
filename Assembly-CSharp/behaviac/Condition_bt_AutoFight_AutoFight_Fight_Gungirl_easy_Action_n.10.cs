using System;

namespace behaviac
{
	// Token: 0x02001F83 RID: 8067
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node17 : Condition
	{
		// Token: 0x060128A6 RID: 75942 RVA: 0x0056DFAE File Offset: 0x0056C3AE
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node17()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060128A7 RID: 75943 RVA: 0x0056DFC4 File Offset: 0x0056C3C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C298 RID: 49816
		private float opl_p0;
	}
}
