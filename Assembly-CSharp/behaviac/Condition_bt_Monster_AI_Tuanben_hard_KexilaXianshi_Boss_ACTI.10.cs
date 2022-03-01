using System;

namespace behaviac
{
	// Token: 0x02003C74 RID: 15476
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node15 : Condition
	{
		// Token: 0x0601608F RID: 90255 RVA: 0x006A8D57 File Offset: 0x006A7157
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node15()
		{
			this.opl_p0 = 21455;
		}

		// Token: 0x06016090 RID: 90256 RVA: 0x006A8D6C File Offset: 0x006A716C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F91B RID: 63771
		private int opl_p0;
	}
}
