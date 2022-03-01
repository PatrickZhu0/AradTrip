using System;

namespace behaviac
{
	// Token: 0x02001DA3 RID: 7587
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node8 : Condition
	{
		// Token: 0x06012500 RID: 75008 RVA: 0x00558344 File Offset: 0x00556744
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 180000;
		}

		// Token: 0x06012501 RID: 75009 RVA: 0x00558368 File Offset: 0x00556768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEEC RID: 48876
		private BE_Target opl_p0;

		// Token: 0x0400BEED RID: 48877
		private BE_Equal opl_p1;

		// Token: 0x0400BEEE RID: 48878
		private int opl_p2;
	}
}
