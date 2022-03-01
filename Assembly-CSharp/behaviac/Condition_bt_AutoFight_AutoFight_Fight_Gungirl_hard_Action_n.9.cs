using System;

namespace behaviac
{
	// Token: 0x02001FB7 RID: 8119
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node22 : Condition
	{
		// Token: 0x0601290C RID: 76044 RVA: 0x005707AA File Offset: 0x0056EBAA
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node22()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601290D RID: 76045 RVA: 0x005707C0 File Offset: 0x0056EBC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2FE RID: 49918
		private float opl_p0;
	}
}
