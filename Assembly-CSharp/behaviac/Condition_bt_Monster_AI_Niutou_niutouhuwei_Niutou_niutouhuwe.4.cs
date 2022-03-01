using System;

namespace behaviac
{
	// Token: 0x0200370D RID: 14093
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node5 : Condition
	{
		// Token: 0x06015628 RID: 87592 RVA: 0x00673ABF File Offset: 0x00671EBF
		public Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node5()
		{
			this.opl_p0 = 5284;
		}

		// Token: 0x06015629 RID: 87593 RVA: 0x00673AD4 File Offset: 0x00671ED4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFF2 RID: 61426
		private int opl_p0;
	}
}
