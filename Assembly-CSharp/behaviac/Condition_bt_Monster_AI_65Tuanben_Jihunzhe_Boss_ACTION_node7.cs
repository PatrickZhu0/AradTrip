using System;

namespace behaviac
{
	// Token: 0x02002F06 RID: 12038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7 : Condition
	{
		// Token: 0x060146E3 RID: 83683 RVA: 0x006255AB File Offset: 0x006239AB
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7()
		{
			this.opl_p0 = 21614;
		}

		// Token: 0x060146E4 RID: 83684 RVA: 0x006255C0 File Offset: 0x006239C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E05D RID: 57437
		private int opl_p0;
	}
}
