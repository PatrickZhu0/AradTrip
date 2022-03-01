using System;

namespace behaviac
{
	// Token: 0x02003BA7 RID: 15271
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node7 : Condition
	{
		// Token: 0x06015EFE RID: 89854 RVA: 0x006A0946 File Offset: 0x0069ED46
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node7()
		{
			this.opl_p0 = 21073;
		}

		// Token: 0x06015EFF RID: 89855 RVA: 0x006A095C File Offset: 0x0069ED5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7A4 RID: 63396
		private int opl_p0;
	}
}
