using System;

namespace behaviac
{
	// Token: 0x02003E8E RID: 16014
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node0 : Condition
	{
		// Token: 0x0601649C RID: 91292 RVA: 0x006BD8B5 File Offset: 0x006BBCB5
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node0()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x0601649D RID: 91293 RVA: 0x006BD8EC File Offset: 0x006BBCEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCD4 RID: 64724
		private int opl_p0;

		// Token: 0x0400FCD5 RID: 64725
		private int opl_p1;

		// Token: 0x0400FCD6 RID: 64726
		private int opl_p2;

		// Token: 0x0400FCD7 RID: 64727
		private int opl_p3;
	}
}
