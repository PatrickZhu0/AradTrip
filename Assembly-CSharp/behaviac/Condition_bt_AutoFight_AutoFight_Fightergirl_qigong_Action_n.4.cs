using System;

namespace behaviac
{
	// Token: 0x02001EF7 RID: 7927
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node39 : Condition
	{
		// Token: 0x06012792 RID: 75666 RVA: 0x00567C3B File Offset: 0x0056603B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node39()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 180000;
		}

		// Token: 0x06012793 RID: 75667 RVA: 0x00567C5C File Offset: 0x0056605C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C186 RID: 49542
		private BE_Target opl_p0;

		// Token: 0x0400C187 RID: 49543
		private BE_Equal opl_p1;

		// Token: 0x0400C188 RID: 49544
		private int opl_p2;
	}
}
