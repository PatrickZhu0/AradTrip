using System;

namespace behaviac
{
	// Token: 0x02003E0D RID: 15885
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node2 : Condition
	{
		// Token: 0x060163A3 RID: 91043 RVA: 0x006B83B2 File Offset: 0x006B67B2
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node2()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 8000;
			this.opl_p2 = 8000;
			this.opl_p3 = 8000;
		}

		// Token: 0x060163A4 RID: 91044 RVA: 0x006B83E8 File Offset: 0x006B67E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC09 RID: 64521
		private int opl_p0;

		// Token: 0x0400FC0A RID: 64522
		private int opl_p1;

		// Token: 0x0400FC0B RID: 64523
		private int opl_p2;

		// Token: 0x0400FC0C RID: 64524
		private int opl_p3;
	}
}
