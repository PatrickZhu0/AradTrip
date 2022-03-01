using System;

namespace behaviac
{
	// Token: 0x02002271 RID: 8817
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node20 : Condition
	{
		// Token: 0x06012E66 RID: 77414 RVA: 0x00592DD8 File Offset: 0x005911D8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node20()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012E67 RID: 77415 RVA: 0x00592DEC File Offset: 0x005911EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C873 RID: 51315
		private float opl_p0;
	}
}
