using System;

namespace behaviac
{
	// Token: 0x02001FBB RID: 8123
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node27 : Condition
	{
		// Token: 0x06012914 RID: 76052 RVA: 0x00570946 File Offset: 0x0056ED46
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node27()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012915 RID: 76053 RVA: 0x0057095C File Offset: 0x0056ED5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C306 RID: 49926
		private float opl_p0;
	}
}
