using System;

namespace behaviac
{
	// Token: 0x02003209 RID: 12809
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4 : Condition
	{
		// Token: 0x06014C9C RID: 85148 RVA: 0x006431C2 File Offset: 0x006415C2
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014C9D RID: 85149 RVA: 0x006431E4 File Offset: 0x006415E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5E9 RID: 58857
		private HMType opl_p0;

		// Token: 0x0400E5EA RID: 58858
		private BE_Operation opl_p1;

		// Token: 0x0400E5EB RID: 58859
		private float opl_p2;
	}
}
