using System;

namespace behaviac
{
	// Token: 0x020039D9 RID: 14809
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node32 : Condition
	{
		// Token: 0x06015B82 RID: 88962 RVA: 0x0068F3B3 File Offset: 0x0068D7B3
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node32()
		{
			this.opl_p0 = 21176;
		}

		// Token: 0x06015B83 RID: 88963 RVA: 0x0068F3C8 File Offset: 0x0068D7C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4C9 RID: 62665
		private int opl_p0;
	}
}
