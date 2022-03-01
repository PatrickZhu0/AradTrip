using System;

namespace behaviac
{
	// Token: 0x02002834 RID: 10292
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node34 : Condition
	{
		// Token: 0x060139A6 RID: 80294 RVA: 0x005D92E5 File Offset: 0x005D76E5
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node34()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x060139A7 RID: 80295 RVA: 0x005D92F8 File Offset: 0x005D76F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D400 RID: 54272
		private float opl_p0;
	}
}
