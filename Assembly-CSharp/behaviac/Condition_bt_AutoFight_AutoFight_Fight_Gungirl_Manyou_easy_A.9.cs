using System;

namespace behaviac
{
	// Token: 0x02001FCF RID: 8143
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node22 : Condition
	{
		// Token: 0x0601293B RID: 76091 RVA: 0x0057190A File Offset: 0x0056FD0A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node22()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601293C RID: 76092 RVA: 0x00571920 File Offset: 0x0056FD20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C32D RID: 49965
		private float opl_p0;
	}
}
