using System;

namespace behaviac
{
	// Token: 0x02002821 RID: 10273
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node68 : Condition
	{
		// Token: 0x06013980 RID: 80256 RVA: 0x005D8AD7 File Offset: 0x005D6ED7
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node68()
		{
			this.opl_p0 = 3706;
		}

		// Token: 0x06013981 RID: 80257 RVA: 0x005D8AEC File Offset: 0x005D6EEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3DB RID: 54235
		private int opl_p0;
	}
}
