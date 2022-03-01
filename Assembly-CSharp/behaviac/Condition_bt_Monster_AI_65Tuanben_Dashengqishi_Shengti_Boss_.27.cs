using System;

namespace behaviac
{
	// Token: 0x02002DFB RID: 11771
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node55 : Condition
	{
		// Token: 0x060144D3 RID: 83155 RVA: 0x006192DD File Offset: 0x006176DD
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node55()
		{
			this.opl_p0 = 21638;
		}

		// Token: 0x060144D4 RID: 83156 RVA: 0x006192F0 File Offset: 0x006176F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE84 RID: 56964
		private int opl_p0;
	}
}
