using System;

namespace behaviac
{
	// Token: 0x02003D5A RID: 15706
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node22 : Condition
	{
		// Token: 0x0601624A RID: 90698 RVA: 0x006B10DB File Offset: 0x006AF4DB
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node22()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x0601624B RID: 90699 RVA: 0x006B10EC File Offset: 0x006AF4EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAA8 RID: 64168
		private int opl_p0;
	}
}
