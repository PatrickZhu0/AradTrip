using System;

namespace behaviac
{
	// Token: 0x02001F7C RID: 8060
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node8 : Condition
	{
		// Token: 0x06012898 RID: 75928 RVA: 0x0056DBDF File Offset: 0x0056BFDF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012899 RID: 75929 RVA: 0x0056DC14 File Offset: 0x0056C014
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C289 RID: 49801
		private int opl_p0;

		// Token: 0x0400C28A RID: 49802
		private int opl_p1;

		// Token: 0x0400C28B RID: 49803
		private int opl_p2;

		// Token: 0x0400C28C RID: 49804
		private int opl_p3;
	}
}
