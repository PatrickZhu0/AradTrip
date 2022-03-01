using System;

namespace behaviac
{
	// Token: 0x02003BAF RID: 15279
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node11 : Condition
	{
		// Token: 0x06015F0E RID: 89870 RVA: 0x006A0CC7 File Offset: 0x0069F0C7
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node11()
		{
			this.opl_p0 = 21056;
		}

		// Token: 0x06015F0F RID: 89871 RVA: 0x006A0CDC File Offset: 0x0069F0DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7B1 RID: 63409
		private int opl_p0;
	}
}
