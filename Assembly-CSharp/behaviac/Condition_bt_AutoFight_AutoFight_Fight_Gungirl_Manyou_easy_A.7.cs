using System;

namespace behaviac
{
	// Token: 0x02001FCB RID: 8139
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node17 : Condition
	{
		// Token: 0x06012933 RID: 76083 RVA: 0x0057176E File Offset: 0x0056FB6E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node17()
		{
			this.opl_p0 = 0.38f;
		}

		// Token: 0x06012934 RID: 76084 RVA: 0x00571784 File Offset: 0x0056FB84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C325 RID: 49957
		private float opl_p0;
	}
}
