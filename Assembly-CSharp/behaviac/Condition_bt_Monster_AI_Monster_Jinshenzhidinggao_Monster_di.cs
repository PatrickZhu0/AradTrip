using System;

namespace behaviac
{
	// Token: 0x02003687 RID: 13959
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node12 : Condition
	{
		// Token: 0x0601552C RID: 87340 RVA: 0x0066E974 File Offset: 0x0066CD74
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node12()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521235;
		}

		// Token: 0x0601552D RID: 87341 RVA: 0x0066E998 File Offset: 0x0066CD98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEEA RID: 61162
		private BE_Target opl_p0;

		// Token: 0x0400EEEB RID: 61163
		private BE_Equal opl_p1;

		// Token: 0x0400EEEC RID: 61164
		private int opl_p2;
	}
}
