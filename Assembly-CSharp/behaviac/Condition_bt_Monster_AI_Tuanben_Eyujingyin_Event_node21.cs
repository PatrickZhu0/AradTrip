using System;

namespace behaviac
{
	// Token: 0x02003997 RID: 14743
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node21 : Condition
	{
		// Token: 0x06015B03 RID: 88835 RVA: 0x0068CEEA File Offset: 0x0068B2EA
		public Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node21()
		{
			this.opl_p0 = 21038;
		}

		// Token: 0x06015B04 RID: 88836 RVA: 0x0068CF00 File Offset: 0x0068B300
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F49B RID: 62619
		private int opl_p0;
	}
}
