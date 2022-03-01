using System;

namespace behaviac
{
	// Token: 0x020039EF RID: 14831
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node20 : Condition
	{
		// Token: 0x06015BAE RID: 89006 RVA: 0x0068FC6A File Offset: 0x0068E06A
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node20()
		{
			this.opl_p0 = 21071;
		}

		// Token: 0x06015BAF RID: 89007 RVA: 0x0068FC80 File Offset: 0x0068E080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4E8 RID: 62696
		private int opl_p0;
	}
}
