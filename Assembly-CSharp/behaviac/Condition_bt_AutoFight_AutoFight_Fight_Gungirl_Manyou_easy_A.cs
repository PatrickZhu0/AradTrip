using System;

namespace behaviac
{
	// Token: 0x02001FBF RID: 8127
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node2 : Condition
	{
		// Token: 0x0601291B RID: 76059 RVA: 0x005711EA File Offset: 0x0056F5EA
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node2()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601291C RID: 76060 RVA: 0x00571200 File Offset: 0x0056F600
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C30D RID: 49933
		private float opl_p0;
	}
}
