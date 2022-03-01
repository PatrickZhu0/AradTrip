using System;

namespace behaviac
{
	// Token: 0x02003A1D RID: 14877
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node85 : Condition
	{
		// Token: 0x06015C04 RID: 89092 RVA: 0x00691DDF File Offset: 0x006901DF
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node85()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015C05 RID: 89093 RVA: 0x00691DF0 File Offset: 0x006901F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F51A RID: 62746
		private int opl_p0;
	}
}
