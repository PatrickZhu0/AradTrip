using System;

namespace behaviac
{
	// Token: 0x0200360B RID: 13835
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9 : Condition
	{
		// Token: 0x0601543C RID: 87100 RVA: 0x00668C86 File Offset: 0x00667086
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x0601543D RID: 87101 RVA: 0x00668CA8 File Offset: 0x006670A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDF6 RID: 60918
		private HMType opl_p0;

		// Token: 0x0400EDF7 RID: 60919
		private BE_Operation opl_p1;

		// Token: 0x0400EDF8 RID: 60920
		private float opl_p2;
	}
}
