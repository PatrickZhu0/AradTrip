using System;

namespace behaviac
{
	// Token: 0x02003C97 RID: 15511
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node48 : Condition
	{
		// Token: 0x060160D5 RID: 90325 RVA: 0x006A9C39 File Offset: 0x006A8039
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node48()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x060160D6 RID: 90326 RVA: 0x006A9C4C File Offset: 0x006A804C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F973 RID: 63859
		private int opl_p0;
	}
}
