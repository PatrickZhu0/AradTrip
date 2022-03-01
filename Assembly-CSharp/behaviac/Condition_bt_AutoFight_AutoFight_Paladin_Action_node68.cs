using System;

namespace behaviac
{
	// Token: 0x02002795 RID: 10133
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node68 : Condition
	{
		// Token: 0x0601386A RID: 79978 RVA: 0x005D261F File Offset: 0x005D0A1F
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node68()
		{
			this.opl_p0 = 3614;
		}

		// Token: 0x0601386B RID: 79979 RVA: 0x005D2634 File Offset: 0x005D0A34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2CA RID: 53962
		private int opl_p0;
	}
}
