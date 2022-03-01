using System;

namespace behaviac
{
	// Token: 0x02001F58 RID: 8024
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node50 : Condition
	{
		// Token: 0x06012853 RID: 75859 RVA: 0x0056B5F7 File Offset: 0x005699F7
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node50()
		{
			this.opl_p0 = 3009;
		}

		// Token: 0x06012854 RID: 75860 RVA: 0x0056B60C File Offset: 0x00569A0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C24C RID: 49740
		private int opl_p0;
	}
}
