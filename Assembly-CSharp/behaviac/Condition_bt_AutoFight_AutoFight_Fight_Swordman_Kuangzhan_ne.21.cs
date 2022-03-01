using System;

namespace behaviac
{
	// Token: 0x020023AD RID: 9133
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node66 : Condition
	{
		// Token: 0x060130C0 RID: 78016 RVA: 0x005A3CFF File Offset: 0x005A20FF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node66()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x060130C1 RID: 78017 RVA: 0x005A3D20 File Offset: 0x005A2120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAE9 RID: 51945
		private BE_Target opl_p0;

		// Token: 0x0400CAEA RID: 51946
		private BE_Equal opl_p1;

		// Token: 0x0400CAEB RID: 51947
		private int opl_p2;
	}
}
