using System;

namespace behaviac
{
	// Token: 0x02001F4B RID: 8011
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node37 : Condition
	{
		// Token: 0x06012839 RID: 75833 RVA: 0x0056B086 File Offset: 0x00569486
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node37()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601283A RID: 75834 RVA: 0x0056B09C File Offset: 0x0056949C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C233 RID: 49715
		private float opl_p0;
	}
}
