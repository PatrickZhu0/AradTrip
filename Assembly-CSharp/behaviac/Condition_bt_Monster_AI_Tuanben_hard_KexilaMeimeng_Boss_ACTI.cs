using System;

namespace behaviac
{
	// Token: 0x02003C04 RID: 15364
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node45 : Condition
	{
		// Token: 0x06015FB3 RID: 90035 RVA: 0x006A4887 File Offset: 0x006A2C87
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node45()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015FB4 RID: 90036 RVA: 0x006A4898 File Offset: 0x006A2C98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F838 RID: 63544
		private int opl_p0;
	}
}
