using System;

namespace behaviac
{
	// Token: 0x02001FDB RID: 8155
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node37 : Condition
	{
		// Token: 0x06012953 RID: 76115 RVA: 0x00571E8E File Offset: 0x0057028E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node37()
		{
			this.opl_p0 = 0.43f;
		}

		// Token: 0x06012954 RID: 76116 RVA: 0x00571EA4 File Offset: 0x005702A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C345 RID: 49989
		private float opl_p0;
	}
}
