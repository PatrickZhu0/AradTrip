using System;

namespace behaviac
{
	// Token: 0x02003A30 RID: 14896
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node23 : Condition
	{
		// Token: 0x06015C2A RID: 89130 RVA: 0x00692559 File Offset: 0x00690959
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node23()
		{
			this.opl_p0 = 21064;
		}

		// Token: 0x06015C2B RID: 89131 RVA: 0x0069256C File Offset: 0x0069096C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F543 RID: 62787
		private int opl_p0;
	}
}
