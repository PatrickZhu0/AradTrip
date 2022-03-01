using System;

namespace behaviac
{
	// Token: 0x02003BAC RID: 15276
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node14 : Condition
	{
		// Token: 0x06015F08 RID: 89864 RVA: 0x006A0B8E File Offset: 0x0069EF8E
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node14()
		{
			this.opl_p0 = 21072;
		}

		// Token: 0x06015F09 RID: 89865 RVA: 0x006A0BA4 File Offset: 0x0069EFA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7AD RID: 63405
		private int opl_p0;
	}
}
