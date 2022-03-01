using System;

namespace behaviac
{
	// Token: 0x02002815 RID: 10261
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node48 : Condition
	{
		// Token: 0x06013968 RID: 80232 RVA: 0x005D8603 File Offset: 0x005D6A03
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node48()
		{
			this.opl_p0 = 3703;
		}

		// Token: 0x06013969 RID: 80233 RVA: 0x005D8618 File Offset: 0x005D6A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3C6 RID: 54214
		private int opl_p0;
	}
}
