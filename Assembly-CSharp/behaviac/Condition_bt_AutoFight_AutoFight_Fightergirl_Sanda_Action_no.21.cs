using System;

namespace behaviac
{
	// Token: 0x02001F3F RID: 7999
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node31 : Condition
	{
		// Token: 0x06012821 RID: 75809 RVA: 0x0056AADB File Offset: 0x00568EDB
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node31()
		{
			this.opl_p0 = 3201;
		}

		// Token: 0x06012822 RID: 75810 RVA: 0x0056AAF0 File Offset: 0x00568EF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C218 RID: 49688
		private int opl_p0;
	}
}
