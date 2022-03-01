using System;

namespace behaviac
{
	// Token: 0x020035B0 RID: 13744
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5 : Condition
	{
		// Token: 0x0601538E RID: 86926 RVA: 0x0066589F File Offset: 0x00663C9F
		public Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601538F RID: 86927 RVA: 0x006658B4 File Offset: 0x00663CB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED5C RID: 60764
		private float opl_p0;
	}
}
