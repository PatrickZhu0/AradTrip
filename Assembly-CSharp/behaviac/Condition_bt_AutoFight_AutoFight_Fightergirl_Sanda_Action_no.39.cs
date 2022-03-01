using System;

namespace behaviac
{
	// Token: 0x02001F57 RID: 8023
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node48 : Condition
	{
		// Token: 0x06012851 RID: 75857 RVA: 0x0056B5AE File Offset: 0x005699AE
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node48()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06012852 RID: 75858 RVA: 0x0056B5C4 File Offset: 0x005699C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C24B RID: 49739
		private float opl_p0;
	}
}
