using System;

namespace behaviac
{
	// Token: 0x02002734 RID: 10036
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node24 : Condition
	{
		// Token: 0x060137AA RID: 79786 RVA: 0x005CD58A File Offset: 0x005CB98A
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node24()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 800;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060137AB RID: 79787 RVA: 0x005CD5C0 File Offset: 0x005CB9C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D203 RID: 53763
		private int opl_p0;

		// Token: 0x0400D204 RID: 53764
		private int opl_p1;

		// Token: 0x0400D205 RID: 53765
		private int opl_p2;

		// Token: 0x0400D206 RID: 53766
		private int opl_p3;
	}
}
