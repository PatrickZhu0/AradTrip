using System;

namespace behaviac
{
	// Token: 0x020023B5 RID: 9141
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node61 : Condition
	{
		// Token: 0x060130D0 RID: 78032 RVA: 0x005A46FB File Offset: 0x005A2AFB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node61()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 160900;
		}

		// Token: 0x060130D1 RID: 78033 RVA: 0x005A471C File Offset: 0x005A2B1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAFD RID: 51965
		private BE_Target opl_p0;

		// Token: 0x0400CAFE RID: 51966
		private BE_Equal opl_p1;

		// Token: 0x0400CAFF RID: 51967
		private int opl_p2;
	}
}
