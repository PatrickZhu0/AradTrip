using System;

namespace behaviac
{
	// Token: 0x02003E12 RID: 15890
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node20 : Condition
	{
		// Token: 0x060163AD RID: 91053 RVA: 0x006B85E1 File Offset: 0x006B69E1
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node20()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060163AE RID: 91054 RVA: 0x006B8618 File Offset: 0x006B6A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC15 RID: 64533
		private int opl_p0;

		// Token: 0x0400FC16 RID: 64534
		private int opl_p1;

		// Token: 0x0400FC17 RID: 64535
		private int opl_p2;

		// Token: 0x0400FC18 RID: 64536
		private int opl_p3;
	}
}
