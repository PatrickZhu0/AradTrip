using System;

namespace behaviac
{
	// Token: 0x0200367D RID: 13949
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node24 : Condition
	{
		// Token: 0x0601551B RID: 87323 RVA: 0x0066DD3B File Offset: 0x0066C13B
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node24()
		{
			this.opl_p0 = 5424;
		}

		// Token: 0x0601551C RID: 87324 RVA: 0x0066DD50 File Offset: 0x0066C150
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EED2 RID: 61138
		private int opl_p0;
	}
}
