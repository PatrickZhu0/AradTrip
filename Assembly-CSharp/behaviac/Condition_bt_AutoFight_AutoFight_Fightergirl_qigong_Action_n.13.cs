using System;

namespace behaviac
{
	// Token: 0x02001F03 RID: 7939
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node18 : Condition
	{
		// Token: 0x060127AA RID: 75690 RVA: 0x0056814E File Offset: 0x0056654E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node18()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060127AB RID: 75691 RVA: 0x00568180 File Offset: 0x00566580
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C19F RID: 49567
		private int opl_p0;

		// Token: 0x0400C1A0 RID: 49568
		private int opl_p1;

		// Token: 0x0400C1A1 RID: 49569
		private int opl_p2;

		// Token: 0x0400C1A2 RID: 49570
		private int opl_p3;
	}
}
