using System;

namespace behaviac
{
	// Token: 0x02003D9B RID: 15771
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node13 : Condition
	{
		// Token: 0x060162C8 RID: 90824 RVA: 0x006B42F8 File Offset: 0x006B26F8
		public Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node13()
		{
			this.opl_p0 = 570153;
		}

		// Token: 0x060162C9 RID: 90825 RVA: 0x006B430C File Offset: 0x006B270C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB19 RID: 64281
		private int opl_p0;
	}
}
