using System;

namespace behaviac
{
	// Token: 0x02003A4F RID: 14927
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node5 : Condition
	{
		// Token: 0x06015C67 RID: 89191 RVA: 0x00693A5F File Offset: 0x00691E5F
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node5()
		{
			this.opl_p0 = 10000;
		}

		// Token: 0x06015C68 RID: 89192 RVA: 0x00693A74 File Offset: 0x00691E74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckYDis(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F591 RID: 62865
		private int opl_p0;
	}
}
