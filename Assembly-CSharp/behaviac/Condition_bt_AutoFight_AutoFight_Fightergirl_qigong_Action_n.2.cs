using System;

namespace behaviac
{
	// Token: 0x02001EF4 RID: 7924
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node6 : Condition
	{
		// Token: 0x0601278C RID: 75660 RVA: 0x00567AE7 File Offset: 0x00565EE7
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 180020;
		}

		// Token: 0x0601278D RID: 75661 RVA: 0x00567B08 File Offset: 0x00565F08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C180 RID: 49536
		private BE_Target opl_p0;

		// Token: 0x0400C181 RID: 49537
		private BE_Equal opl_p1;

		// Token: 0x0400C182 RID: 49538
		private int opl_p2;
	}
}
