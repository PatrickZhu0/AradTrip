using System;

namespace behaviac
{
	// Token: 0x020039D0 RID: 14800
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node46 : Condition
	{
		// Token: 0x06015B70 RID: 88944 RVA: 0x0068F0A5 File Offset: 0x0068D4A5
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node46()
		{
			this.opl_p0 = 21172;
		}

		// Token: 0x06015B71 RID: 88945 RVA: 0x0068F0B8 File Offset: 0x0068D4B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4BE RID: 62654
		private int opl_p0;
	}
}
