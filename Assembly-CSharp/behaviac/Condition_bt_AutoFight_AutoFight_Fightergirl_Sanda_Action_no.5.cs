using System;

namespace behaviac
{
	// Token: 0x02001F2A RID: 7978
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node21 : Condition
	{
		// Token: 0x060127F7 RID: 75767 RVA: 0x0056A20B File Offset: 0x0056860B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node21()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 183204;
		}

		// Token: 0x060127F8 RID: 75768 RVA: 0x0056A22C File Offset: 0x0056862C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1EE RID: 49646
		private BE_Target opl_p0;

		// Token: 0x0400C1EF RID: 49647
		private BE_Equal opl_p1;

		// Token: 0x0400C1F0 RID: 49648
		private int opl_p2;
	}
}
