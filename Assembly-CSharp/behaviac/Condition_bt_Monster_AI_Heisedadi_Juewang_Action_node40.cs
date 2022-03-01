using System;

namespace behaviac
{
	// Token: 0x0200346B RID: 13419
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node40 : Condition
	{
		// Token: 0x06015121 RID: 86305 RVA: 0x00659656 File Offset: 0x00657A56
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node40()
		{
			this.opl_p0 = 900000;
			this.opl_p1 = 900000;
			this.opl_p2 = 900000;
			this.opl_p3 = 900000;
		}

		// Token: 0x06015122 RID: 86306 RVA: 0x0065968C File Offset: 0x00657A8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA21 RID: 59937
		private int opl_p0;

		// Token: 0x0400EA22 RID: 59938
		private int opl_p1;

		// Token: 0x0400EA23 RID: 59939
		private int opl_p2;

		// Token: 0x0400EA24 RID: 59940
		private int opl_p3;
	}
}
