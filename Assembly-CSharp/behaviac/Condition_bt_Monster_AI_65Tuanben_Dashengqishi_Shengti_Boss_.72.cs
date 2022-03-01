using System;

namespace behaviac
{
	// Token: 0x02002E4A RID: 11850
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node218 : Condition
	{
		// Token: 0x06014571 RID: 83313 RVA: 0x0061B18E File Offset: 0x0061958E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node218()
		{
			this.opl_p0 = 21640;
		}

		// Token: 0x06014572 RID: 83314 RVA: 0x0061B1A4 File Offset: 0x006195A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF01 RID: 57089
		private int opl_p0;
	}
}
