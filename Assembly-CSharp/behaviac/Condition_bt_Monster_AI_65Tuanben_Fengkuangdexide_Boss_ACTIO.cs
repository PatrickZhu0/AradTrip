using System;

namespace behaviac
{
	// Token: 0x02002EAC RID: 11948
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node58 : Condition
	{
		// Token: 0x06014632 RID: 83506 RVA: 0x00621CD2 File Offset: 0x006200D2
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node58()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014633 RID: 83507 RVA: 0x00621CF4 File Offset: 0x006200F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFA7 RID: 57255
		private HMType opl_p0;

		// Token: 0x0400DFA8 RID: 57256
		private BE_Operation opl_p1;

		// Token: 0x0400DFA9 RID: 57257
		private float opl_p2;
	}
}
