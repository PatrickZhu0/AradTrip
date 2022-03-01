using System;

namespace behaviac
{
	// Token: 0x02003BB6 RID: 15286
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node23 : Condition
	{
		// Token: 0x06015F1C RID: 89884 RVA: 0x006A0EF5 File Offset: 0x0069F2F5
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node23()
		{
			this.opl_p0 = 21058;
		}

		// Token: 0x06015F1D RID: 89885 RVA: 0x006A0F08 File Offset: 0x0069F308
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7B7 RID: 63415
		private int opl_p0;
	}
}
