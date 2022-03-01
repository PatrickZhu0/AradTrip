using System;

namespace behaviac
{
	// Token: 0x0200274D RID: 10061
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node49 : Condition
	{
		// Token: 0x060137DB RID: 79835 RVA: 0x005CF476 File Offset: 0x005CD876
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node49()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060137DC RID: 79836 RVA: 0x005CF4AC File Offset: 0x005CD8AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D235 RID: 53813
		private int opl_p0;

		// Token: 0x0400D236 RID: 53814
		private int opl_p1;

		// Token: 0x0400D237 RID: 53815
		private int opl_p2;

		// Token: 0x0400D238 RID: 53816
		private int opl_p3;
	}
}
