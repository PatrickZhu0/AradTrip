using System;

namespace behaviac
{
	// Token: 0x02001F36 RID: 7990
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node54 : Condition
	{
		// Token: 0x0601280F RID: 75791 RVA: 0x0056A6FB File Offset: 0x00568AFB
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node54()
		{
			this.opl_p0 = 3208;
		}

		// Token: 0x06012810 RID: 75792 RVA: 0x0056A710 File Offset: 0x00568B10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C204 RID: 49668
		private int opl_p0;
	}
}
