using System;

namespace behaviac
{
	// Token: 0x02003CA9 RID: 15529
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node71 : Condition
	{
		// Token: 0x060160F9 RID: 90361 RVA: 0x006AA429 File Offset: 0x006A8829
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node71()
		{
			this.opl_p0 = 21054;
		}

		// Token: 0x060160FA RID: 90362 RVA: 0x006AA43C File Offset: 0x006A883C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9A1 RID: 63905
		private int opl_p0;
	}
}
