using System;

namespace behaviac
{
	// Token: 0x02003BA0 RID: 15264
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node27 : Condition
	{
		// Token: 0x06015EF0 RID: 89840 RVA: 0x006A0672 File Offset: 0x0069EA72
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node27()
		{
			this.opl_p0 = 21159;
		}

		// Token: 0x06015EF1 RID: 89841 RVA: 0x006A0688 File Offset: 0x0069EA88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F799 RID: 63385
		private int opl_p0;
	}
}
