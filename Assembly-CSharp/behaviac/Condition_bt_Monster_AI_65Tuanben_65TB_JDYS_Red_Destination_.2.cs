using System;

namespace behaviac
{
	// Token: 0x02002BB5 RID: 11189
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node1 : Condition
	{
		// Token: 0x06014070 RID: 82032 RVA: 0x00603EAC File Offset: 0x006022AC
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node1()
		{
			this.opl_p0 = 16000;
			this.opl_p1 = 12000;
			this.opl_p2 = 8000;
			this.opl_p3 = 8000;
		}

		// Token: 0x06014071 RID: 82033 RVA: 0x00603EE0 File Offset: 0x006022E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA69 RID: 55913
		private int opl_p0;

		// Token: 0x0400DA6A RID: 55914
		private int opl_p1;

		// Token: 0x0400DA6B RID: 55915
		private int opl_p2;

		// Token: 0x0400DA6C RID: 55916
		private int opl_p3;
	}
}
