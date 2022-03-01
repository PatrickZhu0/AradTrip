using System;

namespace behaviac
{
	// Token: 0x020039D5 RID: 14805
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node98 : Condition
	{
		// Token: 0x06015B7A RID: 88954 RVA: 0x0068F247 File Offset: 0x0068D647
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node98()
		{
			this.opl_p0 = 21174;
		}

		// Token: 0x06015B7B RID: 88955 RVA: 0x0068F25C File Offset: 0x0068D65C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4C3 RID: 62659
		private int opl_p0;
	}
}
