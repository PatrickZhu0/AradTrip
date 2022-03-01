using System;

namespace behaviac
{
	// Token: 0x02002DD9 RID: 11737
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node85 : Condition
	{
		// Token: 0x0601448F RID: 83087 RVA: 0x006184A1 File Offset: 0x006168A1
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node85()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570290;
		}

		// Token: 0x06014490 RID: 83088 RVA: 0x006184C4 File Offset: 0x006168C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE47 RID: 56903
		private BE_Target opl_p0;

		// Token: 0x0400DE48 RID: 56904
		private BE_Equal opl_p1;

		// Token: 0x0400DE49 RID: 56905
		private int opl_p2;
	}
}
