using System;

namespace behaviac
{
	// Token: 0x020039E1 RID: 14817
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node17 : Condition
	{
		// Token: 0x06015B92 RID: 88978 RVA: 0x0068F6CB File Offset: 0x0068DACB
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node17()
		{
			this.opl_p0 = 21075;
		}

		// Token: 0x06015B93 RID: 88979 RVA: 0x0068F6E0 File Offset: 0x0068DAE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4D5 RID: 62677
		private int opl_p0;
	}
}
