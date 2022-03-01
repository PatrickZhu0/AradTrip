using System;

namespace behaviac
{
	// Token: 0x02001EE8 RID: 7912
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node20 : Condition
	{
		// Token: 0x06012775 RID: 75637 RVA: 0x00566B0F File Offset: 0x00564F0F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node20()
		{
			this.opl_p0 = 3005;
		}

		// Token: 0x06012776 RID: 75638 RVA: 0x00566B24 File Offset: 0x00564F24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C16A RID: 49514
		private int opl_p0;
	}
}
