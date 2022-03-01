using System;

namespace behaviac
{
	// Token: 0x02003C82 RID: 15490
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node4 : Condition
	{
		// Token: 0x060160AB RID: 90283 RVA: 0x006A928F File Offset: 0x006A768F
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node4()
		{
			this.opl_p0 = 21472;
		}

		// Token: 0x060160AC RID: 90284 RVA: 0x006A92A4 File Offset: 0x006A76A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F940 RID: 63808
		private int opl_p0;
	}
}
