using System;

namespace behaviac
{
	// Token: 0x020035B1 RID: 13745
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node6 : Condition
	{
		// Token: 0x06015390 RID: 86928 RVA: 0x006658E7 File Offset: 0x00663CE7
		public Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node6()
		{
			this.opl_p0 = 5333;
		}

		// Token: 0x06015391 RID: 86929 RVA: 0x006658FC File Offset: 0x00663CFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED5D RID: 60765
		private int opl_p0;
	}
}
