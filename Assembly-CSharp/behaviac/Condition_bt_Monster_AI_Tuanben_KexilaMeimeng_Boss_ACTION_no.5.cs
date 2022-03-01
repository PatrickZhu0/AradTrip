using System;

namespace behaviac
{
	// Token: 0x02003A1E RID: 14878
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node98 : Condition
	{
		// Token: 0x06015C06 RID: 89094 RVA: 0x00691E23 File Offset: 0x00690223
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node98()
		{
			this.opl_p0 = 21171;
		}

		// Token: 0x06015C07 RID: 89095 RVA: 0x00691E38 File Offset: 0x00690238
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F51B RID: 62747
		private int opl_p0;
	}
}
