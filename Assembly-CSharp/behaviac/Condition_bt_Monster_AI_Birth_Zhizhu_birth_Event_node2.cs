using System;

namespace behaviac
{
	// Token: 0x02002F31 RID: 12081
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2 : Condition
	{
		// Token: 0x06014734 RID: 83764 RVA: 0x006271C7 File Offset: 0x006255C7
		public Condition_bt_Monster_AI_Birth_Zhizhu_birth_Event_node2()
		{
			this.opl_p0 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p1 = 1;
		}

		// Token: 0x06014735 RID: 83765 RVA: 0x006271E0 File Offset: 0x006255E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckLastResult(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0A5 RID: 57509
		private BE_Operation opl_p0;

		// Token: 0x0400E0A6 RID: 57510
		private int opl_p1;
	}
}
