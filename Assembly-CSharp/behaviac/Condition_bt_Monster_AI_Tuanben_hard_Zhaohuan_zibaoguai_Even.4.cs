using System;

namespace behaviac
{
	// Token: 0x02003D9E RID: 15774
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node8 : Condition
	{
		// Token: 0x060162CE RID: 90830 RVA: 0x006B43CB File Offset: 0x006B27CB
		public Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node8()
		{
			this.opl_p0 = 21402;
		}

		// Token: 0x060162CF RID: 90831 RVA: 0x006B43E0 File Offset: 0x006B27E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB1C RID: 64284
		private int opl_p0;
	}
}
