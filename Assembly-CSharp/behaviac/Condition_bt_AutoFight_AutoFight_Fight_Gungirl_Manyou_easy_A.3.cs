using System;

namespace behaviac
{
	// Token: 0x02001FC3 RID: 8131
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node7 : Condition
	{
		// Token: 0x06012923 RID: 76067 RVA: 0x00571386 File Offset: 0x0056F786
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node7()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x06012924 RID: 76068 RVA: 0x0057139C File Offset: 0x0056F79C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C315 RID: 49941
		private float opl_p0;
	}
}
