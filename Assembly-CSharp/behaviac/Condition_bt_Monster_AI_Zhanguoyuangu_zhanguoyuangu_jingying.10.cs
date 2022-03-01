using System;

namespace behaviac
{
	// Token: 0x02003F51 RID: 16209
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node9 : Condition
	{
		// Token: 0x06016611 RID: 91665 RVA: 0x006C515E File Offset: 0x006C355E
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570217;
		}

		// Token: 0x06016612 RID: 91666 RVA: 0x006C5180 File Offset: 0x006C3580
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE46 RID: 65094
		private BE_Target opl_p0;

		// Token: 0x0400FE47 RID: 65095
		private BE_Equal opl_p1;

		// Token: 0x0400FE48 RID: 65096
		private int opl_p2;
	}
}
