using System;

namespace behaviac
{
	// Token: 0x02003DA4 RID: 15780
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node1 : Condition
	{
		// Token: 0x060162DA RID: 90842 RVA: 0x006B45D9 File Offset: 0x006B29D9
		public Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node1()
		{
			this.opl_p0 = 21360;
		}

		// Token: 0x060162DB RID: 90843 RVA: 0x006B45EC File Offset: 0x006B29EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB27 RID: 64295
		private int opl_p0;
	}
}
