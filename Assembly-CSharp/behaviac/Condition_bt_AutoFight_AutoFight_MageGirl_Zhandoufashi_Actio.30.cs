using System;

namespace behaviac
{
	// Token: 0x02002728 RID: 10024
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node58 : Condition
	{
		// Token: 0x06013792 RID: 79762 RVA: 0x005CD06E File Offset: 0x005CB46E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node58()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013793 RID: 79763 RVA: 0x005CD0A4 File Offset: 0x005CB4A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1EB RID: 53739
		private int opl_p0;

		// Token: 0x0400D1EC RID: 53740
		private int opl_p1;

		// Token: 0x0400D1ED RID: 53741
		private int opl_p2;

		// Token: 0x0400D1EE RID: 53742
		private int opl_p3;
	}
}
