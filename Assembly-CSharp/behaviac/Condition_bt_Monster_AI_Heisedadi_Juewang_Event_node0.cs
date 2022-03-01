using System;

namespace behaviac
{
	// Token: 0x0200347F RID: 13439
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node0 : Condition
	{
		// Token: 0x06015147 RID: 86343 RVA: 0x0065A186 File Offset: 0x00658586
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node0()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015148 RID: 86344 RVA: 0x0065A1A8 File Offset: 0x006585A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA48 RID: 59976
		private HMType opl_p0;

		// Token: 0x0400EA49 RID: 59977
		private BE_Operation opl_p1;

		// Token: 0x0400EA4A RID: 59978
		private float opl_p2;
	}
}
