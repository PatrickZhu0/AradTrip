using System;

namespace behaviac
{
	// Token: 0x02003C58 RID: 15448
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node36 : Condition
	{
		// Token: 0x06016058 RID: 90200 RVA: 0x006A7DD6 File Offset: 0x006A61D6
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node36()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06016059 RID: 90201 RVA: 0x006A7DEC File Offset: 0x006A61EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8D3 RID: 63699
		private int opl_p0;
	}
}
