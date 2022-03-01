using System;

namespace behaviac
{
	// Token: 0x02003BB9 RID: 15289
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node59 : Condition
	{
		// Token: 0x06015F22 RID: 89890 RVA: 0x006A102B File Offset: 0x0069F42B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node59()
		{
			this.opl_p0 = 21507;
		}

		// Token: 0x06015F23 RID: 89891 RVA: 0x006A1040 File Offset: 0x0069F440
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7BB RID: 63419
		private int opl_p0;
	}
}
