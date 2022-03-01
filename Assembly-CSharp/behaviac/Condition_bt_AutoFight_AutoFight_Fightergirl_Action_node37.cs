using System;

namespace behaviac
{
	// Token: 0x02001ED6 RID: 7894
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node37 : Condition
	{
		// Token: 0x06012751 RID: 75601 RVA: 0x0056637B File Offset: 0x0056477B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node37()
		{
			this.opl_p0 = 3117;
		}

		// Token: 0x06012752 RID: 75602 RVA: 0x00566390 File Offset: 0x00564790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C143 RID: 49475
		private int opl_p0;
	}
}
