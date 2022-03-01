using System;

namespace behaviac
{
	// Token: 0x02003F60 RID: 16224
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node9 : Condition
	{
		// Token: 0x0601662E RID: 91694 RVA: 0x006C59D2 File Offset: 0x006C3DD2
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570217;
		}

		// Token: 0x0601662F RID: 91695 RVA: 0x006C59F4 File Offset: 0x006C3DF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE6E RID: 65134
		private BE_Target opl_p0;

		// Token: 0x0400FE6F RID: 65135
		private BE_Equal opl_p1;

		// Token: 0x0400FE70 RID: 65136
		private int opl_p2;
	}
}
