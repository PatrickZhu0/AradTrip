using System;

namespace behaviac
{
	// Token: 0x02001F13 RID: 7955
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node31 : Condition
	{
		// Token: 0x060127CA RID: 75722 RVA: 0x00568816 File Offset: 0x00566C16
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node31()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 180020;
		}

		// Token: 0x060127CB RID: 75723 RVA: 0x00568838 File Offset: 0x00566C38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1BF RID: 49599
		private BE_Target opl_p0;

		// Token: 0x0400C1C0 RID: 49600
		private BE_Equal opl_p1;

		// Token: 0x0400C1C1 RID: 49601
		private int opl_p2;
	}
}
