using System;

namespace behaviac
{
	// Token: 0x0200398D RID: 14733
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node1 : Condition
	{
		// Token: 0x06015AEF RID: 88815 RVA: 0x0068CB87 File Offset: 0x0068AF87
		public Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node1()
		{
			this.opl_p0 = 21039;
		}

		// Token: 0x06015AF0 RID: 88816 RVA: 0x0068CB9C File Offset: 0x0068AF9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F48B RID: 62603
		private int opl_p0;
	}
}
