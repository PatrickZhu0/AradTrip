using System;

namespace behaviac
{
	// Token: 0x02003A23 RID: 14883
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node35 : Condition
	{
		// Token: 0x06015C10 RID: 89104 RVA: 0x00692016 File Offset: 0x00690416
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node35()
		{
			this.opl_p0 = 21066;
		}

		// Token: 0x06015C11 RID: 89105 RVA: 0x0069202C File Offset: 0x0069042C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F528 RID: 62760
		private int opl_p0;
	}
}
