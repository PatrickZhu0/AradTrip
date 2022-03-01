using System;

namespace behaviac
{
	// Token: 0x02003C8D RID: 15501
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node50 : Condition
	{
		// Token: 0x060160C1 RID: 90305 RVA: 0x006A9795 File Offset: 0x006A7B95
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node50()
		{
			this.opl_p0 = 21061;
		}

		// Token: 0x060160C2 RID: 90306 RVA: 0x006A97A8 File Offset: 0x006A7BA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F95B RID: 63835
		private int opl_p0;
	}
}
