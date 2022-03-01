using System;

namespace behaviac
{
	// Token: 0x020025A9 RID: 9641
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node50 : Condition
	{
		// Token: 0x06013499 RID: 79001 RVA: 0x005BC4B2 File Offset: 0x005BA8B2
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node50()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 200;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601349A RID: 79002 RVA: 0x005BC4E8 File Offset: 0x005BA8E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CECD RID: 52941
		private int opl_p0;

		// Token: 0x0400CECE RID: 52942
		private int opl_p1;

		// Token: 0x0400CECF RID: 52943
		private int opl_p2;

		// Token: 0x0400CED0 RID: 52944
		private int opl_p3;
	}
}
