using System;

namespace behaviac
{
	// Token: 0x02002617 RID: 9751
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node68 : Condition
	{
		// Token: 0x06013574 RID: 79220 RVA: 0x005C0EA7 File Offset: 0x005BF2A7
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node68()
		{
			this.opl_p0 = 1006;
		}

		// Token: 0x06013575 RID: 79221 RVA: 0x005C0EBC File Offset: 0x005BF2BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFBF RID: 53183
		private int opl_p0;
	}
}
