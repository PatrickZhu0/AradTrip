using System;

namespace behaviac
{
	// Token: 0x02001F87 RID: 8071
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node22 : Condition
	{
		// Token: 0x060128AE RID: 75950 RVA: 0x0056E212 File Offset: 0x0056C612
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node22()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060128AF RID: 75951 RVA: 0x0056E228 File Offset: 0x0056C628
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2A0 RID: 49824
		private float opl_p0;
	}
}
