using System;

namespace behaviac
{
	// Token: 0x02003114 RID: 12564
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node3 : Condition
	{
		// Token: 0x06014AD1 RID: 84689 RVA: 0x00639F5B File Offset: 0x0063835B
		public Condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node3()
		{
			this.opl_p0 = 20717;
		}

		// Token: 0x06014AD2 RID: 84690 RVA: 0x00639F70 File Offset: 0x00638370
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E440 RID: 58432
		private int opl_p0;
	}
}
