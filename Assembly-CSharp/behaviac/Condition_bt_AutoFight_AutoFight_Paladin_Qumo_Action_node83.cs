using System;

namespace behaviac
{
	// Token: 0x020027F5 RID: 10229
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node83 : Condition
	{
		// Token: 0x06013929 RID: 80169 RVA: 0x005D5C47 File Offset: 0x005D4047
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node83()
		{
			this.opl_p0 = 3505;
		}

		// Token: 0x0601392A RID: 80170 RVA: 0x005D5C5C File Offset: 0x005D405C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D388 RID: 54152
		private int opl_p0;
	}
}
