using System;

namespace behaviac
{
	// Token: 0x02001EED RID: 7917
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node25 : Condition
	{
		// Token: 0x0601277F RID: 75647 RVA: 0x00566D1B File Offset: 0x0056511B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node25()
		{
			this.opl_p0 = 3010;
		}

		// Token: 0x06012780 RID: 75648 RVA: 0x00566D30 File Offset: 0x00565130
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C175 RID: 49525
		private int opl_p0;
	}
}
