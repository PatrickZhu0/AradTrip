using System;

namespace behaviac
{
	// Token: 0x02002BB3 RID: 11187
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node5 : Condition
	{
		// Token: 0x0601406C RID: 82028 RVA: 0x00603E06 File Offset: 0x00602206
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node5()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x0601406D RID: 82029 RVA: 0x00603E3C File Offset: 0x0060223C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA64 RID: 55908
		private int opl_p0;

		// Token: 0x0400DA65 RID: 55909
		private int opl_p1;

		// Token: 0x0400DA66 RID: 55910
		private int opl_p2;

		// Token: 0x0400DA67 RID: 55911
		private int opl_p3;
	}
}
