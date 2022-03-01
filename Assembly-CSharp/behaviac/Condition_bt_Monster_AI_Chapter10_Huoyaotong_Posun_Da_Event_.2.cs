using System;

namespace behaviac
{
	// Token: 0x02003118 RID: 12568
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Da_Event_node3 : Condition
	{
		// Token: 0x06014AD8 RID: 84696 RVA: 0x0063A1AB File Offset: 0x006385AB
		public Condition_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Da_Event_node3()
		{
			this.opl_p0 = 20720;
		}

		// Token: 0x06014AD9 RID: 84697 RVA: 0x0063A1C0 File Offset: 0x006385C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E446 RID: 58438
		private int opl_p0;
	}
}
