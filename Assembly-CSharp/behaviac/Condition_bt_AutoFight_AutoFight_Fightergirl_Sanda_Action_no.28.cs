using System;

namespace behaviac
{
	// Token: 0x02001F48 RID: 8008
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node65 : Condition
	{
		// Token: 0x06012833 RID: 75827 RVA: 0x0056AEBB File Offset: 0x005692BB
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node65()
		{
			this.opl_p0 = 3200;
		}

		// Token: 0x06012834 RID: 75828 RVA: 0x0056AED0 File Offset: 0x005692D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C22C RID: 49708
		private int opl_p0;
	}
}
