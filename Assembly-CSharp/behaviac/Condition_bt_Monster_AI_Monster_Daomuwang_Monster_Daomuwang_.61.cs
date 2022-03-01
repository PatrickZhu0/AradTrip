using System;

namespace behaviac
{
	// Token: 0x0200366F RID: 13935
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node12 : Condition
	{
		// Token: 0x060154FF RID: 87295 RVA: 0x0066D75E File Offset: 0x0066BB5E
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node12()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 8000;
			this.opl_p2 = 8000;
			this.opl_p3 = 8000;
		}

		// Token: 0x06015500 RID: 87296 RVA: 0x0066D794 File Offset: 0x0066BB94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEB5 RID: 61109
		private int opl_p0;

		// Token: 0x0400EEB6 RID: 61110
		private int opl_p1;

		// Token: 0x0400EEB7 RID: 61111
		private int opl_p2;

		// Token: 0x0400EEB8 RID: 61112
		private int opl_p3;
	}
}
