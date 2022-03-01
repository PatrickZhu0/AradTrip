using System;

namespace behaviac
{
	// Token: 0x02003C6F RID: 15471
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node82 : Condition
	{
		// Token: 0x06016085 RID: 90245 RVA: 0x006A8B3B File Offset: 0x006A6F3B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node82()
		{
			this.opl_p0 = 21053;
		}

		// Token: 0x06016086 RID: 90246 RVA: 0x006A8B50 File Offset: 0x006A6F50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F90D RID: 63757
		private int opl_p0;
	}
}
