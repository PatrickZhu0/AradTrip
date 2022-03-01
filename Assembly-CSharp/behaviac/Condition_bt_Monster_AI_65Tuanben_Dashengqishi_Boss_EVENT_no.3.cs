using System;

namespace behaviac
{
	// Token: 0x02002DB9 RID: 11705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node12 : Condition
	{
		// Token: 0x06014451 RID: 83025 RVA: 0x006175E5 File Offset: 0x006159E5
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node12()
		{
			this.opl_p0 = 21651;
		}

		// Token: 0x06014452 RID: 83026 RVA: 0x006175F8 File Offset: 0x006159F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE1A RID: 56858
		private int opl_p0;
	}
}
