using System;

namespace behaviac
{
	// Token: 0x02002515 RID: 9493
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node112 : Condition
	{
		// Token: 0x06013373 RID: 78707 RVA: 0x005B5C0B File Offset: 0x005B400B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node112()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 260600;
		}

		// Token: 0x06013374 RID: 78708 RVA: 0x005B5C2C File Offset: 0x005B402C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD95 RID: 52629
		private BE_Target opl_p0;

		// Token: 0x0400CD96 RID: 52630
		private BE_Equal opl_p1;

		// Token: 0x0400CD97 RID: 52631
		private int opl_p2;
	}
}
