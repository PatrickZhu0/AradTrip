using System;

namespace behaviac
{
	// Token: 0x02003ACD RID: 15053
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node13 : Condition
	{
		// Token: 0x06015D59 RID: 89433 RVA: 0x00698986 File Offset: 0x00696D86
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node13()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570141;
		}

		// Token: 0x06015D5A RID: 89434 RVA: 0x006989A8 File Offset: 0x00696DA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F665 RID: 63077
		private BE_Target opl_p0;

		// Token: 0x0400F666 RID: 63078
		private BE_Equal opl_p1;

		// Token: 0x0400F667 RID: 63079
		private int opl_p2;
	}
}
