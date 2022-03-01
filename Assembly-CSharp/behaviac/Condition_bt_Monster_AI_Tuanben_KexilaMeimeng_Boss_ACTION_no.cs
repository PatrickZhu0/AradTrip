using System;

namespace behaviac
{
	// Token: 0x02003A18 RID: 14872
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node45 : Condition
	{
		// Token: 0x06015BFA RID: 89082 RVA: 0x00691C31 File Offset: 0x00690031
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node45()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015BFB RID: 89083 RVA: 0x00691C40 File Offset: 0x00690040
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F513 RID: 62739
		private int opl_p0;
	}
}
