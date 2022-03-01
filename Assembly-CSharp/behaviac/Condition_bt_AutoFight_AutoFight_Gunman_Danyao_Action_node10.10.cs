using System;

namespace behaviac
{
	// Token: 0x020025EC RID: 9708
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node10 : Condition
	{
		// Token: 0x0601351F RID: 79135 RVA: 0x005BE13E File Offset: 0x005BC53E
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node10()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013520 RID: 79136 RVA: 0x005BE174 File Offset: 0x005BC574
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF64 RID: 53092
		private int opl_p0;

		// Token: 0x0400CF65 RID: 53093
		private int opl_p1;

		// Token: 0x0400CF66 RID: 53094
		private int opl_p2;

		// Token: 0x0400CF67 RID: 53095
		private int opl_p3;
	}
}
