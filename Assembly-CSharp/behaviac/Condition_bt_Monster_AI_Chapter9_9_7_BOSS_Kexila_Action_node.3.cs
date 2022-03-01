using System;

namespace behaviac
{
	// Token: 0x020031FE RID: 12798
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14 : Condition
	{
		// Token: 0x06014C86 RID: 85126 RVA: 0x00642D1B File Offset: 0x0064111B
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14()
		{
			this.opl_p0 = 21562;
		}

		// Token: 0x06014C87 RID: 85127 RVA: 0x00642D30 File Offset: 0x00641130
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5DA RID: 58842
		private int opl_p0;
	}
}
