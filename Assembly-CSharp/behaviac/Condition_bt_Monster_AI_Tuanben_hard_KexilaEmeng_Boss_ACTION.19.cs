using System;

namespace behaviac
{
	// Token: 0x02003BA4 RID: 15268
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node17 : Condition
	{
		// Token: 0x06015EF8 RID: 89848 RVA: 0x006A080B File Offset: 0x0069EC0B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node17()
		{
			this.opl_p0 = 21075;
		}

		// Token: 0x06015EF9 RID: 89849 RVA: 0x006A0820 File Offset: 0x0069EC20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7A0 RID: 63392
		private int opl_p0;
	}
}
