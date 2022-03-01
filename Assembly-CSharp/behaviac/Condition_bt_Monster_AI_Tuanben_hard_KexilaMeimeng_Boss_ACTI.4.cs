using System;

namespace behaviac
{
	// Token: 0x02003C09 RID: 15369
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node85 : Condition
	{
		// Token: 0x06015FBD RID: 90045 RVA: 0x006A4A37 File Offset: 0x006A2E37
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node85()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015FBE RID: 90046 RVA: 0x006A4A48 File Offset: 0x006A2E48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F83F RID: 63551
		private int opl_p0;
	}
}
