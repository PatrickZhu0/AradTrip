using System;

namespace behaviac
{
	// Token: 0x020036EB RID: 14059
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node4 : Condition
	{
		// Token: 0x060155EA RID: 87530 RVA: 0x0067291B File Offset: 0x00670D1B
		public Condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node4()
		{
			this.opl_p0 = 7274;
		}

		// Token: 0x060155EB RID: 87531 RVA: 0x00672930 File Offset: 0x00670D30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFBD RID: 61373
		private int opl_p0;
	}
}
