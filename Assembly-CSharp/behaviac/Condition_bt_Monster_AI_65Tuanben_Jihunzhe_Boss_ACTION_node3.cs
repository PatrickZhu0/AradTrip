using System;

namespace behaviac
{
	// Token: 0x02002F04 RID: 12036
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node36 : Condition
	{
		// Token: 0x060146DF RID: 83679 RVA: 0x00625507 File Offset: 0x00623907
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node36()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060146E0 RID: 83680 RVA: 0x00625518 File Offset: 0x00623918
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E059 RID: 57433
		private int opl_p0;
	}
}
